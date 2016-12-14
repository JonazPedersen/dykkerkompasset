using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKrepo;

namespace dykkerkompasset.Controllers
{
    public class PositionsListController : Controller
    {
        PositionListFac pf = new PositionListFac();
        
        public ActionResult VisPosition()
        {
            
            return View(pf.GetAll("ID","DESC",8));
        }
    }
}