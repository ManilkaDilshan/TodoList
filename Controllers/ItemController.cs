using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;

namespace TodoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ItemController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllItems()
    {
        try
        { 
            return Ok(await _dataContext.Items.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        try
        { 
            var item = await _dataContext.Items.FindAsync(id);
            if (item is null) return NotFound("Sorry, task does not exists");
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<Item>>> AddItem(Item item)
    {
        try
        {
            _dataContext.Items.Add(item);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Items.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Item>> UpdateItem(int id, Item updatedItem)
    {
        try
        { 
            var item = await _dataContext.Items.FindAsync(id);
            if (item is null)
                return NotFound("Sorry, task does not exists");
        
            item.Title = updatedItem.Title;
            item.Description = updatedItem.Description;
            item.IsCompleted = updatedItem.IsCompleted;
            item.Color = updatedItem.Color;

            await _dataContext.SaveChangesAsync();

            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Item>>> DeleteItem(int id)
    {
        try
        {
            var item = await _dataContext.Items.FindAsync(id);
            if (item is null)
                return NotFound("Sorry, task does not exists");

            _dataContext.Items.Remove(item);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Items.ToListAsync());

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
