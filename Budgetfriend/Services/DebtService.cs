using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetfriend.Services.Interfaces;
using Budgetfriend.Model;

namespace Budgetfriend.Services;

public class DebtService : IDebtService
{
    private readonly ITransactionService _transactionService;

    public DebtService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<List<Transaction>> GetAllDebtsAsync()
    {
        var transactions = await _transactionService.LoadTransactionsAsync();
        return transactions.Where(t => t.Type == "Debt" || t.Type == "Cleared").ToList();
    }

    public async Task<List<Transaction>> GetPendingDebtsAsync()
    {
        var transactions = await _transactionService.LoadTransactionsAsync();
        return transactions.Where(t => t.Type == "Debt").ToList();
    }

    public async Task<List<Transaction>> GetClearedDebtsAsync()
    {
        var transactions = await _transactionService.LoadTransactionsAsync();
        return transactions.Where(t => t.Type == "Cleared").ToList();
    }

    public async Task<(decimal totalDebt, decimal clearedDebt, decimal pendingDebt)> GetDebtStatisticsAsync()
    {
        var allDebts = await GetAllDebtsAsync();
        var totalDebt = allDebts.Sum(d => d.Amount);
        var clearedDebt = allDebts.Where(d => d.Type == "Cleared").Sum(d => d.Amount);
        var pendingDebt = allDebts.Where(d => d.Type == "Debt").Sum(d => d.Amount);

        return (totalDebt, clearedDebt, pendingDebt);
    }

    public async Task<List<Transaction>> FilterDebtsAsync(string source, string status, DateTime? startDate, DateTime? endDate)
    {
        var debts = await GetAllDebtsAsync();

        if (!string.IsNullOrEmpty(source))
        {
            debts = debts.Where(d => 
                d.Title.Contains(source, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (status != "all")
        {
            var debtStatus = status == "pending" ? "Debt" : "Cleared";
            debts = debts.Where(d => d.Type == debtStatus).ToList();
        }

        if (startDate.HasValue)
        {
            debts = debts.Where(d => d.Date >= startDate.Value).ToList();
        }

        if (endDate.HasValue)
        {
            debts = debts.Where(d => d.Date <= endDate.Value).ToList();
        }

        return debts;
    }

    public async Task MarkDebtAsClearedAsync(int transactionId)
    {
        var transactions = await _transactionService.LoadTransactionsAsync();
        var debt = transactions.FirstOrDefault(t => t.TransactionId == transactionId);
        
        if (debt != null && debt.Type == "Debt")
        {
            debt.Type = "Cleared";
            await _transactionService.SaveTransactionAsync(debt);
        }
    }

    public async Task SaveDebtAsync(Transaction debt)
    {
        debt.Type = "Debt";
        await _transactionService.SaveTransactionAsync(debt);
    }

    public async Task DeleteDebtAsync(int transactionId)
    {
        await _transactionService.DeleteTransactionAsync(transactionId);
    }
}
