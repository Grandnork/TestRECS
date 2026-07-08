using Backend.Models;

namespace Backend.DTOs;

public class CreateTransactionDto
{
    public string Description { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    public TransactionType Type { get; init; }

    public Guid PersonId { get; init; }
}