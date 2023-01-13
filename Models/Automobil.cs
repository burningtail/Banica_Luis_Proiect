using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Banica_Luis_Proiect.Models
{
    public class Automobil
    {
        public int Id { get; set; }

        [Display(Name = "Marca si Modelul")]
        public string? Nume { get; set; }
        public string? Client { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Data inchirierii")]
        [DataType(DataType.Date)]
        public DateTime DataInchirierii { get; set; }

        public ICollection<CategorieAutomobil> CategoriiAutomobil { get; set; }

    }
}
