using Entities.DataTransferObjects.UserApplication;
using Generics.Models;

namespace Contracts.Services;

public interface IUserApplicationService
{
    Task<ResponseMessage<UserApplicationDto>> GetAllAsync();
    Task<ResponseMessage<UserApplicationDto>> GetAsync(Guid id);
    Task<ResponseMessage<UserApplicationDto>> PostAsync(UserApplicationRegisterDto userDTO);
    Task<ResponseMessage<bool>> PutAsync(Guid id, UserApplicationUpdateDto userDTO);
    Task<ResponseMessage<bool>> DeleteAsync(Guid id);
}