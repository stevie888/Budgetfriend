using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Budgetfriend.Model;
namespace Budgetfriend.Services.Interfaces;



public interface ITagService
{
    Task<List<string>> GetAllTagsAsync();
    Task AddCustomTagAsync(string tag);
    Task DeleteCustomTagAsync(string tag);
} 