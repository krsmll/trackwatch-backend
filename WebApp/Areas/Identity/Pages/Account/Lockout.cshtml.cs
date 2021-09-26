using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Identity.Pages.Account
{
    /// <inheritdoc />
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        /// <summary>
        /// Lockout model on get.
        /// </summary>
        public void OnGet()
        {

        }
    }
}
