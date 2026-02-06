using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        List<Category> categories = await _context.Categories
            .OrderBy(c => c.Name)
            .ToListAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        Category? category = await _context.Categories
            .Include(c => c.Activities)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound(new { message = "Category not found" });
        }

        return Ok(category);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        // Check if category with same name already exists
        if (await _context.Categories.AnyAsync(c => c.Name == category.Name))
        {
            return BadRequest(new { message = "Category with this name already exists" });
        }

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Category>> UpdateCategory(int id, Category category)
    {
        Category? existingCategory = await _context.Categories.FindAsync(id);

        if (existingCategory == null)
        {
            return NotFound(new { message = "Category not found" });
        }

        // Check if another category with same name exists
        if (await _context.Categories.AnyAsync(c => c.Name == category.Name && c.Id != id))
        {
            return BadRequest(new { message = "Category with this name already exists" });
        }

        existingCategory.Name = category.Name;
        existingCategory.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(existingCategory);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        Category? category = await _context.Categories
            .Include(c => c.Activities)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound(new { message = "Category not found" });
        }

        // Prevent deletion if activities are using this category
        if (category.Activities.Any())
        {
            return BadRequest(new { message = "Cannot delete category that has activities. Reassign or delete activities first." });
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
