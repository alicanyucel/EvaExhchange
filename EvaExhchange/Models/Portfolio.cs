using System.ComponentModel.DataAnnotations;

namespace EvaExhchange.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<StockPortfolio> StockPortfolios { get; set; }
    }
}
