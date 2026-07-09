using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReportsController(AppDbContext context)
    {
        _context = context;
    }

// GET: api/reports/general
    [HttpGet("general")]
    public async Task<ActionResult<GeneralReportDto>> GetGeneralReport()
    {
        /*
            Retorno completo pedido no enunciado.
        */
        var people = await _context.People
            .Include(p => p.Transactions)
            .ToListAsync();

        var peopleTotals = people
            .Select(person =>
            {
                var income = person.Transactions
                    .Where(t => t.Type == TransactionType.Income)
                    .Sum(t => t.Amount);

                var expenses = person.Transactions
                    .Where(t => t.Type == TransactionType.Expense)
                    .Sum(t => t.Amount);

                return new PersonTotalDto
                {
                    PersonId = person.Id,
                    PersonName = person.Name,
                    TotalIncome = income,
                    TotalExpenses = expenses
                };

            })
            .ToList();

        var report = new GeneralReportDto
        {
            People = peopleTotals,

            TotalIncome = peopleTotals
                .Sum(p => p.TotalIncome),

            TotalExpenses = peopleTotals
                .Sum(p => p.TotalExpenses)
        };
        return Ok(report);
    }




    /*
        Retorno apenas do saldo total da residência.
    */
    // GET: api/reports/household-total
    [HttpGet("household-total")]
    public async Task<ActionResult<HouseholdTotalDto>> GetHouseholdTotal()
    {
        /*
            Primeiro foi puxado o retorno do banco de dados para depois realizar as somas porque SQLite
            não consegue trabalhar com soma de tipos decimais então é passado para o C# a soma.
        */
        var transactions = await _context.Transactions
            .ToListAsync();


        var totalIncome = transactions
            .Where(t => t.Type == TransactionType.Income)
            .Sum(t => t.Amount);


        var totalExpenses = transactions
            .Where(t => t.Type == TransactionType.Expense)
            .Sum(t => t.Amount);


        var result = new HouseholdTotalDto
        {
            TotalIncome = totalIncome,
            TotalExpenses = totalExpenses
        };


        return Ok(result);
    }



    /*
        Retorno do apenas do saldo total por pessoa especifica.
    */
    [HttpGet("person/{id}")]
    public async Task<ActionResult<PersonTotalDto>> GetPersonTotal(Guid id)
    {
    /*
        Primeiro foi puxado o retorno do banco de dados para depois realizar as somas porque SQLite
        não consegue trabalhar com soma de tipos decimais então é passado para o C# a soma.
    */

    var person = await _context.People
        .Include(p => p.Transactions)
        .FirstOrDefaultAsync(p => p.Id == id);


    if (person == null)
    {
        return NotFound("Person not found.");
    }


    var totalIncome = person.Transactions
        .Where(t => t.Type == TransactionType.Income)
        .Sum(t => t.Amount);


    var totalExpenses = person.Transactions
        .Where(t => t.Type == TransactionType.Expense)
        .Sum(t => t.Amount);


    var result = new PersonTotalDto
    {
        PersonId = person.Id,
        PersonName = person.Name,
        TotalIncome = totalIncome,
        TotalExpenses = totalExpenses
    };


    return Ok(result);
    }
}