using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment5_Voglewede_Woods.Data;
using Assignment5_Voglewede_Woods.Models;

namespace Assignment5_Voglewede_Woods.Controllers
{
    public class Music_InventoryController : Controller
    {
        private readonly Assignment5_Voglewede_WoodsContext _context;

        public Music_InventoryController(Assignment5_Voglewede_WoodsContext context)
        {
            _context = context;
        }

       
        // GET: Music_Inventory
        public async Task<IActionResult> Index(string musicGenre, string musicPerformer, string searchString)
        {
            if (_context.Music_Inventory == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Music_Inventory
                                            orderby m.Genre
                                            select m.Genre;
            var music = from m in _context.Music_Inventory
                         select m;

            // Use LINQ to get list of performers.
            IQueryable<string> performerQuery = from n in _context.Music_Inventory
                                            orderby n.Performer
                                            select n.Performer;
            var songs = from n in _context.Music_Inventory
                        select n;

           
            if (!string.IsNullOrEmpty(musicGenre))
            {
                music = music.Where(x => x.Genre == musicGenre);
            }

            if (!string.IsNullOrEmpty(musicPerformer))
            {
                music = music.Where(x => x.Performer == musicPerformer);
            }

            var musicGenreVM = new GenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Performers = new SelectList(await performerQuery.Distinct().ToListAsync()),
                Music = await music.ToListAsync()
            };

            return View(musicGenreVM);
        }



        // GET: Music_Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Music_Inventory == null)
            {
                return NotFound();
            }

            var music_Inventory = await _context.Music_Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music_Inventory == null)
            {
                return NotFound();
            }

            return View(music_Inventory);
        }

        // GET: Music_Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Music_Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlbumName,Genre,Performer,Price,Type,Year")] Music_Inventory music_Inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music_Inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminTools));
            }
            return View(music_Inventory);
        }

        // GET: Music_Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Music_Inventory == null)
            {
                return NotFound();
            }

            var music_Inventory = await _context.Music_Inventory.FindAsync(id);
            if (music_Inventory == null)
            {
                return NotFound();
            }
            return View(music_Inventory);
        }

        // POST: Music_Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlbumName,Genre,Performer,Price,Type,Year")] Music_Inventory music_Inventory)
        {
            if (id != music_Inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music_Inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Music_InventoryExists(music_Inventory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdminTools));
            }
            return View(music_Inventory);
        }

        // GET: Music_Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Music_Inventory == null)
            {
                return NotFound();
            }

            var music_Inventory = await _context.Music_Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music_Inventory == null)
            {
                return NotFound();
            }

            return View(music_Inventory);
        }

        // POST: Music_Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Music_Inventory == null)
            {
                return Problem("Entity set 'Assignment5_Voglewede_WoodsContext.Music_Inventory'  is null.");
            }
            var music_Inventory = await _context.Music_Inventory.FindAsync(id);
            if (music_Inventory != null)
            {
                _context.Music_Inventory.Remove(music_Inventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminTools));
        }

        private bool Music_InventoryExists(int id)
        {
            return (_context.Music_Inventory?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public ActionResult Admin()
        {
            return View(Admin);
        }

        public async Task<IActionResult> AdminTools()
        {
            return _context.Music_Inventory != null ?
                        View(await _context.Music_Inventory.ToListAsync()) :
                        Problem("Entity set 'Assignment5_Voglewede_WoodsContext.Music_Inventory'  is null.");
            
        }
    }
}
