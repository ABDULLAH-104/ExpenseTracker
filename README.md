# 💰 Expense Tracker API

A simple and clean RESTful API built with **ASP.NET Core** and **SQL Server** to track daily expenses. This project demonstrates core backend development concepts including CRUD operations, stored procedures, and proper RESTful API design.

## 🚀 Features

- ➕ **Add** new expenses with title, amount, and category
- 📋 **View** all expenses (sorted by most recent)
- 🔍 **Filter** expenses by category (Food, Transport, Shopping, etc.)
- 🗑️ **Delete** expenses by ID
- ✅ Follows proper REST conventions (GET, POST, DELETE)

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core Web API (.NET 10)
- **Database:** Microsoft SQL Server
- **ORM/Data Access:** Dapper
- **Database Logic:** Stored Procedures
- **Testing:** Postman

## 📂 Project Structure

```
ExpenseTracker/
│
├── Controllers/
│   └── ExpenseController.cs      # API endpoints
├── Models/
│   └── clsExpense.cs             # Expense data model
├── appsettings.json              # Configuration (connection string)
└── Program.cs                    # App entry point & middleware setup
```

## 📡 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/Expense/AddExpense` | Add a new expense |
| `GET` | `/api/Expense/GetAllExpenses` | Get all expenses |
| `GET` | `/api/Expense/GetByCategory/{category}` | Get expenses by category |
| `DELETE` | `/api/Expense/DeleteExpense/{id}` | Delete an expense by ID |

### Example Request — Add Expense

**POST** `/api/Expense/AddExpense`

```json
{
    "TITLE": "Lunch",
    "AMOUNT": 350,
    "CATEGORY": "Food"
}
```

**Response**

```json
{
    "Message": "Expense added successfully"
}
```

## 🗄️ Database Setup

Run the following SQL script to set up the database table and stored procedure:

```sql
CREATE TABLE TBL_EXPENSES (
    EXPENSE_ID INT IDENTITY(1,1) PRIMARY KEY,
    TITLE VARCHAR(200) NOT NULL,
    AMOUNT DECIMAL(10,2) NOT NULL,
    CATEGORY VARCHAR(50) NOT NULL,
    EXPENSE_DATE DATETIME DEFAULT GETDATE()
);
```

The stored procedure `SP_MANAGE_EXPENSES` handles Create, Read, Delete, and Filter operations using a `@PROC_TYPE` parameter pattern.

## ⚙️ Getting Started

1. Clone the repository
   ```bash
   git clone https://github.com/ABDULLAH-104/ExpenseTracker.git
   ```
2. Update the connection string in `appsettings.json` with your SQL Server details
3. Run the database script to create the table and stored procedure
4. Run the project (`F5` in Visual Studio)
5. Test the endpoints using Postman

## 📌 Future Improvements

- [ ] Add Update/Edit expense functionality
- [ ] Add monthly expense summary/reports
- [ ] Add user authentication
- [ ] Add pagination for large expense lists

## 👤 Author

**Abdullah**
Learning backend development with ASP.NET Core & SQL Server

---

⭐ If you found this project helpful, feel free to star the repository!
