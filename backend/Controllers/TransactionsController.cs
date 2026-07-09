using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    /*
        Aplicação de DTO para encapsulamento e redução do contato entre o cliente e o banco de dados.
    */

    // GET: api/Transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetTransactions()
    {
    var transactions = await _context.Transactions
        .Select(transaction => new TransactionResponseDto
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Amount = transaction.Amount,
            Type = transaction.Type,
            PersonId = transaction.PersonId,
            PersonName = transaction.Person!.Name
        })
        .ToListAsync();

    return Ok(transactions);
    }

    // POST: api/Transactions
    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(
        CreateTransactionDto dto)
    {
        /*
            Verificar se a pessoa em questão existe primeiramente.
        */
        var person = await _context.People
            .FindAsync(dto.PersonId);


        if (person == null)
        {
            return BadRequest("Person does not exist.");
        }


        /*
            Checar se a pessoa é menor de idade & se o tipo de transação é de receita,
            se ambos forem verdadeiros, o erro de "menor de idade só podem cadastrar despesas" é lançado.
        */

        if (person.Age < 18 &&
            dto.Type == TransactionType.Income)
        {
            return BadRequest(
                "Minors can only register expenses."
            );
        }

        /*
            Aplicação de DTO para encapsulamento e redução do contato entre o cliente e o banco de dados.
        */
        var transaction = new Transaction
        {
            Description = dto.Description,
            Amount = dto.Amount,
            Type = dto.Type,
            PersonId = dto.PersonId
        };


        _context.Transactions.Add(transaction);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTransactions),
            new { id = transaction.Id },
            transaction
        );
    }
}