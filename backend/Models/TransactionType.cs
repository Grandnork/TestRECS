namespace Backend.Models;

public enum TransactionType
{
/*
    Primeiramente foi pensado na utilização dos sinais para identificar e diferenciar transações de receita e despeja, mas
    todo sistema financeiro também trabalha com o calculo de impostos que variam dependendo do tipo e natureza da operação,
    a identificação sobre o tipo de transação facilitaria o calculo de impostos para cada uma delas.
*/
    Expense = 0,
    Income = 1
}