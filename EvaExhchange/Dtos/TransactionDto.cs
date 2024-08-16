namespace EvaExhchange.Dtos
{
    public class TransactionDto
    {
        public string UserId { get; set; }
        public string StockSymbol { get; set; }
        public int PortfolioId { get; set; }
        public int Quantity { get; set; }
    }

}
