namespace Backend.Models;

public enum TransactionType
{
/*
    Levando em consideração o potencial de crescimento do sistema, TransactionType foi separado
    para melhorar a leitura e facilitar mudanças.
*/
    Expense = 0,
    Income = 1
}