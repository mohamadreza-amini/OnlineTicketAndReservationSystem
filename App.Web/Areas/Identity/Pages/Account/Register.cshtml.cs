// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly IUserService _userService;

        public RegisterModel(ILogger<RegisterModel> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [BindProperty]
        public Input _Input { get; set; }

        public class Input
        {
            public UserCommand userCommand { get; set; }
            public IFormFile formFile { get; set; }

        }

        public string ReturnUrl { get; set; }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "upload");
            var address = Path.Combine(root,_Input.formFile.FileName);
            _Input.userCommand.BlobCommand = new BlobCommand { FileAddress = address ,MimeType = _Input.formFile.ContentType,FileSize=(int)_Input.formFile.Length};
            

            if (ModelState.IsValid)
            {

                var result = await _userService.CreateUser(_Input.userCommand);
                
                _Input.formFile.CopyTo(new FileStream(address, FileMode.Create));
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userService.SignIn(_Input.userCommand);

                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

    }
}
