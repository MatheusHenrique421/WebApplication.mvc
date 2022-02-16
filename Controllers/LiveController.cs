using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication.mvc.Data;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication.mvc.Controllers
{
    public class LiveController : Controller
    {
        private readonly ContextBase _context;

        public LiveController(ContextBase context)
        {
            _context = context;
        }

        // GET: Live
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.Live.Include(l => l.Instrutor);
            return View(await contextBase.ToListAsync());
        }

        // GET: Live/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: Live/Create
        public IActionResult Create()
        {
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id");
            return View();
        }

        // POST: Live/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,InstrutorId,HoraInicio,DuracaoMin,ValorInscricao")] Live live)
        {
            if (ModelState.IsValid)
            {
                _context.Add(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // GET: Live/Edit/5
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
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // POST: Live/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,InstrutorId,HoraInicio,DuracaoMin,ValorInscricao")] Live live)
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
            ViewData["InstrutorId"] = new SelectList(_context.Instrutor, "Id", "Id", live.InstrutorId);
            return View(live);
        }

        // GET: Live/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Live
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // POST: Live/Delete/5
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
