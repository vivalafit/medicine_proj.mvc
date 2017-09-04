using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using med_projec_roles_added.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;

namespace med_projec_roles_added.Controllers
{
    public class DoctorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
     
      
        public ActionResult Index()
        {
            var allusers = db.Users.ToList();
            ViewBag.Pacient = "Pacient";
            var users = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("eabe1e81-8dd2-4182-b70f-b78673847906")).ToList();
            var userVM = users.Select(user => new UserViewModel { Username = user.Email, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();
            var admins = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("df265882-060a-45a9-a3db-bd19622b8826")).ToList();
            var adminsVM = admins.Select(user => new UserViewModel { Username = user.Email, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();
            var model = new GroupedUserViewModel { Pacient = userVM, Doctor = adminsVM };
            //
           
            //
            ViewBag.Pacients = new SelectList(users.ToList(), "Email", "Email");
            //
            return View(model);
        }
        //  Doctor/EditPacientInfo/test_pacient@gmail.com
        [Route("Doctor/EditPacientInfo/{name}")]
        public ActionResult EditPacientInfo(string name)
        {
            string username = name;
            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            ViewBag.Email = user.Email;
            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser()
            {
                Email = user.Email,
                PacientInfo = user.PacientInfo
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPacientInfo(ApplicationUser pacient)
        {
            if (ModelState.IsValid)
            {
                string username = pacient.Email;
                // Get the userprofile
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                // Update fields
                user.Email = pacient.Email;
                user.PacientInfo = pacient.PacientInfo;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index"); // or whatever
            }

            return View(pacient);
        }
        [HttpPost]
        public ActionResult PacientSearch(string name)
        {
            var all_pacients = db.Users.Where(a => a.Email.Contains(name)).ToList();
            return PartialView(all_pacients);
        }
        [Route("Doctor/Details/{name}")]
        public ActionResult Details(string name)
        {
            string username = name;
            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            ViewBag.Email = user.Email;
            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser()
            {
                Email = user.Email,
                PacientInfo = user.PacientInfo
            };
            return View(model);
          
        }
    }
}