


using Budgetfriend.Model;

namespace Budgetfriend.Services.Interfaces;

public interface IDebtService
{
    Task<List<Transaction>> GetAllDebtsAsync();
    Task<List<Transaction>> GetPendingDebtsAsync();
    Task<List<Transaction>> GetClearedDebtsAsync();
    Task<(decimal totalDebt, decimal clearedDebt, decimal pendingDebt)> GetDebtStatisticsAsync();
    Task<List<Transaction>> FilterDebtsAsync(string source, string status, DateTime? startDate, DateTime? endDate);
    Task MarkDebtAsClearedAsync(int transactionId);
    Task SaveDebtAsync(Transaction debt);
    Task DeleteDebtAsync(int transactionId);
}
