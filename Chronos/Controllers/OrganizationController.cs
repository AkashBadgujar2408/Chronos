using ApplicationCore.DTOs;
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Chronos.Controllers;

[Authorize]
public class OrganizationController(IOrganizationsService _organizationsService, IMapper _mapper) : Controller
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

    [HttpGet]
    public async Task<IActionResult> Update()
    {
        Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        OrganizationResponse? organizationResponse = await _organizationsService.GetUserOrganizationAsync(currentUserId);
        OrganizationUpdateRequest organizationUpdateRequest = _mapper.Map<OrganizationUpdateRequest>(organizationResponse);

        if (organizationResponse == null)
        {
            return NotFound("Organization not found for current user.");
        }

        return View(organizationUpdateRequest);
    }

    [HttpPost]
    public async Task<IActionResult> Update(OrganizationUpdateRequest model)
    {
        if (ModelState.IsValid)
        {
            model.UpdatedBy = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            OperationResult<OrganizationResponse?> orgUpdateResult = await _organizationsService.UpdateOrganizationAsync(model);

            TempData.SetNotificationAlert(orgUpdateResult);
            if (!orgUpdateResult.IsSuccessful)
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
