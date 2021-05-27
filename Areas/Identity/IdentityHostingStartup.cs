using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyOnlineStoreAPI.Configuration;
using MyOnlineStoreAPI.Data;

[assembly: HostingStartup(typeof(MyOnlineStoreAPI.Areas.Identity.IdentityHostingStartup))] 
namespace MyOnlineStoreAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyOnlineStoreAPIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MyOnlineStoreAPIContextConnection")));
            });
        }
    }
}