using Entities.DataTransferObjects.UserApplication;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Services;

public interface IUserApplicationService
{
    Task<ActionResult> Authenticate(UserApplicationLoginDto userDTO);
    Task<ActionResult> GetAllAsync(int page, int limit);
    Task<ActionResult> GetAsync(Guid id);
    Task<ActionResult> PostAsync(UserApplicationRegisterDto userDTO);
    Task<ActionResult> PutAsync(Guid id, UserApplicationUpdateDto userDTO);
    Task<ActionResult> DeleteAsync(Guid id);
}