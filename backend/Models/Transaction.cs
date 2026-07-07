using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Transaction
{
/*
    Durante o desenvolvimento e estudo do sistema criado, foi optado por utilizar private set no identificador Guid,
    pois, é de suma importância que em um sistema, as chaves primarias de identificação não sejam alteradas livremente,
    o mesmo se aplica a identificações de transações.
*/
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }

    // Foreign key
    public Guid PersonId { get; set; }

    // Navigation property
    public Person? Person { get; set; }
}