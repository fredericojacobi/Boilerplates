using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Authentication;
using Entities.Enums;
using Generics.Constants;
using Generics.Extensions;
using Generics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILoggerService _loggerService;
    
    public AuthenticationService(ILoggerService loggerService, IRepositoryWrapper repository)
    {
        _loggerService = loggerService;
        _repository = repository;
    }
    
    public async Task<ActionResult> Authenticate(AuthenticationDto authenticationDto)
    {
        var responseMessage = new ResponseMessage<AuthenticationDto>();
        
        try
        {
            var user = await _repository.UserApplication.ReadUserByUserNameAsync(authenticationDto.UserName);
            if (user == null) return responseMessage.NotFound("User not found");

            if (await _repository.UserApplication.ValidatePassword(user, authenticationDto.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDto = new AuthenticationDto
                {
                    Token = tokenHandler.GenerateToken(AppSettings.JwtSecret, user.Id),
                    UserName = user.UserName
                };

                await _loggerService.LogAsync($"Authentication token generated. Token: {tokenDto.Token} {JsonSerializer.Serialize(user)}", LogType.Success, user.Id);
                return responseMessage.Ok(tokenDto);
            }

            await _loggerService.LogAsync($"Authentication failed. Wrong username or password.", LogType.Error, user.Id);

            return responseMessage.Unauthorized("Wrong username or password.");
        }
        catch (Exception ex)
        {
            await _loggerService.LogAsync($"Authentication failed. Exception message: {ex.Message}", LogType.Error);
            return responseMessage.InternalServerError(ex);
        }
    }
}