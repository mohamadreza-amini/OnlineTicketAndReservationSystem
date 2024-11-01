// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Model.Entities;
using DataTransferObject.DTOClasses.Contracts.Commands;
using Service.ServiceClasses;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        
        private readonly ILogger<LoginModel> _logger;
        private readonly IUserService _userService;

        public LoginModel(ILogger<LoginModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [BindProperty]
        public LoginCommand loginCommand { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

           
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            

            if (ModelState.IsValid)
            {
                if (await _userService.UserExist(loginCommand))
                {
                    var result = await _userService.PasswordSignIn(loginCommand);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

           
            return Page();
        }
    }
}
