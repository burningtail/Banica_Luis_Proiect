using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Banica_Luis_Proiect.Models;

namespace Banica_Luis_Proiect.Data
{
    public class Banica_Luis_ProiectContext : DbContext
    {
        public Banica_Luis_ProiectContext (DbContextOptions<Banica_Luis_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Banica_Luis_Proiect.Models.Automobil> Automobil { get; set; } = default!;

        public DbSet<Banica_Luis_Proiect.Models.Categorie> Categorie { get; set; }
    }
}
