using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using WorkApplication1.MVC;

namespace WorkApplication1.MVC.Views
{
    public class ContactEmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public ContactEmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContactEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactEmployee.ToListAsync());
        }

        // GET: ContactEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmployee = await _context.ContactEmployee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (contactEmployee == null)
            {
                return NotFound();
            }

            return View(contactEmployee);
        }

        // GET: ContactEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeType,EmployeeAddress,EmployeeDate")] ContactEmployee contactEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactEmployee);
        }

        // GET: ContactEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmployee = await _context.ContactEmployee.FindAsync(id);
            if (contactEmployee == null)
            {
                return NotFound();
            }
            return View(contactEmployee);
        }

        // POST: ContactEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeType,EmployeeAddress,EmployeeDate")] ContactEmployee contactEmployee)
        {
            if (id != contactEmployee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactEmployeeExists(contactEmployee.EmployeeId))
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
            return View(contactEmployee);
        }

        // GET: ContactEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmployee = await _context.ContactEmployee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (contactEmployee == null)
            {
                return NotFound();
            }

            return View(contactEmployee);
        }

        // POST: ContactEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactEmployee = await _context.ContactEmployee.FindAsync(id);
            _context.ContactEmployee.Remove(contactEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactEmployeeExists(int id)
        {
            return _context.ContactEmployee.Any(e => e.EmployeeId == id);
        }
    }
}
