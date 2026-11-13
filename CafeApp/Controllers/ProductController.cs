using CafeApp.Services;
using CafeApp.Data;
using CafeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Product/Create")]
        public IActionResult Create()
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Product/Create")]
        public async Task<IActionResult> Create([Bind("ProductId,Name,ImageSrc,Details,Price")] Product product)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = Messages.ProductCreated;
                TempData["Success Message"] = Messages.ProductCreated;
                return RedirectToAction("ProductList", "Barista");
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,ImageSrc,Details,Price")] Product product)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

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
                TempData["SuccessMessage"] = Messages.ProductUpdated;
                TempData["Success Message"] = Messages.ProductUpdated;
                return RedirectToAction("ProductList", "Barista");
            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login", "Barista");
            }

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = Messages.ProductDeleted;
                TempData["Success Message"] = Messages.ProductDeleted;
            }
            return RedirectToAction("ProductList", "Barista");
        }
    }
}
