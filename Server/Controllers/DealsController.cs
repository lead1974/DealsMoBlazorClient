using AutoMapper;
using DealsMo.Server.Helpers;
using DealsMo.Shared.DTOs;
using DealsMo.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class DealsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private string containerName = "deals";

        public DealsController(ApplicationDbContext context,
            IFileStorageService fileStorageService,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IndexPageDTO>> Get()
        //{
        //    var limit = 6;

        //    var dealsInTheaters = await context.Deals
        //        .Where(x => x.InTheaters).Take(limit)
        //        .OrderByDescending(x => x.ReleaseDate)
        //        .ToListAsync();

        //    var todaysDate = DateTime.Today;

        //    var upcomingReleases = await context.Deals
        //        .Where(x => x.ReleaseDate > todaysDate)
        //        .OrderBy(x => x.ReleaseDate).Take(limit)
        //        .ToListAsync();

        //    var response = new IndexPageDTO();
        //    response.Intheaters = dealsInTheaters;
        //    response.UpcomingReleases = upcomingReleases;

        //    return response;

        //}

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DealDetailsDTO>> Get(int id)
        {
            var deal = await context.Deals.Where(x => x.Id == id)
                .Include(x => x.DealsCategories).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync();

            if (deal == null) { return NotFound(); }

            var voteAverage = 0.0;
            var uservote = 0;

            if (await context.DealRating.AnyAsync(x => x.DealId == id))
            {
                voteAverage = await context.DealRating.Where(x => x.DealId == id)
                    .AverageAsync(x => x.Rate);

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
                    var userId = user.Id;

                    var userVoteDB = await context.DealRating
                        .FirstOrDefaultAsync(x => x.DealId == id && x.UserId == userId);

                    if (userVoteDB != null)
                    {
                        uservote = userVoteDB.Rate;
                    }
                }
            }

            var model = new DealDetailsDTO();
            model.Deal = deal;
            model.DealCategories = deal.DealsCategories.Select(x => x.Category).OrderBy(x => x.Seq).ToList();

            model.UserVote = uservote;
            model.AverageVote = voteAverage;
            return model;
        }

        [HttpPost("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Deal>>> Filter(FilterDealsDTO filterDealsDTO)
        {
            var dealsQueryable = context.Deals.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterDealsDTO.Title))
            {
                dealsQueryable = dealsQueryable
                    .Where(x => x.Title.Contains(filterDealsDTO.Title));
            }

            if (filterDealsDTO.IsPopular)
            {
                dealsQueryable = dealsQueryable.Where(x => x.IsPopular);
            }

            if (filterDealsDTO.DealCategoryId != 0)
            {
                dealsQueryable = dealsQueryable
                    .Where(x => x.DealsCategories.Select(y => y.CategoryId)
                    .Contains(filterDealsDTO.DealCategoryId));
            }

            await HttpContext.InsertPaginationParametersInResponse(dealsQueryable,
                filterDealsDTO.RecordsPerPage);

            var deals = await dealsQueryable.Paginate(filterDealsDTO.Pagination).ToListAsync();

            return deals;
        }



        [HttpGet("update/{id}")]
        public async Task<ActionResult<DealUpdateDTO>> PutGet(int id)
        {
            var dealActionResult = await Get(id);
            if (dealActionResult.Result is NotFoundResult) { return NotFound(); }

            var dealDetailDTO = dealActionResult.Value;
            var selectedCategoriesIds = dealDetailDTO.DealCategories.Select(x => x.Id).ToList();
            var notSelectedCategories = await context.DealCategories
                .Where(x => !selectedCategoriesIds.Contains(x.Id))
                .ToListAsync();

            var model = new DealUpdateDTO();
            model.Deal = dealDetailDTO.Deal;
            model.SelectedCategories = dealDetailDTO.DealCategories;
            model.NotSelectedCategories = notSelectedCategories;
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Deal deal)
        {
            if (!string.IsNullOrWhiteSpace(deal.ImageURL))
            {
                var imageURL = Convert.FromBase64String(deal.ImageURL);
                deal.ImageURL = await fileStorageService.SaveFile(imageURL, "jpg", containerName);
            }

            context.Add(deal);
            await context.SaveChangesAsync();
            return deal.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Deal deal)
        {
            var dealDB = await context.Deals.FirstOrDefaultAsync(x => x.Id == deal.Id);

            if (dealDB == null) { return NotFound(); }

            dealDB = mapper.Map(deal, dealDB);

            if (!string.IsNullOrWhiteSpace(deal.ImageURL))
            {
                var dealImageURL = Convert.FromBase64String(deal.ImageURL);
                dealDB.ImageURL = await fileStorageService.EditFile(dealImageURL,
                    "jpg", containerName, dealDB.ImageURL);
            }

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from DealsCategory where DealId = {deal.Id}");

            dealDB.DealsCategories = deal.DealsCategories;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deal = await context.Deals.FirstOrDefaultAsync(x => x.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            context.Remove(deal);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
