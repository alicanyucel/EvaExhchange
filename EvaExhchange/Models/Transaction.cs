using System.ComponentModel.DataAnnotations;

namespace EvaExhchange.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(3)]
        public string StockSymbol { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public bool IsBuy { get; set; } // true for buy, false for sell

        [Required]
        public DateTime TransactionDate { get; set; }

        public Stock Stock { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}