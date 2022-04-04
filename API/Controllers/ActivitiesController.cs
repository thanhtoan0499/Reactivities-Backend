using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        // GET: api/Activities/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Activity>> GetActivity (Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity ([FromBody]Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Activity>> PutActivity (Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity (Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
