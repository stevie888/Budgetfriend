using Budgetfriend.Model;

namespace Budgetfriend.Services.Interfaces;

/// <summary>
/// Service interface for managing debt-related operations in the application
/// </summary>
public interface IDebtService
{
    /// <summary>
    /// Retrieves all debt transactions from the database
    /// </summary>
    /// <returns>A list of all debt transactions</returns>
    Task<List<Transaction>> GetAllDebtsAsync();

    /// <summary>
    /// Retrieves all pending debt transactions that haven't been cleared
    /// </summary>
    /// <returns>A list of pending debt transactions</returns>
    Task<List<Transaction>> GetPendingDebtsAsync();

    /// <summary>
    /// Retrieves all cleared debt transactions
    /// </summary>
    /// <returns>A list of cleared debt transactions</returns>
    Task<List<Transaction>> GetClearedDebtsAsync();

    /// <summary>
    /// Calculates and returns debt statistics including total, cleared, and pending amounts
    /// </summary>
    /// <returns>A tuple containing total debt, cleared debt, and pending debt amounts</returns>
    Task<(decimal totalDebt, decimal clearedDebt, decimal pendingDebt)> GetDebtStatisticsAsync();

    /// <summary>
    /// Filters debt transactions based on specified criteria
    /// </summary>
    /// <param name="source">The source of the debt</param>
    /// <param name="status">The status of the debt (cleared/pending)</param>
    /// <param name="startDate">Optional start date for filtering</param>
    /// <param name="endDate">Optional end date for filtering</param>
    /// <returns>A filtered list of debt transactions</returns>
    Task<List<Transaction>> FilterDebtsAsync(string source, string status, DateTime? startDate, DateTime? endDate);

    /// <summary>
    /// Marks a specific debt transaction as cleared
    /// </summary>
    /// <param name="transactionId">The ID of the transaction to mark as cleared</param>
    Task MarkDebtAsClearedAsync(int transactionId);

    /// <summary>
    /// Saves a new debt transaction or updates an existing one
    /// </summary>
    /// <param name="debt">The debt transaction to save</param>
    Task SaveDebtAsync(Transaction debt);

    /// <summary>
    /// Deletes a debt transaction from the database
    /// </summary>
    /// <param name="transactionId">The ID of the transaction to delete</param>
    Task DeleteDebtAsync(int transactionId);
}
