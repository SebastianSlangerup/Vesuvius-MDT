using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class FoodCategory
{
    public int FoodCategoryId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [JsonIgnore]
    public List<MenuItem> MenuItems { get; set; }
}