﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;
using comic.ViewModels;

namespace comic.Controllers;

[Route("/admin/manage-products")]
public class ManageProductsController : Controller
{
    private readonly IProductsRepository _productsRepository;
    private IWebHostEnvironment _env;
    private readonly ILogger<ManageProductsController> _logger;

    public ManageProductsController(IProductsRepository productsRepository, IWebHostEnvironment env,
        ILogger<ManageProductsController> logger)
    {
        _productsRepository = productsRepository;
        _env = env;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> ManageProducts()
    {
        if (!User.Identity!.IsAuthenticated || !User.IsInRole("admin"))
        {
            return RedirectToAction("Index", "Home");
        }

        _logger.LogError("An error occurred while loading products.");

        return View(await _productsRepository.GetAll());
    }

    // // GET: ManageProducts/Details/5
    // public async Task<IActionResult> Details(int? id)
    // {
    //     if (id == null || _context.Products == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var product = await _context.Products
    //         .Include(p => p.Category)
    //         .Include(p => p.Publisher)
    //         .Include(p => p.StoreOwner)
    //         .FirstOrDefaultAsync(m => m.ProductId == id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return View(product);
    // }

    // [HttpPost]
    // public async Task<IActionResult> Create(Product product)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View(product);
    //     }
    //     
    //     _productsRepository.Add(product);
    //     return RedirectToAction("Index");
    // }

    // GET: ManageProducts/Create
    [HttpGet]
    [Route("/admin/manage-products/create")]
    public async Task<IActionResult> Create()
    {
        ViewData["CategoryId"] =
            new SelectList(await _productsRepository.GetAllCategories(), "CategoryId", "CategoryName");

        ViewData["PublisherId"] =
            new SelectList(await _productsRepository.GetAllPublisher(), "PublisherId", "PublisherName");

        ViewData["StoreOwnerId"] =
            new SelectList(await _productsRepository.GetAllStoreOwner(), "StoreOwnerId", "FullName");
        
        ViewData["TagsId"] =
            new SelectList(await _productsRepository.GetAllTag(), "TagId", "TagName");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/admin/manage-products/create")]
    public async Task<IActionResult> Create(CreateProductViewModel vm)
    {
        if (ModelState.IsValid)
        {
            var images = new List<string>();

            if (vm.images.Any())
            {
                String uploadfolder = Path.Combine(_env.WebRootPath, "images");

                foreach (var image in vm.images)
                {
                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                    var filepath = Path.Combine(uploadfolder, filename);

                    try
                    {
                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }

                        images.Add(filename);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error copying file: {ex.Message}");
                        return View("Error");
                    }
                }
            }

            var product = new Product
            {
                Name = vm.Name,
                PublisherId = vm.NewPublisherName != null
                    ? _productsRepository.AddNewPublisher(new Publisher()
                    {
                        PublisherName = vm.NewPublisherName
                    })
                    : vm.PublisherId,
                Description = vm.Description,
                Price = vm.Price,
                Inventory = vm.Inventory,
                CategoryId = vm.CategoryId,
                StoreOwnerId = vm.StoreOwnerId,
                Images = images.Select(image => new Image { ImageName = image }).ToList()
            };

            _productsRepository.Add(product);

            return RedirectToAction(nameof(ManageProducts));
        }

        return View();
    }

    // POST: ManageProducts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create(
    //     [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
    //     Product product)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         _context.Add(product);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(ManageProducts));
    //         return RedirectToAction(nameof(Create));
    //     }
    //
    //     // ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     // ViewData["PublisherId"] =
    //     //     new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     // ViewData["StoreOwnerId"] =
    //     //     new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }

    // // GET: ManageProducts/Edit/5
    // public async Task<IActionResult> Edit(int? id)
    // {
    //     if (id == null || _context.Products == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var product = await _context.Products.FindAsync(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     ViewData["PublisherId"] =
    //         new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     ViewData["StoreOwnerId"] =
    //         new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }
    //
    // // POST: ManageProducts/Edit/5
    // // To protect from overposting attacks, enable the specific properties you want to bind to.
    // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id,
    //     [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
    //     Product product)
    // {
    //     if (id != product.ProductId)
    //     {
    //         return NotFound();
    //     }
    //
    //     if (ModelState.IsValid)
    //     {
    //         try
    //         {
    //             _context.Update(product);
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!ProductExists(product.ProductId))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }
    //
    //         return RedirectToAction(nameof(ManageProducts));
    //     }
    //
    //     ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
    //     ViewData["PublisherId"] =
    //         new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
    //     ViewData["StoreOwnerId"] =
    //         new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
    //     return View(product);
    // }

    // GET: ManageProducts/Delete/5
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: ManageProducts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);

        _productsRepository.Delete(product);

        return RedirectToAction(nameof(ManageProducts));
    }

    // private bool ProductExists(int id)
    // {
    //     return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
    // }
}