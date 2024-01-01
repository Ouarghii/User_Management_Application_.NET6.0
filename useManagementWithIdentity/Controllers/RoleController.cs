using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using useManagementWithIdentity.Models;
using useManagementWithIdentity.ViewModels;

[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return View("~/Views/Roles/Index.cshtml", roles);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(RoleFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            var roleExists = await _roleManager.RoleExistsAsync(model.Name);

            if (roleExists)
            {
                ModelState.AddModelError("Name", "Role already exists!");
            }
            else
            {
                // Trim the role name before creating
                var role = new IdentityRole(model.Name.Trim());

                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the error, e.g., add errors to ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
        }

        // If we reach here, there was a validation error or role already exists; return to the form
        var roles = await _roleManager.Roles.ToListAsync();
        return View("~/Views/Roles/Index.cshtml", roles);
    }


}
