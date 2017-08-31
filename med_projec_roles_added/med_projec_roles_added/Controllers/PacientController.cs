using med_projec_roles_added.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace med_projec_roles_added.Controllers
{
    public class PacientController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Pacient
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            ViewBag.PacientInfo = user.PacientInfo;
            return View();
        }
    }
}