using ExpenseTracker.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ExpenseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // CREATE - POST (Body se data aata hai)
        [HttpPost]
        [Route("AddExpense")]
        public async Task<IActionResult> AddExpense([FromBody] clsExpense request)
        {
            string? connString = _configuration.GetConnectionString("connString");
            using var _context = new SqlConnection(connString);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TITLE", request.TITLE);
            parameters.Add("@AMOUNT", request.AMOUNT);
            parameters.Add("@CATEGORY", request.CATEGORY);
            parameters.Add("@PROC_TYPE", "1");

            await _context.ExecuteAsync("SP_MANAGE_EXPENSES", parameters, commandType: CommandType.StoredProcedure);
            return Ok(new { Message = "Expense added successfully" });
        }

        // READ - GET (Body nahi, seedha URL se data milta hai)
        [HttpGet]
        [Route("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {
            string? connString = _configuration.GetConnectionString("connString");
            using var _context = new SqlConnection(connString);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PROC_TYPE", "2");

            var expenses = await _context.QueryAsync<clsExpense>("SP_MANAGE_EXPENSES", parameters, commandType: CommandType.StoredProcedure);
            return Ok(new { Message = "All Expenses", expenses });
        }

        // DELETE - DELETE (ID URL ke through aata hai)
        [HttpDelete]
        [Route("DeleteExpense/{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            string? connString = _configuration.GetConnectionString("connString");
            using var _context = new SqlConnection(connString);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EXPENSE_ID", id);
            parameters.Add("@PROC_TYPE", "3");

            await _context.ExecuteAsync("SP_MANAGE_EXPENSES", parameters, commandType: CommandType.StoredProcedure);
            return Ok(new { Message = "Expense deleted successfully" });
        }

        // FILTER - GET (Category URL se milta hai)
        [HttpGet]
        [Route("GetByCategory/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            string? connString = _configuration.GetConnectionString("connString");
            using var _context = new SqlConnection(connString);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CATEGORY", category);
            parameters.Add("@PROC_TYPE", "4");

            var expenses = await _context.QueryAsync<clsExpense>("SP_MANAGE_EXPENSES", parameters, commandType: CommandType.StoredProcedure);
            return Ok(new { Message = "Filtered Expenses", expenses });
        }
    }
}