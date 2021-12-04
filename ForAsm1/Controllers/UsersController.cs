using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForAsm1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult MyTeam()
        {
            return View();
        }
        public ActionResult InformationUpdate()
        {
            return View();
        }
    }
}