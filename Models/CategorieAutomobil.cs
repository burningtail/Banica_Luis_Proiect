namespace Banica_Luis_Proiect.Models
{
    public class CategorieAutomobil
    {
        public int Id { get; set; }
        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
