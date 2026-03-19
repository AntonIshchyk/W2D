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
public class SpacesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SpacesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Community>>> GetSpaces()
    {
        var communities = await _context.Communities.OrderBy(s => s.Name).ToListAsync();
        return Ok(communities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Community>> GetSpace(int id)
    {
        var community = await _context.Communities.FirstOrDefaultAsync(s => s.Id == id);
        if (community == null) return NotFound(new { message = "Community not found" });
        return Ok(community);
    }
}
