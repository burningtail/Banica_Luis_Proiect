using Banica_Luis_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Banica_Luis_Proiect.Models
{
    public class AutoCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData>? AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Banica_Luis_ProiectContext context,
        Automobil automobil)
        {
            var allCategories = context.Categorie;
            var categoriiAutomobil = new HashSet<int>(
            automobil.CategoriiAutomobil.Select(c => c.CategorieId)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieId = cat.Id,
                    Nume = cat.NumeCategorie,
                    Assigned = categoriiAutomobil.Contains(cat.Id)
                });
            }
        }
        public void UpdateAutoCategories(Banica_Luis_ProiectContext context,
        string[] selectedCategories, Automobil autoToUpdate)
        {
            if (selectedCategories == null)
            {
                autoToUpdate.CategoriiAutomobil = new List<CategorieAutomobil>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiAutomobil = new HashSet<int>
            (autoToUpdate.CategoriiAutomobil.Select(c => c.Categorie.Id));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.Id.ToString()))
                {
                    if (!categoriiAutomobil.Contains(cat.Id))
                    {
                        autoToUpdate.CategoriiAutomobil.Add(
                        new CategorieAutomobil
                        {
                            AutomobilId = autoToUpdate.Id,
                            CategorieId = cat.Id
                        });
                    }
                }
                else
                {
                    if (categoriiAutomobil.Contains(cat.Id))
                    {
                        CategorieAutomobil courseToRemove
                        = autoToUpdate
                        .CategoriiAutomobil
                        .SingleOrDefault(i => i.CategorieId == cat.Id);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }

}