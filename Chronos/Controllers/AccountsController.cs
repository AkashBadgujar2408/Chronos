using ApplicationCore.DTOs;
using Chronos.Core.DTOs;
using Chronos.Core.ServiceContracts;
using Chronos.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUsersService _usersService;

        public AccountsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                
            }
            else
            {
                //TempData.SetNotificationAlert(OperationResult.Failed, "User not found");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                OperationResult<AuthenticationResponse?> registerResult = await _usersService.RegisterUserAsync(model);
                if (registerResult.IsSuccessful && registerResult.Entity != null)
                {
                    TempData.SetNotificationAlert(registerResult.Status, "User registered successfully");
                }
                else
                {
                    TempData.SetNotificationAlert(OperationStatus.Failed, "User registration failed");
                }
            }
            else
            {
                //TempData.SetNotificationAlert(OperationResult.Failed, "User registration failed");
            }
            return View();
        }
    }
}
