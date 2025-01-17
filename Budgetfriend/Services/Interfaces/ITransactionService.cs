using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Budgetfriend.Model;
namespace Budgetfriend.Services.Interfaces;

/// <summary>
/// Service interface for managing financial transactions
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Saves a new transaction to the database
    /// </summary>
    /// <param name="transaction">The transaction to be saved</param>
    Task SaveTransactionAsync(Transaction transaction);

    /// <summary>
    /// Retrieves all transactions from the database
    /// </summary>
    /// <returns>A list of all transactions</returns>
    Task<List<Transaction>> LoadTransactionsAsync();

    /// <summary>
    /// Deletes a transaction from the database by its ID
    /// </summary>
    /// <param name="transactionId">The ID of the transaction to delete</param>
    Task DeleteTransactionAsync(int transactionId);

    /// <summary>
    /// Calculates various financial summaries from a list of transactions
    /// </summary>
    /// <param name="transactions">The list of transactions to analyze</param>
    /// <returns>A tuple containing total inflows, outflows, debt metrics, balance, and balance sufficiency status</returns>
    (decimal totalInflows, decimal totalOutflows, decimal totalDebt, decimal totalClearedDebt, decimal remainingDebt, decimal balance, bool isSufficientBalance) CalculateTransactionSums(List<Transaction> transactions);

    /// <summary>
    /// Searches for transactions by their title
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <returns>A list of matching transactions</returns>
    Task<List<Transaction>> SearchTransactionsByTitleAsync(string title);

    /// <summary>
    /// Filters transactions based on multiple criteria
    /// </summary>
    /// <param name="startDate">Optional start date for filtering</param>
    /// <param name="endDate">Optional end date for filtering</param>
    /// <param name="type">Transaction type filter</param>
    /// <param name="tags">Tags to filter by</param>
    /// <returns>A filtered list of transactions</returns>
    Task<List<Transaction>> FilterTransactionsAsync(DateTime? startDate, DateTime? endDate, string type, string tags);

    /// <summary>
    /// Sorts transactions based on a specified field
    /// </summary>
    /// <param name="sortBy">The field to sort by</param>
    /// <param name="isAscending">True for ascending order, false for descending</param>
    /// <returns>A sorted list of transactions</returns>
    Task<List<Transaction>> SortTransactionsAsync(string sortBy, bool isAscending);

    /// <summary>
    /// Sorts transactions in ascending order by a specified field
    /// </summary>
    /// <param name="sortBy">The field to sort by</param>
    /// <returns>A sorted list of transactions</returns>
    Task<List<Transaction>> SortTransactionsAscending(string sortBy);

    /// <summary>
    /// Sorts transactions in descending order by a specified field
    /// </summary>
    /// <param name="sortBy">The field to sort by</param>
    /// <returns>A sorted list of transactions</returns>
    Task<List<Transaction>> SortTransactionsDescending(string sortBy);

    /// <summary>
    /// Updates an existing transaction in the database
    /// </summary>
    /// <param name="transaction">The transaction with updated information</param>
    Task UpdateTransactionAsync(Transaction transaction);
}