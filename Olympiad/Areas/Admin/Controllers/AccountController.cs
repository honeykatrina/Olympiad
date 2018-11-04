using LogicLayer.Interfaces;
using LogicLayer.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Olympiad.Areas.Admin.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Olympiad.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        
        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}