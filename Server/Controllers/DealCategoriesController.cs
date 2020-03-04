using DealsMo.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class DealCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DealCategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<DealCategory>>> Get()
        {
            return await context.DealCategories.OrderBy(x => x.Name).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealCategory>> Get(int id)
        {
            var genre = await context.DealCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null) { return NotFound(); }
            return genre;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DealCategory category)
        {
            category.CreatedBy = "user";
            category.CreatedTS = DateTime.UtcNow;
            category.UpdatedBy = "user";
            category.UpdatedTS = DateTime.UtcNow;
            context.Add(category);
            await context.SaveChangesAsync();
            return category.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(DealCategory category)
        {
            category.CreatedBy = "user";
            category.CreatedTS = DateTime.UtcNow;
            category.UpdatedBy = "user";
            category.UpdatedTS = DateTime.UtcNow;
            context.Attach(category).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await context.DealCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            context.Remove(category);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
