using P235AllupDb.Models;
using P235AllupDb.ViewModels.BasketVMs;

namespace P235AllupDb.Interfaces
{
    public interface ILayoutService
    {
        Task<Dictionary<string,string>> GetSettingsAsync();
        Task<List<Category>> GetCategoriesAsync();
        Task<List<BasketVM>> GetBasketsAsync();
    }
}
