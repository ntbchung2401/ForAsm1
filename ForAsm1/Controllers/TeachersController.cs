using ForAsm1.MainRole;
using ForAsm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForAsm1.Controllers
{
    [Authorize(Roles = Role.Teacher)]
    public class TeachersController : Controller
    {
        private ApplicationDbContext _context;
        public TeachersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Teachers
        public ActionResult TakeAttendance()
        {
            return View();
        }
        public ActionResult ShowClassStudent()
        {
            return View();
        }
        public ActionResult CreateTeam()
        {
            return View();
        }
        public ActionResult AddUserTeam()
        {
            return View();
        }
        public ActionResult RemoveUserTeam()
        {
            return View();
        }

    }
}