using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static GameZone.Constants.ModelConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext _contex)
        {
            context = _contex;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameInfoViewModel
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                })
                .AsNoTracking()
                .ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameViewModel();
            model.Genres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Ако моделът не е валиден, върнете се към изгледа с текущия модел
                model.Genres = await context.Genres
                    .AsNoTracking()
                    .Select(g => new GenreViewModel
                    {
                        Id = g.Id,
                        Name = g.Name
                    })
                    .ToListAsync();
                return View(model);
            }

            // Създайте нов обект от типа Game и го попълнете с данните от модела
            var game = new Game
            {
                Title = model.Title,
                GenreId = model.GenreId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublisherId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                ReleasedOn = Convert.ToDateTime(model.ReleasedOn),
                IsDeleted = false
            };

            // Добавете новия обект към контекста
            context.Games.Add(game);
            await context.SaveChangesAsync();

            // Пренасочете потребителя към страницата с всички игри
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var model = context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameViewModel
                {
                    Title = g.Title,
                    GenreId = g.GenreId,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                })
                .FirstOrDefault();

            model.Genres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel model)
        {
            var game = context.Games
                .Where(g => g.Id == model.Id)
                .FirstOrDefault();
            game.Title = model.Title;
            game.GenreId = model.GenreId;
            game.Description = model.Description;
            game.ImageUrl = model.ImageUrl;
            game.ReleasedOn = Convert.ToDateTime(model.ReleasedOn);

            context.Games.Update(game);
           
            context.SaveChanges();

            model.Genres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await context.Games
               .Where(g => g.IsDeleted  == false && g.PublisherId == userId)
               .Select(g => new GameInfoViewModel
               {
                   Id = g.Id,
                   Genre = g.Genre.Name,
                   Title = g.Title,
                   ImageUrl = g.ImageUrl,
                   Publisher = g.Publisher.UserName ?? string.Empty,
                   ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
               })
               
               .AsNoTracking()
               .ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }
    }
}
