using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ChapaNET;
using System;
using System.Security.Claims;
using TheChampions.Models;
using TheChampions.Models.DTO;
using TheChampions.Models.View_Model;
using Microsoft.EntityFrameworkCore;
using TheChampions.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TheChampions.Controllers
{   
    public class PaymentController : Controller
    {
        Chapa chapa = new Chapa("CHAPUBK_TEST-7U6zZTWevEXPcim8LK2mgvX7Rkarz4QQ");

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PaymentContext _paymentContext;
        private readonly CampContext _campContext;


        public PaymentController(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, PaymentContext paymentContext,
                                     CampContext campContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _paymentContext = paymentContext;
            _campContext = campContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("GetChapaListBank")]
        [HttpGet]
        public async Task<List<string>> GetChapaListBank()
        {
            var id = Chapa.GetUniqueRef();
            var banks = await chapa.GetBanksAsync();
            string retb = string.Join(',', banks.AsEnumerable());
            List<string> bankList = retb.Split(',').ToList();

            return bankList;
        }

        [Route("ChapaPay")]
        [HttpPost]
        public async Task<string> ChapaPay([FromBody] PaymentViewModel puser)
        {
            var Request = new ChapaRequest(
                 amount: (double)puser.Amount,
                 email: puser.Email,
                 firstName: puser.First_Name,
                 lastName: puser.Last_Name,
                 tx_ref: puser.tx_ref,
                 callback_url: "http://localhost:3000/chapa"
                );
            var Result = await chapa.RequestAsync(Request);
            var isValid = await chapa.VerifyAsync(puser.tx_ref);
            if (Result.Status == "success")
            {
                var dbPrem = new PaymentViewModel
                {
                    tx_ref = puser.tx_ref,
                    Email = puser.Email,
                    First_Name = puser.First_Name,
                    Last_Name = puser.Last_Name,
                    Amount = puser.Amount
                    //isPaid = true
                };
                await _paymentContext.PaidCustomer.AddAsync(dbPrem);
                _paymentContext.SaveChanges();
                return Result.CheckoutUrl;
            }
            return Result.Message;
        }



        public IActionResult Payment(PaymentViewModel pay)
        {
            
            int randomNumber = new Random().Next(100000, 999999); // Generate random six-digit number for our chapa tx_ref
            string tx_ref = pay.First_Name + randomNumber;
            ViewBag.RandomNum = tx_ref;


           
            //ViewBag.Amount = fee;

            return View(pay);
        }

        //[HttpPost]
        //public async Task<IActionResult> Paymentt(decimal totalFee) 
        //{
        //    decimal total = totalFee;

        //    PaymentViewModel payment = null;


        //    string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    ApplicationUser user = await _userManager.FindByIdAsync(userId);

        //    int randomNumber = new Random().Next(100000, 999999); // Generate random six-digit number for our chapa tx_ref
        //    string tx_ref = user.FirstName + randomNumber;



        //    payment = new PaymentViewModel
        //    {
        //        Name = user.Name,
        //        Email = user.Email,
        //        Amount = total,
        //        tx_ref = tx_ref

        //    };

        //    return RedirectToAction("Payment", payment);
        //}
    }
}


