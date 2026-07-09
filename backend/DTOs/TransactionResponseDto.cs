using Backend.Models;

namespace Backend.DTOs;

public class TransactionResponseDto
{
    public Guid Id { get; init; }

    public string Description { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    public TransactionType Type { get; init; }

    public Guid PersonId { get; init; }

    public string PersonName { get; init; } = string.Empty;
}