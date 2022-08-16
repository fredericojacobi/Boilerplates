using System.Net;
using AutoMapper;
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

    public UserApplicationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseMessage<UserApplicationDto>> GetAllAsync()
    {
        try
        {
            var result = await _repository.UserApplication.ReadAllUsersAsync();
            if (result.IsEmpty()) 
                return new ResponseMessage<UserApplicationDto>(HttpStatusCode.NotFound, "Not found");

            var dto = _mapper.Map<IEnumerable<UserApplicationDto>>(result);
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.OK, dto);
        }
        catch (Exception ex)
        {
            var msg = $"{DateTime.Now} : {ex.Message} \n Source: {ex.Source} \n InnerException: {ex.InnerException}";
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.InternalServerError, msg);
        }
    }

    public async Task<ResponseMessage<UserApplicationDto>> GetAsync(Guid id)
    {
        try
        {
            var result = await _repository.UserApplication.ReadUserByIdAsync(id);
            if (result.Id.IsDefault())
                return new ResponseMessage<UserApplicationDto>(HttpStatusCode.NotFound, "Not found");

            var dto = _mapper.Map<UserApplicationDto>(result);
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.OK, dto);
        }
        catch (Exception ex)
        {
            var msg = $"{DateTime.Now} : {ex.Message} \n Source: {ex.Source} \n InnerException: {ex.InnerException}";
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.InternalServerError, msg);
        }
    }

    public async Task<ResponseMessage<UserApplicationDto>> PostAsync(UserApplicationRegisterDto userDTO)
    {
        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.CreateUserAsync(user, userDTO.Password);
            if (!result)
                return new ResponseMessage<UserApplicationDto>(
                    HttpStatusCode.InternalServerError,
                    "Woops! Something went wrong");

            var createdUser = await _repository.UserApplication.ReadUserByUserNameAsync(user.UserName);
            var dto = _mapper.Map<UserApplicationDto>(createdUser);
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.OK, dto);
        }
        catch (Exception ex)
        {
            var msg = $"{DateTime.Now} : {ex.Message} \n Source: {ex.Source} \n InnerException: {ex.InnerException}";
            return new ResponseMessage<UserApplicationDto>(HttpStatusCode.InternalServerError, msg);
        }
    }

    public async Task<ResponseMessage<bool>> PutAsync(Guid id, UserApplicationUpdateDto userDTO)
    {
        if (!id.Equals(userDTO.Id))
            return new ResponseMessage<bool>(HttpStatusCode.BadRequest, "Id's are differents");

        try
        {
            var user = _mapper.Map<UserApplication>(userDTO);
            var result = await _repository.UserApplication.UpdateUserAsync(user);
            return new ResponseMessage<bool>(
                result ? HttpStatusCode.OK : HttpStatusCode.InternalServerError,
                result ? "Success" : "Woops! Something went wrong");
        }
        catch (Exception ex)
        {
            var msg = $"{DateTime.Now} : {ex.Message} \n Source: {ex.Source} \n InnerException: {ex.InnerException}";
            return new ResponseMessage<bool>(HttpStatusCode.InternalServerError, msg);
        }
    }

    public async Task<ResponseMessage<bool>> DeleteAsync(Guid id)
    {
        if (id.IsDefault())
            return new ResponseMessage<bool>(HttpStatusCode.BadRequest, "Invalid Id");

        try
        {
            var result = await _repository.UserApplication.DeleteUserAsync(id);
            return new ResponseMessage<bool>(
                result ? HttpStatusCode.OK : HttpStatusCode.InternalServerError,
                result ? "Success" : "Woops! Something went wrong");
        }
        catch (Exception ex)
        {
            var msg = $"{DateTime.Now} : {ex.Message} \n Source: {ex.Source} \n InnerException: {ex.InnerException}";
            return new ResponseMessage<bool>(HttpStatusCode.InternalServerError, msg);
        }
    }
}