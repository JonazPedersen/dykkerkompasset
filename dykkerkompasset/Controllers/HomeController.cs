﻿using System;
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
        public string fromWGS84toDecimal(string pos)
        {
            string newPos = pos.Replace(",", "");
            string[] arrPos = newPos.Split(':');

            int dec = int.Parse(arrPos[1]) * 60;

            return arrPos[0] + dec;
        }
        private string fromDecimalToWGS84(string longOGLat)
        {
            string[] arrPos = longOGLat.Split(',');
            int dec = int.Parse(arrPos[1]);

            return arrPos[0] + "," + (dec * 60);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Adgangskode)
        {

            Bruger bruger = bf.Login(Email.Trim(), Crypto.Hash(Adgangskode.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                Response.Redirect("/Admin/AMenu/Index");
            }

            return Redirect("/Home/Login/");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        SpotFac pf = new SpotFac();

        public ActionResult VisPosition()
        {

            return View(pf.GetAll("ID", "DESC", 10));
        }

        BillederFac imgf = new BillederFac();
        SpotFac sf = new SpotFac();

        public ActionResult ShowSpot(int id)
        {
            SpotVM SVM = new SpotVM();
            SVM.spot = sf.Get(id);
            SVM.billeder = imgf.GetBy("SpotID", id);
            
            return View(SVM);
        }

    }
}
