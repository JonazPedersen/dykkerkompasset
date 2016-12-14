using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKrepo;

namespace dykkerkompasset.Areas.Admin.Controllers
{
    public class AMenuController : Controller
    {
        private MenuFac mf = new MenuFac();
        
        // GET: Admin/AKategori
        public ActionResult Index()
        {
            return View(mf.GetAll());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            mf.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Menu menu)
        {
            mf.Insert(menu);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EditMenu editmenu = new EditMenu();
            editmenu.Menu = mf.Get(id);

            return View(editmenu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            mf.Update(menu);
            return RedirectToAction("Index");
        }
    }
}