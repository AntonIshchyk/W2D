using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("fixed")]
[Authorize]
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
        List<Tag> tags = await _context.Tags
            .OrderBy(t => t.Name)
            .ToListAsync();

        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
        Tag? tag = await _context.Tags
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            return NotFound(new { message = "Tag not found" });
        }

        return Ok(tag);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Tag>> CreateTag(Tag tag)
    {
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
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Tag>> UpdateTag(int id, Tag tag)
    {
        Tag? existingTag = await _context.Tags.FindAsync(id);

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
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteTag(int id)
    {
        Tag? tag = await _context.Tags
            .Include(t => t.Events)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            return NotFound(new { message = "Tag not found" });
        }

        // Prevent deletion if events are using this tag
        if (tag.Events.Any())
        {
            return BadRequest(new { message = "Cannot delete tag that is used by events. Remove tag from events first." });
        }

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
