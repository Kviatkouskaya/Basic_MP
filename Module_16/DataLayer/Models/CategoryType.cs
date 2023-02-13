using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public enum CategoryType
    {
        Beverages = 1,
        Condiments = 2,
        Confections = 3,
        [Display(Name = "Daily products")]
        DailyProducts = 4,
        [Display(Name = "Grains cereals")]
        GrainsCereals = 5,
        [Display(Name = "Meat poultry")]
        MeatPoultry = 6,
        Produce = 7,
        Seafood = 8
    }
}
