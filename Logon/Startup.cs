using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Logon.Startup))]

namespace Logon
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
             {
                AuthenticationType = "AplicationCookie",
                LoginPath = new PathString("/Autenticacao/Login")
                    });
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
            }
        }
    }

