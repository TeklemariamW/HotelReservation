using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}