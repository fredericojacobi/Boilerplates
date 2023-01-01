using Entities.DataTransferObjects.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Services;

public interface IAuthenticationService
{
    Task<ActionResult> Authenticate(AuthenticationDto authenticationDto);
}