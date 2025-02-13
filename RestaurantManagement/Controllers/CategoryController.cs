using Applaction.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, [FromQuery] int deletedBy)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "Geçersiz kategori ID" });
        }

        var request = new DeleteCategoryRequest
        {
            DeletedBy = deletedBy
        };

        var response = await _sender.Send(request);

        if (!response.IsSuccess)
        {
            return BadRequest(new { errors = response.Errors });
        }

        return Ok(response);
    }
}
