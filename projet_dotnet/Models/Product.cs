using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float? Price { get; set; }   
    }
}
