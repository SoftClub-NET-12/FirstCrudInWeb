using FirstCrudinWeb.Filters;
using FirstCrudinWeb.Models;

namespace FirstCrudinWeb.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories(CategoryFilter filter);
    Category? GetCategoryById(int id);
    bool AddCategory(Category category);
    bool UpdateCategory(Category category);
    bool DeleteCategory(int id);
}