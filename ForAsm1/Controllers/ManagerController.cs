using ForAsm1.MainRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForAsm1.Controllers
{
    [Authorize(Roles = Role.Manager)]
    public class ManagerController : Controller
    {
        // GET: Admin
        public ActionResult CreateTeacher()
        {
            return View();
        }
        public ActionResult RemoveTeacher()
        {
            return View();
        }
        public ActionResult ShowClass()
        {
            return View();
        }

    }
}