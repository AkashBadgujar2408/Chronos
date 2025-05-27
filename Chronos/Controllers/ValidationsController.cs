using ApplicationCore.DTOs;
using Chronos.Core.DTOs;
using Chronos.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Controllers;

public class ValidationsController(IUsersService _usersService) : Controller
{
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> IsUserNameAvailable(string username)
    {
        OperationResult<AuthenticationResponse?> userSearchResult = await _usersService.GetUserByUserName(username.Trim());

        if (userSearchResult != null && userSearchResult.Entity != null)
        {
            return Json(true);
        }
        return Json(false);
    }
}
