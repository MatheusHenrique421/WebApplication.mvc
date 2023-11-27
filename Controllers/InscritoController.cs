using Microsoft.EntityFrameworkCore;
using WebApplication.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication.mvc.Data;
using System.Threading.Tasks;
using System.Linq;
namespace WebApplication.mvc.Controllers
{
    public class InscritoController : Controller
    {
        private readonly ContextBase _context;

        public InscritoController(ContextBase context)
        {
            _context = context;
        }

        // GET: Inscrito
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscrito.ToListAsync());
        }

        // GET: Inscrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito
                .FirstOrDefaultAsync(m => m.InscritoID == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // GET: Inscrito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inscrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscritoID,Nome,Email,EnderecoInstagram,DataNascimento")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscrito);
        }

        // GET: Inscrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito.FindAsync(id);
            if (inscrito == null)
            {
                return NotFound();
            }
            return View(inscrito);
        }

        // POST: Inscrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscritoID,Nome,Email,EnderecoInstagram,DataNascimento")] Inscrito inscrito)
        {
            if (id != inscrito.InscritoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritoExists(inscrito.InscritoID))
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
            return View(inscrito);
        }

        // GET: Inscrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito
                .FirstOrDefaultAsync(m => m.InscritoID  == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // POST: Inscrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscrito = await _context.Inscrito.FindAsync(id);
            _context.Inscrito.Remove(inscrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritoExists(int id)
        {
            return _context.Inscrito.Any(e => e.InscritoID == id);
        }
    }
}
