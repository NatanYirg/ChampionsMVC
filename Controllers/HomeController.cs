using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheChampions.Models;
using TheChampions.Repository;

namespace TheChampions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustReachContext _context;
        private readonly ICamp _icamp;

        public HomeController(ILogger<HomeController> logger, CustReachContext context, ICamp icamp)
        {
            _logger = logger;
            _context = context;
            _icamp = icamp;
        }

        public IActionResult Index(CustomerReach cr)
        {
            return View(cr);
        }

        public ViewResult ContactUs() 
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(CustomerReach cr) 
        {
             _context.CustomerReach.Add(cr);
            await _context.SaveChangesAsync();
            return View();
        }

        public ViewResult CustMessage()
        {
            List<CustomerReach> r = _icamp.custMessages();
            return View(r);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}