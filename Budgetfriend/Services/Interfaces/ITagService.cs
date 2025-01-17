using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Budgetfriend.Model;
namespace Budgetfriend.Services.Interfaces;

/// <summary>
/// Service interface for managing tags in the budget application
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Retrieves all available tags from the system
    /// </summary>
    /// <returns>A list of tag strings</returns>
    Task<List<string>> GetAllTagsAsync();

    /// <summary>
    /// Adds a new custom tag to the system
    /// </summary>
    /// <param name="tag">The tag string to be added</param>
    Task AddCustomTagAsync(string tag);

    /// <summary>
    /// Removes an existing custom tag from the system
    /// </summary>
    /// <param name="tag">The tag string to be deleted</param>
    Task DeleteCustomTagAsync(string tag);
} 