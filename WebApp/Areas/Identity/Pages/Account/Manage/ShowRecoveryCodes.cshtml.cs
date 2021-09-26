using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Areas.Identity.Pages.Account.Manage
{
    /// <inheritdoc />
    public class ShowRecoveryCodesModel : PageModel
    {
        /// <summary>
        /// Recovery codes
        /// </summary>
        [TempData]
        public string[] RecoveryCodes { get; set; } = default!;

        /// <summary>
        /// Status message
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; } = default!;

        /// <summary>
        /// On get show recovery codes model
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            if (RecoveryCodes.Length == 0)
            {
                return RedirectToPage("./TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
