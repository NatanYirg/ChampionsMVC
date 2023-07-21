using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChampions.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheChampions.Repository;

namespace TheChampions.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ICamp icamp;
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private readonly CampContext _context;

        public ActivityController(ICamp icamp, IWebHostEnvironment iwebHostEnvironment, CampContext context)
        {
            this.icamp = icamp;
            this.iwebHostEnvironment = iwebHostEnvironment;
            _context = context;

        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getActivityById(int id)
        {
            Activity a = icamp.GetActivitybyid(id);
            return View();
        }

        public ViewResult ListActivity()
        {
            List<Activity> a = icamp.getAllActivity();
            return View(a);
        }
        // GET: ActivityController/Create
        public ViewResult CreateActivity()
        {
            return View();
        }

        // POST: ActivityController/Create
        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            Activity a = icamp.AddActivity(activity);
            return RedirectToAction("CreateActivity");
        }



        // GET: ActivityController/Edit/5
        public ActionResult Edit(int id)
        {
            Activity a = icamp.GetActivitybyid(id);
            return View(a);
        }

        // POST: ActivityController/Edit/5
        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            
            Activity a = icamp.UpdateActivity(activity);
            return RedirectToAction("ListActivity");
        }

        // GET: ActivityController/Delete/5
        public ActionResult Delete(int id)
        {
            Activity a = icamp.DeleteActivity(id);
            return RedirectToAction("ListActivity");
        }


    }
}
