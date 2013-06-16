using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using AR2AP.WebApp.Models.Account;

namespace AR2AP.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AR2AP.Service.EmpService service = new AR2AP.Service.EmpService();
                var entity = service.GetEntity(model.UserName, model.Password);
                if (entity != null)
                {
                    AR2AP.WebApp.Authentication.AuthUtility.RegisterTicket(entity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "用户名或密码不正确！");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
