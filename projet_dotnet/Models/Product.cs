using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_dotnet.Models
{
    public class Product
    {
     
        public int Id { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public float Price { get; set; } 
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }   
    }
}
