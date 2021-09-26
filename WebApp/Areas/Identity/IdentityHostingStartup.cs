using System;
using DAL.App.EF;
using Domain.App.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WebApp.Areas.Identity.IdentityHostingStartup))]
namespace WebApp.Areas.Identity
{
    /// <summary>
    /// IdentityHostingStartup
    /// </summary>
    public class IdentityHostingStartup : IHostingStartup
    {
        /// <summary>
        /// Configures identity hosting startup.
        /// </summary>
        /// <param name="builder">Web host builder</param>
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}