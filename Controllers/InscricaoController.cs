using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication.mvc.Data;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication.mvc.Controllers
{
	public class InscricaoController : Controller
	{
		private readonly ContextBase _context;

		public InscricaoController(ContextBase context)
		{
			_context = context;
		}

		// GET: Inscricao
		public async Task<IActionResult> Index()
		{
			var contextBase = _context.Inscricoes.Include(i => i.Inscrito).Include(i => i.Live);
			return View(await contextBase.ToListAsync());
		}

		// GET: Inscricao/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inscricao = await _context.Inscricoes
					.Include(i => i.Inscrito)
					.Include(i => i.Live)
					.FirstOrDefaultAsync(m => m.Id == id);
			if (inscricao == null)
			{
				return NotFound();
			}

			return View(inscricao);
		}

		// GET: Inscricao/Create
		public IActionResult Create()
		{
			ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id");
			ViewData["LiveId"] = new SelectList(_context.Live, "Id", "Id");
			return View();
		}

		// POST: Inscricao/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,LiveId,InscritoId,ValorInscricao,DataVencimento,StatusPagamento")] Inscricao inscricao)
		{
			if (ModelState.IsValid)
			{
				_context.Add(inscricao);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id", inscricao.InscritoId);
			ViewData["LiveId"] = new SelectList(_context.Live, "Id", "Id", inscricao.LiveId);
			return View(inscricao);
		}

		// GET: Inscricao/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inscricao = await _context.Inscricoes.FindAsync(id);
			if (inscricao == null)
			{
				return NotFound();
			}
			ViewData["InscritoId"] = new SelectList(_context.Inscrito, "Id", "Id", inscricao.InscritoId);
			ViewData["LiveId"] = new SelectList(_context.Live, "Id", "Id", inscricao.LiveId);
			ViewData["LiveValorInscricao"] = new SelectList(_context.Live, "Id", "Id", inscricao.ValorInscricao);
			return View(inscricao);
		}

		// POST: Inscricao/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,LiveId,InscritoId,ValorInscricao,DataVencimento,StatusPagamento")] Inscricao inscricao)
		{
			if (id != inscricao.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(inscricao);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!InscricaoExists(inscricao.Id))
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
			ViewData["InscritoNome"] = new SelectList(_context.Inscrito, "Id", "Id", inscricao.Inscritos);
			ViewData["LiveValorInscricao"] = new SelectList(_context.Live, "Id", "Id", inscricao.ValorInscricao);
			ViewData["LiveId"] = new SelectList(_context.Live, "Id", "Id", inscricao.LiveId);
			return View(inscricao);
		}

		// GET: Inscricao/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inscricao = await _context.Inscricoes
					.Include(i => i.Inscrito)
					.Include(i => i.Live)
					.FirstOrDefaultAsync(m => m.Id == id);
			if (inscricao == null)
			{
				return NotFound();
			}

			return View(inscricao);
		}

		// POST: Inscricao/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var inscricao = await _context.Inscricoes.FindAsync(id);
			_context.Inscricoes.Remove(inscricao);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool InscricaoExists(int id)
		{
			return _context.Inscricoes.Any(e => e.Id == id);
		}
	}
}
