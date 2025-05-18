using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalPortal.Data;

namespace MedicalPortal.Models
{
    public class MedicalServicesController : Controller
    {
        private readonly MedicalPortalContext _context;

        public MedicalServicesController(MedicalPortalContext context)
        {
            _context = context;
        }

        // GET: MedicalServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalServices.ToListAsync());
        }

        // GET: MedicalServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalService == null)
            {
                return NotFound();
            }

            return View(medicalService);
        }

        // GET: MedicalServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] MedicalService medicalService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalService);
        }

        // GET: MedicalServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices.FindAsync(id);
            if (medicalService == null)
            {
                return NotFound();
            }
            return View(medicalService);
        }

        // POST: MedicalServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] MedicalService medicalService)
        {
            if (id != medicalService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalServiceExists(medicalService.Id))
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
            return View(medicalService);
        }

        // GET: MedicalServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalService == null)
            {
                return NotFound();
            }

            return View(medicalService);
        }

        // POST: MedicalServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalService = await _context.MedicalServices.FindAsync(id);
            if (medicalService != null)
            {
                _context.MedicalServices.Remove(medicalService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalServiceExists(int id)
        {
            return _context.MedicalServices.Any(e => e.Id == id);
        }
    }
}
