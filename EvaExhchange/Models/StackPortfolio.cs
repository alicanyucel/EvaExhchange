using System.ComponentModel.DataAnnotations;
namespace EvaExhchange.Models;
public class StockPortfolio
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(3)]
    public string StockSymbol { get; set; }

    [Required]
    public int PortfolioId { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public Stock Stock { get; set; }
    public Portfolio Portfolio { get; set; }
}
