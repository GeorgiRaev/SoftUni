using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Controllers
{
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        public ProductController(ApplicationDbContext context)
            : base(context)
        {

        }
        public async Task<IActionResult> Index()
        {

            var userId = GetUserId();
            var model = new List<ProductAllViewModel>();

            if (userId == null)
            {
                model = context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl

                }).ToList();
            }
            else
            {
                model = context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsSeller = p.SellerId == userId,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId)

                }).ToList();
            }
            return View(model);


        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductAddViewModel model = new ProductAddViewModel
            {
                Categories = await context.Categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToListAsync()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories  = await context.Categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToListAsync();
                return View(model);
            }

            string userId = GetUserId();
            context.Products.Add(new Product
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                AddedOn = DateTime.Parse(model.AddedOn),
                SellerId = userId
            });
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();
            var model = context.ProductsClients
                .Where(pc => pc.ClientId == userId)
                .Select(pc => new ProductCartViewModel
                {
                    Id = pc.ProductId,
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price,
                    ImageUrl = pc.Product.ImageUrl
                }).ToList();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = context.Products.Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    AddedOn = p.AddedOn.ToString("dd-MM-yyyy"),
                    Seller = p.Seller.UserName,
                    CategoryName = p.Category.Name,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == GetUserId())
                }).FirstOrDefault();
                
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductEditViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    SellerId = p.SellerId,
                    CategoryId = p.CategoryId,
                    AddedOn = p.AddedOn.ToString("dd-MM-yyyy"),
                    Categories = context.Categories
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .ToList()
                }).FirstOrDefault();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await context.Categories
                 .Select(c => new CategoryViewModel
                 {
                     Id = c.Id,
                     Name = c.Name
                 })
                 .ToListAsync();
                return View(model);
            }

            string userId = GetUserId();
            var entity = context.Products
                .Where(p => p.Id == model.Id)
               .FirstOrDefault();
           
            entity.ProductName = model.ProductName;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.ImageUrl = model.ImageUrl;
            entity.CategoryId = model.CategoryId;
            entity.AddedOn = DateTime.Parse(model.AddedOn);
            context.SaveChanges();
            return RedirectToAction("Details", new { id = model.Id });

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDeleteViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    SellerId = p.SellerId,
                    Seller = p.Seller.UserName
                }).FirstOrDefault();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            string userId = GetUserId();
            var product = context.Products
                .Where(p => p.Id == model.Id)
                .FirstOrDefault();
            if (product.SellerId == userId)
            {
                var entity = context.Products.Remove(product);
                context.SaveChanges();
            }
           
            return RedirectToAction(nameof(Index));

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
           
            string userId = GetUserId();
            var isAlreadyAdded = context.ProductsClients
                .Where(p => p.ProductId == id && p.ClientId == userId)
               .Any();

            if (!isAlreadyAdded)
            {
                context.ProductsClients.Add(new ProductClient()
                {
                    ClientId = userId,
                    ProductId = id
                });

                context.SaveChanges();
            }

            return RedirectToAction(nameof(Cart));

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = GetUserId();
            var addedProduct = context.ProductsClients
                .Where(p => p.ProductId == id && p.ClientId == userId)
               .FirstOrDefault();

            if (addedProduct != null)
            {
                context.ProductsClients.Remove(addedProduct);

                context.SaveChanges();
            }

            return RedirectToAction(nameof(Cart));

        }

    }
}
