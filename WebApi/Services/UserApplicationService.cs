using System.Text.Json;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Entities.Enums;
using Entities.Models;
using Generics.Extensions;
using Generics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILoggerService _loggerService;
    private readonly IMapper _mapper;

    public UserApplicationService(ILoggerService loggerService, IRepositoryWrapper repository, IMapper mapper)
    {
        _loggerService = loggerService;
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ActionResult> GetAllAsync(int page, int limit)
    {
        await _loggerService.LogAsync("test message", LogType.Success);
        return page > 0 && limit > 0 ? await GetAllPaginatedAsync(page, limit) : await GetAllAsync();
    }

    public async Task<ActionResult> GetAllAsync()
    {
        var responseMessage = new ResponseMessage<UserApplicationDto>();

        try
        {
            var result = await _repository.UserApplication.ReadAllUsersAsync();
            if (result.IsEmpty()) return responseMessage.NotFound();

            var dto = _mapper.Map<List<UserApplicationDto>>(result);

            return responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Get User failed. Exception message: {ex.Message}", LogType.Error);
            return responseMessage.InternalServerError(ex);
        }
    }

    private async Task<ActionResult> GetAllPaginatedAsync(int page, int limit)
    {
        var responseMessage = new ResponseMessage<Pagination<UserApplicationDto>>();

        try
        {
            var result = await _repository.UserApplication.ReadAllUsersPaginatedAsync(page, limit);
            if (result.Records.IsEmpty()) return responseMessage.NotFound();

            var dto = _mapper.Map<Pagination<UserApplicationDto>>(result);

            return responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Get Users failed. Exception message: {ex.Message}", LogType.Error);
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> GetAsync(Guid id)
    {
        var responseMessage = new ResponseMessage<UserApplicationDto>();

        try
        {
            var user = await _repository.UserApplication.ReadUserByIdAsync(id);
            if (user == null || user.Id.IsDefault()) return responseMessage.NotFound("User not found");

            var dto = _mapper.Map<UserApplicationDto>(user);
            return responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Get User id: {id} failed. Exception message: {ex.Message}", LogType.Error);
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> PostAsync(UserApplicationRegisterDto userDTO)
    {
        var responseMessage = new ResponseMessage<UserApplicationDto>();

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

                await _loggerService.LogAsync($"Failed to create a new User. Error: {msg}", LogType.Error);
                return responseMessage.BadRequest(msg);
            }

            var createdUser = await _repository.UserApplication.ReadUserByUserNameAsync(user.UserName);
            await _loggerService.LogAsync($"UserId {createdUser?.Id} created. {JsonSerializer.Serialize(createdUser)}", LogType.Success, createdUser?.Id);

            var dto = _mapper.Map<UserApplicationDto>(createdUser);
            return responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Failed to create a new User. Exception message: {ex.Message}", LogType.Error);
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> PutAsync(Guid id, UserApplicationUpdateDto userDTO)
    {
        var responseMessage = new ResponseMessage<bool>();

        if (!id.Equals(userDTO.Id))
        {
            await _loggerService.LogAsync($"Fail to update an User. Error: Id's doesn't match. Querystring: {id}. Dto: {userDTO.Id}", LogType.Error);
            return responseMessage.BadRequest("Id's doesn't match.");
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

                await _loggerService.LogAsync($"Failed to update an User. Error: {msg}", LogType.Error, user.Id);
                return responseMessage.BadRequest(msg);
            }

            var updatedUser = await _repository.UserApplication.ReadUserByIdAsync(user.Id);
            await _loggerService.LogAsync($"UserId {userDTO.Id} updated. {JsonSerializer.Serialize(updatedUser)}", LogType.Success, userDTO.Id);
            return responseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Failed to update an User. Exception message: {ex.Message}", LogType.Error, userDTO.Id);
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var responseMessage = new ResponseMessage<bool>();

        if (id.IsDefault()) return responseMessage.BadRequest("Invalid Id");

        try
        {
            var user = await _repository.UserApplication.ReadUserByIdAsync(id);
            if (user == null) return responseMessage.NotFound();

            var result = await _repository.UserApplication.DeleteUserAsync(id);
            if (!result.Succeeded)
            {
                var msg = string.Empty;
                result.Errors?
                    .ToList()
                    .ForEach(x => { msg += x.Description; });

                await _loggerService.LogAsync($"Failed to delete an User. {JsonSerializer.Serialize(user)} Error: {msg}", LogType.Error, id);
                return responseMessage.BadRequest(msg);
            }

            await _loggerService.LogAsync($"User deleted. {JsonSerializer.Serialize(user)}", LogType.Success, id);
            return responseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Failed to delete an User. Exception message: {ex.Message}", LogType.Error, id);
            return responseMessage.InternalServerError(ex);
        }
    }
}