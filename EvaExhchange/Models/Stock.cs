using System.ComponentModel.DataAnnotations;

namespace EvaExhchange.Models
{
    public class Stock
    {
        [Key]
        [StringLength(3)]
        public string Symbol { get; set; } // 3 karakter uzunluğunda ve büyük harf

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}