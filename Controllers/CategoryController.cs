using FirstCrudinWeb.Filters;
using FirstCrudinWeb.Models;
using FirstCrudinWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrudinWeb.Controllers;

[Route("Category")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Category> GetAllCategories([FromQuery]CategoryFilter filter)
    {
        return categoryService.GetAllCategories(filter);
    }

    [HttpGet("{id}")]
    public Category? GetCategoryById(int id)
    {
        return categoryService.GetCategoryById(id);
    }

    [HttpPost]
    public bool CreateCategory([FromBody]Category category)
    {
        return categoryService.AddCategory(category!);
    }

    [HttpPut]
    public bool UpdateCategory([FromBody]Category category)
    {
        return categoryService.UpdateCategory(category!);
    }
    

    [HttpDelete("{id}")]
    public bool DeleteCategory(int id)
    {
        return categoryService.DeleteCategory(id);
    }
}