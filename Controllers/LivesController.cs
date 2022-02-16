using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.mvc.Data;
using WebApplication.mvc.Models;

namespace WebApplication.mvc.Controllers
{
    public class LivesController : Controller
    {
        private readonly ContextBase _context;

        public LivesController(ContextBase context)
        {
            _context = context;
        }

        // GET: Lives
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.Live.Include(l => l.Inscrito).Include(l => l.Instrutor);
            return View(await contextBase.ToListAsync());
        }

        // GET: Lives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .Include(l => l.Inscrito)
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: Lives/Create
        public IActionResult Create()
        {
            ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id");
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id");
            return View();
        }

        // POST: Lives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,InstrutorId,InscritoId,HoraInicio,DuracaoMin,ValorInscricao")] Live live)
        {
            if (ModelState.IsValid)
            {
                _context.Add(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id", live.InscritoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // GET: Lives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live.FindAsync(id);
            if (live == null)
            {
                return NotFound();
            }
            ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id", live.InscritoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // POST: Lives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,InstrutorId,InscritoId,HoraInicio,DuracaoMin,ValorInscricao")] Live live)
        {
            if (id != live.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(live);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiveExists(live.Id))
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
            ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id", live.InscritoId);
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // GET: Lives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .Include(l => l.Inscrito)
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // POST: Lives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var live = await _context.Live.FindAsync(id);
            _context.Live.Remove(live);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiveExists(int id)
        {
            return _context.Live.Any(e => e.Id == id);
        }
    }
}
