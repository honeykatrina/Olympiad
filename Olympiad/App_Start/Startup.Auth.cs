using System;
using DataLayer.Models;
using LogicLayer.Infrastructure;
using LogicLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Olympiad.Models;

[assembly: OwinStartupAttribute(typeof(Olympiad.Startup))]
namespace Olympiad
{
    public partial class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);

            // Включение использования файла cookie, в котором приложение может хранить информацию для пользователя, выполнившего вход,
            // и использование файла cookie для временного хранения информации о входах пользователя с помощью стороннего поставщика входа
            // Настройка файла cookie для входа
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DbConnection");
        }
    }
}