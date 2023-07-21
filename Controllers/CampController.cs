using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChampions.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheChampions.Repository;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using System.Xml.Linq;

namespace TheChampions.Controllers
{
    public class CampController : Controller
    {
        private readonly ICamp icamp;
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private readonly CampContext _context;
        private IHtmlLocalizer<CampController> _localizer;

        public CampController(ICamp icamp, IWebHostEnvironment iwebHostEnvironment, CampContext context, IHtmlLocalizer<CampController> localizer)
        {
            this.icamp = icamp;
            this.iwebHostEnvironment = iwebHostEnvironment;
            _context = context;
            _localizer = localizer;

        }



        public ActionResult Index()
        {

            return View();
        }

        public ViewResult SeeMore()
        {
            return View();
        }
        public ViewResult WaterDay()
        {
            return View();
        }
        public ViewResult Buhe()
        {
            return View();
        }


        public ViewResult ListRegistrants()
        {
            ViewBag.Title = "All Registrants";
            List<Registration> r = icamp.getAllRegistrant();
            return View(r);
        }


        public ViewResult getRegistrantbyid(int id)
        {
            Registration r = icamp.getRegistrantbyid(id);
            return View(r);
        }



        [HttpGet]
        public ViewResult Register()
        {
            var selectactivity = _context.activities.ToList();
            ViewBag.ActivityList = new SelectList(selectactivity, "activityid", "activityname");

            //HttpContext.Session.SetString("Fee", Model.Fee);


            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            var selectactivity = _context.activities.ToList();
            ViewBag.ActivityList = new SelectList(selectactivity, "activityid", "activityname");


            if (registration.studentImage != null)
            {
                string imgPath = "Registration/Image/" + Guid.NewGuid().ToString() + "_" + registration.studentImage.FileName;
                string serverPath = Path.Combine(iwebHostEnvironment.WebRootPath, imgPath);
                registration.studentImage.CopyTo(new FileStream(serverPath, FileMode.Create));
                registration.imagePath = imgPath;
            }


            


            Registration r = icamp.AddRegisteree(registration);
            return RedirectToAction("Index" ,"Home");
        }


        




        // GET: CampController/Edit/5
        public ViewResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Registration r = icamp.getRegistrantbyid(id);
            return View(r);
        }

        // POST: CampController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            {
                if (registration.studentImage != null)
                {
                    string imgPath = "Registration/Image/" + Guid.NewGuid().ToString() + "_" + registration.studentImage.FileName;
                    string serverPath = Path.Combine(iwebHostEnvironment.WebRootPath, imgPath);
                    registration.studentImage.CopyTo(new FileStream(serverPath, FileMode.Create));
                    registration.imagePath = imgPath;
                }

                Registration s = icamp.UpdateRegisteree(registration);
                return RedirectToAction("index");
            }
        }

        // GET: CampController/Delete/5
        public ActionResult Delete(int id)
        {
            Registration s = icamp.DeleteRegisteree(id);
            return RedirectToAction("ListRegistrants");

        }


        private string UploadImage(IFormFile file)
        {
            string imgPath = "Registration/Image/" + Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverPath = Path.Combine(iwebHostEnvironment.WebRootPath, imgPath);
            file.CopyTo(new FileStream(serverPath, FileMode.Create));
            return "/" + imgPath;
        }


        [HttpPost]
        public IActionResult CultureManagment(string culture, string returnUrl) 
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue (new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Search(string term)
        {
            if (term == null)
            {
                return View("Index");
            }
            List<Registration> searchResult = icamp.Search(term);
            return View(searchResult);
        }
    }
}


//ViewData["CurrentFilter"] = Name;
//var studs = from s in _context.registrations
//            select s;
//if (!String.IsNullOrEmpty(Name))
//{
//    studs = studs.Where(s => s.FirstName.Contains(Name));
//}
//return View(studs);