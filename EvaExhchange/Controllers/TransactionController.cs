using EvaExhchange.Context;
using EvaExhchange.Dtos;
using EvaExhchange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaExhchange.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyStock([FromBody] TransactionDto transactionDto)
        {
            var stock = await _context.Stocks.FindAsync(transactionDto.StockSymbol);
            var portfolio = await _context.Portfolios.FindAsync(transactionDto.PortfolioId);

            if (stock == null || portfolio == null)
                return BadRequest("Stock or portfolio not found");

            var existingStockInPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(sp => sp.StockSymbol == transactionDto.StockSymbol && sp.PortfolioId == transactionDto.PortfolioId);

            if (existingStockInPortfolio == null)
                return BadRequest("Stock is not in portfolio");

            var transaction = new Transaction
            {
                UserId = transactionDto.UserId,
                StockSymbol = transactionDto.StockSymbol,
                PortfolioId = transactionDto.PortfolioId,
                Quantity = transactionDto.Quantity,
                IsBuy = true,
                TransactionDate = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        [HttpPost("sell")]
        public async Task<IActionResult> SellStock([FromBody] TransactionDto transactionDto)
        {
            var stock = await _context.Stocks.FindAsync(transactionDto.StockSymbol);
            var portfolio = await _context.Portfolios.FindAsync(transactionDto.PortfolioId);

            if (stock == null || portfolio == null)
                return BadRequest("Stock or portfolio not found");

            var existingStockInPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(sp => sp.StockSymbol == transactionDto.StockSymbol && sp.PortfolioId == transactionDto.PortfolioId);

            if (existingStockInPortfolio == null || existingStockInPortfolio.Quantity < transactionDto.Quantity)
                return BadRequest("Insufficient stock quantity in portfolio");

            var transaction = new Transaction
            {
                UserId = transactionDto.UserId,
                StockSymbol = transactionDto.StockSymbol,
                PortfolioId = transactionDto.PortfolioId,
                Quantity = transactionDto.Quantity,
                IsBuy = false,
                TransactionDate = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }
    }
}
