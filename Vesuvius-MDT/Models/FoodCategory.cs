using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class FoodCategory
{
    public int FoodCategoryId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    public List<MenuItem> MenuItems { get; set; }
}