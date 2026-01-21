using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Extensions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TagsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
    {
        var tags = await _context.Tags
            .OrderBy(t => t.Name)
            .ToListAsync();

        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
        var tag = await _context.Tags
            .Include(t => t.Activities)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            return NotFound(new { message = "Tag not found" });
        }

        return Ok(tag);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Tag>> CreateTag(Tag tag)
    {
        if (!User.IsAdmin())
        {
            return Forbid();
        }

        // Check if tag with same name already exists
        if (await _context.Tags.AnyAsync(t => t.Name == tag.Name))
        {
            return BadRequest(new { message = "Tag with this name already exists" });
        }

        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Tag>> UpdateTag(int id, Tag tag)
    {
        if (!User.IsAdmin())
        {
            return Forbid();
        }

        var existingTag = await _context.Tags.FindAsync(id);

        if (existingTag == null)
        {
            return NotFound(new { message = "Tag not found" });
        }

        // Check if another tag with same name exists
        if (await _context.Tags.AnyAsync(t => t.Name == tag.Name && t.Id != id))
        {
            return BadRequest(new { message = "Tag with this name already exists" });
        }

        existingTag.Name = tag.Name;
        existingTag.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(existingTag);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteTag(int id)
    {
        if (!User.IsAdmin())
        {
            return Forbid();
        }

        var tag = await _context.Tags
            .Include(t => t.Activities)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            return NotFound(new { message = "Tag not found" });
        }

        // Prevent deletion if activities are using this tag
        if (tag.Activities.Any())
        {
            return BadRequest(new { message = "Cannot delete tag that is used by activities. Remove tag from activities first." });
        }

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
