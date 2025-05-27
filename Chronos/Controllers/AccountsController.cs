using ApplicationCore.DTOs;
using Chronos.Core.DTOs;
using Chronos.Core.ServiceContracts;
using Chronos.Core.Services;
using Chronos.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly JwtService _jwtService;

        public AccountsController(IUsersService usersService, JwtService jwtService)
        {
            _usersService = usersService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInRequest model)
        {
            if (ModelState.IsValid)
            {
                OperationResult<AuthenticationResponse?> signInResult = await _usersService.ValidateLoginCredentialsAsync(model);
                if (signInResult.IsSuccessful && signInResult.Entity != null)
                {
                    //Generate JWT
                    string jwtToken = _jwtService.GenerateToken(signInResult.Entity);

                    //Store JWT in secure cookie
                    Response.Cookies.Append("jwt", jwtToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, //Only over HTTPS
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(1)
                    });

                    TempData.SetNotificationAlert(signInResult.Status, "User signed in successfully");
                }
                else
                {
                    TempData.SetNotificationAlert(OperationStatus.Failed, "User sign in failed");
                }
            }
            else
            {
                TempData.SetNotificationAlert(OperationStatus.Failed, "Invalid sign in request!");
                return View(model);
            }

            return RedirectToAction("Index", "Dashboard");
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
                if (!model.AreTermsNConditionsAccepted)
                {
                    TempData.SetNotificationAlert(OperationStatus.Failed, ModelState[nameof(model.AreTermsNConditionsAccepted)]?.Errors.FirstOrDefault()?.ErrorMessage!);
                }
                else
                {
                    TempData.SetNotificationAlert(OperationStatus.Failed, "Validation failed.");
                }
                return View(model);
            }
            return View();
        }
    }
}
