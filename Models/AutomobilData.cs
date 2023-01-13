namespace Banica_Luis_Proiect.Models
{
    public class AutomobilData
    {
        public IEnumerable<Automobil> Automobile { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieAutomobil> CategoriiAutomobil { get; set; }

    }
}
