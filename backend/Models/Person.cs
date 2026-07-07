using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Person
{
/*
    Durante o desenvolvimento e estudo do sistema criado, foi optado por utilizar private set no identificador Guid,
    pois, é de suma importância que em um sistema as chaves primarias de identificação não sejam alteradas livremente.
*/
    public Guid Id { get; private set; } = Guid.NewGuid();

/*
    Validação de nome refeita para realizar o bloqueio de numeros e grande parte dos simbolos, 
    bloqueando a inserção de simbolos invalidos, mas levando em consideração nomes como "O'Connor".
*/
    [Required]
    [MaxLength(100)]
    [RegularExpression(
        @"^[a-zA-ZÀ-ÿ\s'-]+$",
        ErrorMessage = "Name contains invalid characters."
    )]
    public string Name { get; set; } = string.Empty;

    [Range(0, 123)]
    public int Age { get; set; }

    // Navigation property
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}