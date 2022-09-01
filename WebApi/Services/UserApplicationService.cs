using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Constants;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Entities.Models;
using Extensions;
using Generics.Models;

namespace Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    private readonly ResponseMessage<UserApplicationDto> _responseMessage = new();
    private readonly ResponseMessage<bool> _bResponseMessage = new();
    
    public UserApplicationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseMessage<UserApplicationTokenDto>> Authenticate(UserApplicationLoginDto userDTO)
    {
        var responseMessage = new ResponseMessage<UserApplicationTokenDto>();
        
        try
        {
            var user = await _repository.UserApplication.ReadUserByUserNameAsync(userDTO.UserName);
            if (await _repository.UserApplication.ValidatePassword(user, userDTO.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDto = new UserApplicationTokenDto
                {
                    Token = tokenHandler.GenerateToken(AppSettings.JwtSecret, user.Id),
                    UserName = user.UserName
                };
                
                return responseMessage.Ok(tokenDto);
            }

            return responseMessage.Unauthorized("Wrong username or password.");
        }
        catch (Exception ex)
        {
            return responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ResponseMessage<UserApplicationDto>> GetAllAsync()
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
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ResponseMessage<UserApplicationDto>> GetAsync(Guid id)
    {
        try
        {
            var result = await _repository.UserApplication.ReadUserByIdAsync(id);
            if (result.Id.IsDefault()) return _responseMessage.NotFound();

            var dto = _mapper.Map<UserApplicationDto>(result);
            return _responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ResponseMessage<UserApplicationDto>> PostAsync(UserApplicationRegisterDto userDTO)
    {
        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.CreateUserAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                var msg = string.Empty;
                result.Errors?.ToList().ForEach(x => { msg += x.Description; });
                return _responseMessage.BadRequest(msg);
            }

            var createdUser = await _repository.UserApplication.ReadUserByUserNameAsync(user.UserName);
            var dto = _mapper.Map<UserApplicationDto>(createdUser);
            return _responseMessage.Ok(dto);
        }
        catch (Exception ex)
        {
            return _responseMessage.InternalServerError(ex);
        }
    }

    public async Task<ResponseMessage<bool>> PutAsync(Guid id, UserApplicationUpdateDto userDTO)
    {
        if (!id.Equals(userDTO.Id)) return _bResponseMessage.BadRequest("Id's are differents");

        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.UpdateUserAsync(user);
            return _bResponseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            return _bResponseMessage.InternalServerError(ex);
        }
    }

    public async Task<ResponseMessage<bool>> DeleteAsync(Guid id)
    {
        if (id.IsDefault()) return _bResponseMessage.BadRequest("Invalid Id");

        try
        {
            var result = await _repository.UserApplication.DeleteUserAsync(id);
            return _bResponseMessage.IdentityResultMessage(result);
        }
        catch (Exception ex)
        {
            return _bResponseMessage.InternalServerError(ex);
        }
    }
}