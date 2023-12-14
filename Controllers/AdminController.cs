﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comic.Models;

namespace comic.Controllers
{
    public class AdminController : Controller
    {
        private readonly ComicContext _context;

        public AdminController(ComicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ManageProducts()
        {
            if (!User.Identity!.IsAuthenticated || !User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            
            var comicContext = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Publisher)
                .Include(p => p.StoreOwner);
            
            return View(await comicContext.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Publisher)
                .Include(p => p.StoreOwner)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId");
            ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
            Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageProducts));
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["PublisherId"] =
                new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
            ViewData["StoreOwnerId"] =
                new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
            return View(product);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["PublisherId"] =
                new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
            ViewData["StoreOwnerId"] =
                new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
            return View(product);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("ProductId,Name,PublisherId,Description,Price,Inventory,CategoryId,StoreOwnerId,CreatedAt,UpdatedAt")]
            Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(ManageProducts));
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["PublisherId"] =
                new SelectList(_context.Publishers, "PublisherId", "PublisherId", product.PublisherId);
            ViewData["StoreOwnerId"] =
                new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", product.StoreOwnerId);
            return View(product);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Publisher)
                .Include(p => p.StoreOwner)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ComicContext.Products'  is null.");
            }

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageProducts));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}