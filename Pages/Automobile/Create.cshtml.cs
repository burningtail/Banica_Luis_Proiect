using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Banica_Luis_Proiect.Data;
using Banica_Luis_Proiect.Models;

namespace Banica_Luis_Proiect.Pages.Automobile
{
    public class CreateModel : AutoCategoriesPageModel
    {
        private readonly Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext _context;

        public CreateModel(Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext context) => _context = context;

        public IActionResult OnGet()
        {

            var automobil = new Automobil();
            automobil.CategoriiAutomobil = new List<CategorieAutomobil>();
            PopulateAssignedCategoryData(_context, automobil);

            return Page();
        }

        [BindProperty]
        public Automobil Automobil { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAutomobil = new Automobil();
            if (selectedCategories != null)
            {
                newAutomobil.CategoriiAutomobil = new List<CategorieAutomobil>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieAutomobil
                    {
                        CategorieId = int.Parse(cat)
                    };
                    newAutomobil.CategoriiAutomobil.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Automobil>(
            newAutomobil,
            "Automobil",
            i => i.Nume, i => i.Client,
            i => i.Pret, i => i.DataInchirierii))
            {
                _context.Automobil.Add(newAutomobil);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newAutomobil);
            return Page();
        }
    }
}

//    public async Task<IActionResult> OnPostAsync()
//        {
//          if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Automobil.Add(Automobil);
//            await _context.SaveChangesAsync();

//            return RedirectToPage("./Index");
//        }
//    }
//}
