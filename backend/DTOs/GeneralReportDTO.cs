namespace Backend.DTOs;

public class GeneralReportDto
{
    public List<PersonTotalDto> People { get; init; } = new();

    public decimal TotalIncome { get; init; }

    public decimal TotalExpenses { get; init; }

    public decimal Balance => TotalIncome - TotalExpenses;
}