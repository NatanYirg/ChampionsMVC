using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheChampions.Models;
using TheChampions.Repository;

namespace TheChampions.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICamp icamp;
        private readonly CampContext _context;

        public TransactionController(CampContext context, ICamp icamp)
        {
            _context = context;
            this.icamp = icamp;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
              return _context.transactions != null ? 
                          View(await _context.transactions.ToListAsync()) :
                          Problem("Entity set 'CampContext.transactions'  is null.");
        }

        // GET: Transaction/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.transactions
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        // GET: Transaction/CreateOrEdit
        //public IActionResult CreateOrEdit()
        //{
        //    return View(new Transaction());
        //}

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateOrEdit([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SwiftCode,amount,Date")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        transaction.Date = DateTime.Now;
        //        _context.Add(transaction);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transaction);
        //}


        public IActionResult CreateOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Transaction());
            else
                return View(_context.transactions.Find(id));
        }


        [HttpPost]
        public IActionResult CreateOrEdit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.TransactionId == 0)
                {
                    transaction.Date = DateTime.Now;
                    icamp.createTransaction(transaction);
                }
            }
            Transaction t = icamp.UpdateTransaction(transaction); 
            return RedirectToAction("Index");
        }

        

        // GET: Transaction/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.transactions.FindAsync(id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(transaction);
        //}

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SwiftCode,amount,Date")] Transaction transaction)
        //{
        //    if (id != transaction.TransactionId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(transaction);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TransactionExists(transaction.TransactionId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transaction);
        //}

        // GET: Transaction/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.transactions
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transactions == null)
            {
                return Problem("Entity set 'CampContext.transactions'  is null.");
            }
            var transaction = await _context.transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
