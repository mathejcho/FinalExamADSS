using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalExamADSS.Data;
using FinalExamADSS.Models;

namespace FinalExamADSS.Controllers
{
    public class ClientCarsController : Controller
    {
        private readonly DataContext _context;

        public ClientCarsController(DataContext context)
        {
            _context = context;
        }

        // GET: ClientCars
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ClientCars.Include(c => c.Car).Include(c => c.Client);
            return View(await dataContext.ToListAsync());
        }

        // GET: ClientCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCars = await _context.ClientCars
                .Include(c => c.Car)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientCars == null)
            {
                return NotFound();
            }

            return View(clientCars);
        }

        // GET: ClientCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Manufacturer");
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            return View();
        }

        // POST: ClientCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,CarId")] ClientCars clientCars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Manufacturer", clientCars.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", clientCars.ClientId);
            return View(clientCars);
        }

        // GET: ClientCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCars = await _context.ClientCars.FindAsync(id);
            if (clientCars == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Manufacturer", clientCars.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", clientCars.ClientId);
            return View(clientCars);
        }

        // POST: ClientCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,CarId")] ClientCars clientCars)
        {
            if (id != clientCars.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCarsExists(clientCars.ClientId))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Manufacturer", clientCars.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", clientCars.ClientId);
            return View(clientCars);
        }

        // GET: ClientCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCars = await _context.ClientCars
                .Include(c => c.Car)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientCars == null)
            {
                return NotFound();
            }

            return View(clientCars);
        }

        // POST: ClientCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientCars = await _context.ClientCars.FindAsync(id);
            _context.ClientCars.Remove(clientCars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientCarsExists(int id)
        {
            return _context.ClientCars.Any(e => e.ClientId == id);
        }
    }
}
