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
    public class IndexModel : PageModel
    {
        private readonly Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext _context;

        public IndexModel(Banica_Luis_Proiect.Data.Banica_Luis_ProiectContext context)
        {
            _context = context;
        }

        public IList<Automobil> Automobil { get; set; } = default!;


        public AutomobilData AutomobilD { get; set; }
        public int AutomobilId { get; set; }
        public int CategorieId { get; set; }
        public async Task OnGetAsync(int? id, int categorieId)
        {
            AutomobilD = new AutomobilData();

            AutomobilD.Automobile = await _context.Automobil
            .Include(b => b.CategoriiAutomobil)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                AutomobilId = id.Value;
                Automobil automobil = AutomobilD.Automobile
                .Where(i => i.Id == id.Value).Single();
                AutomobilD.Categorii = automobil.CategoriiAutomobil.Select(s => s.Categorie);
            }
        }

                //public async Task OnGetAsync()
                //{
                //    if (_context.Automobil != null)
                //    {
                //        Automobil = await _context.Automobil.ToListAsync();
                //    }
                //}
            
        



    }

}
