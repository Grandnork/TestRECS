namespace Backend.DTOs;

public class HouseholdTotalDto
{
    // Sum of all transactions with Type = Income
    public decimal TotalIncome { get; init; }

    // Sum of all transactions with Type = Expense
    public decimal TotalExpenses { get; init; }

    // Remaining value after expenses
    public decimal Balance => TotalIncome - TotalExpenses;
}