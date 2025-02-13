using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptSocietyCO.Data;
using ScriptSocietyCO.Models;

namespace ScriptSocietyCO.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly ScriptSocietyCOContext _context;

        public ScriptsController(ScriptSocietyCOContext context)
        {
            _context = context;
        }

        // GET: Scripts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Script.ToListAsync());
        }

        // GET: Scripts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var script = await _context.Script
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (script == null)
            {
                return NotFound();
            }

            return View(script);
        }

        // GET: Scripts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Type,Color,Price,Size,StockTotal")] Script script)
        {
            if (ModelState.IsValid)
            {
                _context.Add(script);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(script);
        }

        // GET: Scripts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var script = await _context.Script.FindAsync(id);
            if (script == null)
            {
                return NotFound();
            }
            return View(script);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Type,Color,Price,Size,StockTotal")] Script script)
        {
            if (id != script.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(script);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScriptExists(script.ProductId))
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
            return View(script);
        }

        // GET: Scripts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var script = await _context.Script
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (script == null)
            {
                return NotFound();
            }

            return View(script);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var script = await _context.Script.FindAsync(id);
            if (script != null)
            {
                _context.Script.Remove(script);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScriptExists(int id)
        {
            return _context.Script.Any(e => e.ProductId == id);
        }



    }
}
