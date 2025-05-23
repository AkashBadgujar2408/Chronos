
using ApplicationCore.DTOs;
using Chronos.Core.DTOs;

namespace Chronos.Core.ServiceContracts;

public interface IUsersService
{
    Task<OperationResult<AuthenticationResponse?>> ValidateLoginCredentialsAsync(LoginRequest? loginRequest);
    Task<OperationResult<AuthenticationResponse?>> RegisterUserAsync(RegisterRequest? registerRequest);
    Task<OperationResult<AuthenticationResponse?>> UpdateUserAsync(UserUpdateRequest? userUpdateRequest);
}
