using ApplicationCore.DTOs;
using Chronos.Core.DTOs;
using Chronos.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Chronos.Controllers;

[Authorize]
public class OrganizationController(IOrganizationsService _organizationsService) : Controller
{
    [HttpGet]
    public IActionResult Create ()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrganizationCreateRequest model)
    {
        if (ModelState.IsValid)
        {
            model.CreatedBy = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            OperationResult<OrganizationResponse?> orgCreateResult = await _organizationsService.CreateOrganizationAsync(model);

            TempData.SetNotificationAlert(orgCreateResult);
            if (!orgCreateResult.IsSuccessful)
            {
                return View(model);
            }
        }
        else
        {
            TempData.SetNotificationAlert(OperationStatus.Failed, message: "Validation failed.");
            return View(model);
        }

        return RedirectToAction("Index", "Dashboard");
    }
}
