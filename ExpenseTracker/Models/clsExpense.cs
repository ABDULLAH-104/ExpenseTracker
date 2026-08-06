using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class clsExpense
    {
        public int EXPENSE_ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string? TITLE { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, 1000000, ErrorMessage = "Amount must be greater than 0")]
        public decimal AMOUNT { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string? CATEGORY { get; set; }

        public DateTime EXPENSE_DATE { get; set; }
    }
}