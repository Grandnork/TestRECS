namespace Backend.DTOs;

public class PersonTotalDto
{
    public Guid PersonId { get; init; }

    public string PersonName { get; init; } = string.Empty;

    public decimal TotalIncome { get; init; }

    public decimal TotalExpenses { get; init; }

    public decimal Balance => TotalIncome - TotalExpenses;
}