using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Budgetfriend.Model;
using Budgetfriend.Services.Interfaces;

public class TagService : ITagService
{
    // File path for storing custom tags in the user's Documents folder
    private readonly string _tagsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tags.csv");

    // Predefined list of default tags that cannot be deleted
    private readonly List<string> _defaultTags = new List<string>
    {
        "Yearly", "Monthly", "Food", "Drinks", "Clothes", "Gadgets",
        "Miscellaneous", "Fuel", "Rent", "EMI", "Party"
    };

    // Retrieves both default and custom tags, ensuring no duplicates
    public async Task<List<string>> GetAllTagsAsync()
    {
        var customTags = await LoadCustomTagsAsync();
        return _defaultTags.Concat(customTags).Distinct().ToList();
    }

    // Adds a new custom tag if it doesn't already exist in either default or custom tags
    public async Task AddCustomTagAsync(string tag)
    {
        var customTags = await LoadCustomTagsAsync();
        if (!customTags.Contains(tag) && !_defaultTags.Contains(tag))
        {
            customTags.Add(tag);
            await SaveCustomTagsAsync(customTags);
        }
    }

    // Loads custom tags from the CSV file, returns empty list if file doesn't exist
    private async Task<List<string>> LoadCustomTagsAsync()
    {
        if (!File.Exists(_tagsFilePath))
        {
            return new List<string>();
        }

        var tags = await File.ReadAllLinesAsync(_tagsFilePath);
        return tags.ToList();
    }

    // Saves the custom tags list to the CSV file
    private async Task SaveCustomTagsAsync(List<string> tags)
    {
        await File.WriteAllLinesAsync(_tagsFilePath, tags);
    }

    // Deletes a custom tag if it exists, throws exception if attempting to delete a default tag
    public async Task DeleteCustomTagAsync(string tag)
    {
        if (_defaultTags.Contains(tag))
        {
            throw new InvalidOperationException("Cannot delete default tags");
        }

        var customTags = await LoadCustomTagsAsync();
        if (customTags.Contains(tag))
        {
            customTags.Remove(tag);
            await SaveCustomTagsAsync(customTags);
        }
    }
} 