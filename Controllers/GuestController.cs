using Microsoft.AspNetCore.Mvc;
using GroupPreOrderApi.Models;

namespace GroupPreOrderApi.Controllers;

[ApiController]
[Route("guest")]
public class GuestController : ControllerBase
{
    /// <summary>
    /// GET /guest/groups/{groupReservationId}/sessions
    /// Отримання списку сесій учасників групового pre-order для Owner
    /// </summary>
    [HttpGet("groups/{groupReservationId}/sessions")]
    public IActionResult GetGroupSessions([FromRoute] string groupReservationId)
    {
        var response = new GroupSessionsResponseDto
        {
            Participants = new List<ParticipantDto>
            {
                new ParticipantDto
                {
                    Id = "session1",
                    Type = "Guest",
                    Name = "Andrii",
                    IsSubmitted = true,
                    Items = new List<OrderItemDto>
                    {
                        new OrderItemDto
                        {
                            Dish = new DishDto { Id = "dish1", Name = "Caesar Salad", Price = 180 },
                            Quantity = 2
                        }
                    }
                },
                new ParticipantDto
                {
                    Id = "session2",
                    Type = "Guest",
                    Name = "Olena",
                    IsSubmitted = false,
                    Items = new List<OrderItemDto>
                    {
                        new OrderItemDto
                        {
                            Dish = new DishDto { Id = "dish2", Name = "Tom Yum", Price = 220 },
                            Quantity = 1
                        }
                    }
                }
            }
        };

        return Ok(response);
    }
}