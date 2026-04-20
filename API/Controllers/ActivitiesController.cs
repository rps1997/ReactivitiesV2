using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;
using MediatR;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    { 
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var query = await Mediator.Send(new GetActivityList.Query());
            return query;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var query =  await Mediator.Send(new GetActivityDetail.Query{Id = id});
            return query;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            await Mediator.Send(new CreateActivity.Command{Activity = activity});
            return Ok(activity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command{Activity = activity});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command{Id = id});
            return Ok();
        }
    }
}
