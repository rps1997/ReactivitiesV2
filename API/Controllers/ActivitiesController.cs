using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext context, IMapper mapper) : BaseApiController
    { 
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if (activity == null) return NotFound();
            return activity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(string id, [FromBody] UpdateActivityDto activity)
        {
            if (activity == null)
                return BadRequest("Activity data is required");

            if (string.IsNullOrEmpty(id))
                return BadRequest("Id is required");

            var existingActivity = await context.Activities.FindAsync(id);

            if (existingActivity == null)
                return NotFound();

            mapper.Map(activity, existingActivity);
            

            await context.SaveChangesAsync();

            return Ok(existingActivity); // or NoContent()
        }
    }
}
