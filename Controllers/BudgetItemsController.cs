using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetCalculator.Data;
using BudgetCalculator.Models;

namespace BudgetCalculator.Controllers
{
    public class BudgetItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BudgetItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BudgetItems.Include(b => b.Budgets);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BudgetItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItems = await _context.BudgetItems
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(m => m.BudgetItemsId == id);
            if (budgetItems == null)
            {
                return NotFound();
            }

            return View(budgetItems);
        }

        // GET: BudgetItems/Create
        public IActionResult Create()
        {
            ViewData["BudgetId"] = new SelectList(_context.Budget, "BudgetId", "BudgetId");
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetItemsId,ItemName,ItemPrice,BudgetId")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetId"] = new SelectList(_context.Budget, "BudgetId", "BudgetId", budgetItems.BudgetId);
            return View(budgetItems);
        }

        // GET: BudgetItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItems = await _context.BudgetItems.FindAsync(id);
            if (budgetItems == null)
            {
                return NotFound();
            }
            ViewData["BudgetId"] = new SelectList(_context.Budget, "BudgetId", "BudgetId", budgetItems.BudgetId);
            return View(budgetItems);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BudgetItemsId,ItemName,ItemPrice,BudgetId")] BudgetItems budgetItems)
        {
            if (id != budgetItems.BudgetItemsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetItemsExists(budgetItems.BudgetItemsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetId"] = new SelectList(_context.Budget, "BudgetId", "BudgetId", budgetItems.BudgetId);
            return View(budgetItems);
        }

        // GET: BudgetItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItems = await _context.BudgetItems
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(m => m.BudgetItemsId == id);
            if (budgetItems == null)
            {
                return NotFound();
            }

            return View(budgetItems);
        }

        // POST: BudgetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetItems = await _context.BudgetItems.FindAsync(id);
            _context.BudgetItems.Remove(budgetItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetItemsExists(int id)
        {
            return _context.BudgetItems.Any(e => e.BudgetItemsId == id);
        }
    }
}
