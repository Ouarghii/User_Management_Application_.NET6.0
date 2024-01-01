﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using useManagementWithIdentity.Models;
using useManagementWithIdentity.ViewModels;

namespace useManagementWithIdentity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            var users=await _userManager.Users.Select(user=>new UserViewModel
            {
                id= user.Id,
                Firstname= user.FirstName,
                Lastname= user.LastName,
                Email= user.Email,
                Username= user.UserName,
                Roles =_userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if(user==null)
                return NotFound();
            var roles = await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.FirstName,
                Roles = roles.Select(async role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected =await _userManager.IsInRoleAsync(user, role.Name)
                }).Select(Task=>Task.Result)
                .ToList(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
             
            foreach(var role in model.Roles) {
                if(userRoles.Any(r=>r==role.RoleName) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }


            } return RedirectToAction(nameof(Index));
        }
    }
}
