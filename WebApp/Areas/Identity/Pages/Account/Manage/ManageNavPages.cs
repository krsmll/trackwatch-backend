using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Navigational page management
    /// </summary>
    public static class ManageNavPages
    {
        /// <summary>
        /// Index
        /// </summary>
        public static string Index => "Index";

        /// <summary>
        /// Email
        /// </summary>
        public static string Email => "Email";

        /// <summary>
        /// Change password
        /// </summary>
        public static string ChangePassword => "ChangePassword";

        /// <summary>
        /// Download personal data
        /// </summary>
        public static string DownloadPersonalData => "DownloadPersonalData";

        /// <summary>
        /// Delete personal data
        /// </summary>
        public static string DeletePersonalData => "DeletePersonalData";

        /// <summary>
        /// External logins
        /// </summary>
        public static string ExternalLogins => "ExternalLogins";

        /// <summary>
        /// Personal data
        /// </summary>
        public static string PersonalData => "PersonalData";

        /// <summary>
        /// Two factor authentication
        /// </summary>
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        /// <summary>
        /// Index nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index)!;

        /// <summary>
        /// Email nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email)!;

        /// <summary>
        /// Change password nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword)!;

        /// <summary>
        /// Download personal data nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData)!;

        /// <summary>
        /// Delete personal data nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData)!;

        /// <summary>
        /// External logins nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins)!;

        /// <summary>
        /// Personal data nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData)!;

        /// <summary>
        /// Two factor authentication nav class
        /// </summary>
        /// <param name="viewContext">View context</param>
        /// <returns></returns>
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication)!;

        private static string? PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
