
using ApplicationCore.DTOs;
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;
using Chronos.Core.Helpers;
using Chronos.Core.RepositoryContracts;
using Chronos.Core.ServiceContracts;

namespace Chronos.Core.Services;
public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult<AuthenticationResponse?>> ValidateLoginCredentialsAsync(LoginRequest? loginRequest)
    {
        OperationType operation = OperationType.Read;

        if (loginRequest == null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "Invalid login request.");
        }

        if (!ValidationHelper.TryValidate(loginRequest, out var validationResults))
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: validationResults.First().ErrorMessage);
        }

        ApplicationUser? existingUser = await _usersRepository.GetUserByUserNameAsync(loginRequest.UserName);

        if (existingUser == null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "Username doesn't exist. Please try again.");
        }
        ApplicationUser? validatedUser = await _usersRepository.ValidateLoginCredentialsAsync(loginRequest.UserName, loginRequest.Password);

        if (validatedUser == null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "Username and passwords do not match.");
        }
        AuthenticationResponse authResponse = _mapper.Map<AuthenticationResponse>(validatedUser);

        return OperationResult.Success(authResponse, OperationType.Read, message: "Login validation successful.")!;
    }

    public async Task<OperationResult<AuthenticationResponse?>> RegisterUserAsync(RegisterRequest? registerRequest)
    {
        OperationType operation = OperationType.Create;
        if (registerRequest == null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "User registration failed.");
        }

        if (!ValidationHelper.TryValidate(registerRequest, out var validationResults))
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: validationResults.First().ErrorMessage);
        }
        ApplicationUser? existingUser = await _usersRepository.GetUserByUserNameAsync(registerRequest.UserName);

        if (existingUser != null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "Username already exists. Please set a different user name.");
        }
        ApplicationUser? appUserToAdd = _mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser? addedUser = await _usersRepository.AddUserAsync(appUserToAdd);
        if (addedUser == null)
        {
            return OperationResult.Failure<AuthenticationResponse?>(operation, message: "User registration failed!");
        }
        AuthenticationResponse? addedUserAuthResponse = _mapper.Map<AuthenticationResponse>(addedUser);

        return OperationResult.Success(addedUserAuthResponse, operation, message: "User registered successfully.")!;
    }

    public Task<OperationResult<AuthenticationResponse?>> UpdateUserAsync(UserUpdateRequest? userUpdateRequest)
    {
        throw new NotImplementedException();
    }
}
