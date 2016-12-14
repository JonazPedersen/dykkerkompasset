using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKrepo;
using System.Web.Security;
using System.Web.Helpers;

namespace dykkerkompasset.Controllers
{
    public class HomeController : Controller
    {
        BrugerFac bf = new BrugerFac();

        public ActionResult KortOverPositioner()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string adgangskode)
        {

            Bruger bruger = bf.Login(email.Trim(), Crypto.Hash(adgangskode.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                Response.Redirect("/Admin/AKategori/Index");
            }

            return Redirect("/Home/Login/");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        PositionListFac pf = new PositionListFac();

        public ActionResult VisPosition()
        {

            return View(pf.GetAll("ID", "DESC", 8));
        }
    }
}
