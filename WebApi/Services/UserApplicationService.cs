using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Entities.Enums;
using Entities.Models;
using Extensions;
using Generics.Constants;
using Generics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILoggerService _loggerService;
    private readonly IMapper _mapper;

    private readonly ResponseMessage<UserApplicationDto> _responseMessage = new();
    private readonly ResponseMessage<bool> _bResponseMessage = new();

    public UserApplicationService(ILoggerService loggerService, IRepositoryWrapper repository, IMapper mapper)
    {
        _loggerService = loggerService;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ActionResult> Authenticate(UserApplicationLoginDto userDTO)
    {
        var responseMessage = new ResponseMessage<UserApplicationTokenDto>();

        try
        {
            var user = await _repository.UserApplication.ReadUserByUserNameAsync(userDTO.UserName);
            if (user == null) return responseMessage.NotFound("User not found");
                
            if (await _repository.UserApplication.ValidatePassword(user, userDTO.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDto = new UserApplicationTokenDto
                {
                    Token = tokenHandler.GenerateToken(AppSettings.JwtSecret, user.Id),
                    UserName = user.UserName
                };

                await _loggerService.Log($"Authentication token generated. Token: {tokenDto.Token} {JsonSerializer.Serialize(user)}", LogType.Authentication, user.Id);
                return responseMessage.Ok(tokenDto);
            }

            await _loggerService.Log($"Authentication failed. Wrong username or password.", LogType.Error, user.Id);

            return responseMessage.Unauthorized("Wrong username or password.");
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Authentication failed. Exception message: {ex.Message}", LogType.Exception);
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> GetAllAsync()
    {
        try
        {
            var result = await _repository.UserApplication.ReadAllUsersAsync();
            if (result.IsEmpty()) return _responseMessage.NotFound();

            var dto = _mapper.Map<IEnumerable<UserApplicationDto>>(result);
            return _responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Get Users failed. Exception message: {ex.Message}", LogType.Exception);
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> GetAsync(Guid id)
    {
        try
        {
            var user = await _repository.UserApplication.ReadUserByIdAsync(id);
            if (user == null || user.Id.IsDefault()) return _responseMessage.NotFound("User not found");

            var dto = _mapper.Map<UserApplicationDto>(user);
            return _responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Get User {id} failed. Exception message: {ex.Message}", LogType.Exception);
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> PostAsync(UserApplicationRegisterDto userDTO)
    {
        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.CreateUserAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                var msg = string.Empty;
                result.Errors?
                    .ToList()
                    .ForEach(x => { msg += x.Description; });
                
                await _loggerService.Log($"Failed to create a new User. Error: {msg}", LogType.Error);
                return _responseMessage.BadRequest(msg);
            }

            var createdUser = await _repository.UserApplication.ReadUserByUserNameAsync(user.UserName);
            await _loggerService.Log($"UserId {createdUser?.Id} created. {JsonSerializer.Serialize(createdUser)}", LogType.Success, createdUser?.Id);
            
            var dto = _mapper.Map<UserApplicationDto>(createdUser);
            return _responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Failed to create a new User. Exception message: {ex.Message}", LogType.Exception);
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> PutAsync(Guid id, UserApplicationUpdateDto userDTO)
    {
        if (!id.Equals(userDTO.Id))
        {
            await _loggerService.Log($"Fail to update an User. Error: Id's doesn't match. Querystring: {id}. Dto: {userDTO.Id}", LogType.Error);
            return _bResponseMessage.BadRequest("Id's doesn't match.");
        }

        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.UpdateUserAsync(user);
            if (!result.Succeeded)
            {
                var msg = string.Empty;
                result.Errors?
                    .ToList()
                    .ForEach(x => { msg += x.Description; });
                
                await _loggerService.Log($"Failed to update an User. Error: {msg}", LogType.Error, user.Id);
                return _bResponseMessage.BadRequest(msg);
            }

            var updatedUser = await _repository.UserApplication.ReadUserByIdAsync(user.Id);
            await _loggerService.Log($"UserId {userDTO.Id} updated. {JsonSerializer.Serialize(updatedUser)}", LogType.Success, userDTO.Id);
            return _bResponseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Failed to update an User. Exception message: {ex.Message}", LogType.Exception, userDTO.Id);
            return _bResponseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        if (id.IsDefault()) return _bResponseMessage.BadRequest("Invalid Id");

        try
        {
            var user = await _repository.UserApplication.ReadUserByIdAsync(id);
            if(user == null) return _responseMessage.NotFound();
            
            var result = await _repository.UserApplication.DeleteUserAsync(id);
            if (!result.Succeeded)
            {
                var msg = string.Empty;
                result.Errors?
                    .ToList()
                    .ForEach(x => { msg += x.Description; });
                
                await _loggerService.Log($"Failed to delete an User. Error: {msg}", LogType.Error, id);
                return _bResponseMessage.BadRequest(msg);
            }
            
            await _loggerService.Log($"User deleted. {JsonSerializer.Serialize(user)}", LogType.Success, id);
            return _bResponseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            await _loggerService.Log($"Failed to delete an User. Exception message: {ex.Message}", LogType.Exception, id);
            return _bResponseMessage.InternalServerError(ex);
        }
    }
}