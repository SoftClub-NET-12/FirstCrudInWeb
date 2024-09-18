using System.Text.Json;
using FirstCrudinWeb.Filters;
using FirstCrudinWeb.Models;
using FirstCrudinWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrudinWeb.Controllers;

[Route("Category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService = new CategoryService();

    [HttpGet]
    public IEnumerable<Category> GetAllCategories()
    {
        string name = HttpContext.Request.Query["name"].ToString();
        CategoryFilter filter = new CategoryFilter(name);

        return _categoryService.GetAllCategories(filter);
    }

    [HttpGet("{id}")]
    public Category? GetCategoryById(int id)
    {
        return _categoryService.GetCategoryById(id);
    }

    [HttpPost]
    public bool CreateCategory()
    {
        using (var reader = new StreamReader(HttpContext.Request.Body))
        {
            string body = reader.ReadToEnd();
            Category? category = JsonSerializer.Deserialize<Category>(body);
            return _categoryService.AddCategory(category!);
        }
    }

    [HttpPut]
    public bool UpdateCategory()
    {
        using (var reader = new StreamReader(HttpContext.Request.Body))
        {
            var body = reader.ReadToEnd();
            Category? category = JsonSerializer.Deserialize<Category>(body);
            return _categoryService.UpdateCategory(category!);
        }
    }

    [HttpPatch]
    public bool UpdateCategoryWithPatch()
    {
        using (var reader = new StreamReader(HttpContext.Request.Body))
        {
            var body = reader.ReadToEnd();
            Category? category = JsonSerializer.Deserialize<Category>(body);
            return _categoryService.UpdateCategory(category!);
        }
    }

    [HttpDelete("{id}")]
    public bool DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
    
    [HttpOptions]
    public IActionResult Options()
    {
        // Возвращаем заголовки, указывающие поддерживаемые методы
        Response.Headers.Append("Allow", "GET, POST, PUT, DELETE, PATCH, OPTIONS, HEAD");
        return Ok();
    }
    
    [HttpHead]
    public IActionResult Head()
    {
        return Ok();
    }
}