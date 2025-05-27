
using ApplicationCore.DTOs;
using Chronos.Core.DTOs;

namespace Chronos.Core.ServiceContracts;

public interface IUsersService
{
    Task<OperationResult<AuthenticationResponse?>> ValidateLoginCredentialsAsync(SignInRequest? loginRequest);
    Task<OperationResult<AuthenticationResponse?>> RegisterUserAsync(RegisterRequest? registerRequest);
    Task<OperationResult<AuthenticationResponse?>> UpdateUserAsync(UserUpdateRequest? userUpdateRequest);
    Task<OperationResult<AuthenticationResponse?>> GetUserByUserName(string? userName);
}
