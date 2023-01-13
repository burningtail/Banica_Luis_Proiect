using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Banica_Luis_Proiect.Data;
using Banica_Luis_Proiect.Models;

namespace Banica_Luis_Proiect.Pages.Automobile
{
    public class DeleteModel : PageModel
    {
        private readonly Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext _context;

        public DeleteModel(Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Automobil Automobil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Automobil == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil.FirstOrDefaultAsync(m => m.Id == id);

            if (automobil == null)
            {
                return NotFound();
            }
            else 
            {
                Automobil = automobil;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Automobil == null)
            {
                return NotFound();
            }
            var automobil = await _context.Automobil.FindAsync(id);

            if (automobil != null)
            {
                Automobil = automobil;
                _context.Automobil.Remove(Automobil);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
