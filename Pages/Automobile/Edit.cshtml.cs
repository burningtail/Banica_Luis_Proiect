using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banica_Luis_Proiect.Data;
using Banica_Luis_Proiect.Models;

namespace Banica_Luis_Proiect.Pages.Automobile
{
    public class EditModel : AutoCategoriesPageModel

    {
        private readonly Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext _context;

        public EditModel(Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Automobil Automobil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Automobil == null)
            {
                return NotFound();
            }

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            Automobil = await _context.Automobil
                .Include(b => b.CategoriiAutomobil).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning restore CS8601 // Possible null reference assignment.

            var automobil = await _context.Automobil.FirstOrDefaultAsync(m => m.Id == id);

            if (automobil == null)
            {
                return NotFound();
            }


            PopulateAssignedCategoryData(_context, Automobil);


            Automobil = automobil;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var autoToUpdate = await _context.Automobil
            .Include(i => i.CategoriiAutomobil)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.Id == id);
            if (autoToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Automobil>(
            autoToUpdate,
            "Automobil",
            i => i.Nume, i => i.Client,
            i => i.Pret, i => i.DataInchirierii))
                
            {
                UpdateAutoCategories(_context, selectedCategories, autoToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateAutoCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateAutoCategories(_context, selectedCategories, autoToUpdate);
            PopulateAssignedCategoryData(_context, autoToUpdate);
            return Page();
        }
    }

}

