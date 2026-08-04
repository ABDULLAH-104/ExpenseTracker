namespace ExpenseTracker.Models
{
    public class clsExpense
    {
        public int EXPENSE_ID { get; set; }
        public string? TITLE { get; set; }
        public decimal AMOUNT { get; set; }
        public string? CATEGORY { get; set; }
        public DateTime EXPENSE_DATE { get; set; }
    }
}