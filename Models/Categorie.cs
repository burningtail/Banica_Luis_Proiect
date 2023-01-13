using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Banica_Luis_Proiect.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Display(Name = "Nume categorie")]
        public string NumeCategorie { get; set; }
        public ICollection<CategorieAutomobil>? CategoriiAutomobil { get; set; }
    }
}

