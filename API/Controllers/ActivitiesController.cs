using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ReactContext _reactContext;

        public ActivitiesController(ReactContext reactContext)
        {
            _reactContext = reactContext;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _reactContext.Activities.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Activity>> GetActivity (Guid id)
        {
            return await _reactContext.Activities.FindAsync(id);
        }

       
    }
}
