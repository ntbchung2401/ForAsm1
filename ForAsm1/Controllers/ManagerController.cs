using ForAsm1.MainRole;
using ForAsm1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ForAsm1.Controllers
{
    [Authorize(Roles = Role.Manager)]
    public class ManagerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }

        public ManagerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = new ApplicationDbContext();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        // GET: Manager
        public ActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeacher(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, Role.Teacher);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateClass()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateClass(Classes model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var cl = new Classes { Name = model.Name };
            try
            {
                _context.Classes.Add(cl);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("duplicate", "This class is already existed");
                return View(model);
            }
            return RedirectToAction("CreateClass");
        }
        public ActionResult RemoveTeacher()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ShowTeacherInfor()
        {
            var role = _context.Roles
        .SingleOrDefault(r => r.Name.Equals(Role.Teacher));
            var users = _context.Users
              .Where(m => m.Roles.Any(r => r.RoleId.Equals(role.Id)))
              .ToList();
            return View("ShowInfor", users);
        }
        public ActionResult ShowStudentInfor()
        {
            var role = _context.Roles
        .SingleOrDefault(r => r.Name.Equals(Role.Student));
            var users = _context.Users
              .Where(m => m.Roles.Any(r => r.RoleId.Equals(role.Id)))
              .ToList();
            return View("ShowInfor", users);
        }
        public ActionResult ShowClass()
        {
            return View();
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}