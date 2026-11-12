using CafeApp.Data;
using CafeApp.Models;
using CafeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace CafeApp.Controllers
{
    public class BaristaController : Controller
    {
        private readonly DataContext _context;
        public BaristaController(DataContext cont)
        {
            _context = cont;
        }

        // BARISTA LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");

            if (Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("OrderList");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Barista model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập đầy đủ Email và Mật khẩu!";
                TempData["Error Message"] = "Vui lòng nhập đầy đủ Email và Mật khẩu!";
                return View(model);
            }

            var barista = _context.FindByEmail(model.Email);

            if (barista != null && barista.Password == model.Password)
            {
                barista.IsAuthenticated = true;
                HttpContext.Session.SetString("IsAuth", "True");
                TempData["SuccessMessage"] = Messages.LoginSuccess;
                return RedirectToAction("OrderList");
            }
            else
            {
                TempData["ErrorMessage"] = Messages.InvalidLogin;
                TempData["Error Message"] = Messages.InvalidLogin;
            }

            return View(model);
        }

        // BARISTA LOGOUT
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAuth");
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = Messages.LogoutSuccess;
            return RedirectToAction("Login");
        }

        // CREATE NEW BARISTA
        [HttpGet]
        public IActionResult Signup()
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");

            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("Email,Password")] Barista barista)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                var existingBarista = _context.FindByEmail(barista.Email!);

                if (existingBarista == null)
                {
                    _context.Add(barista);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = Messages.BaristaCreated;
                    return RedirectToAction(nameof(OrderList));
                }
                else
                {
                    TempData["ErrorMessage"] = Messages.BaristaExists;
                    TempData["Error Message"] = Messages.BaristaExists;
                }
            }
            return View(barista);
        }

        // HÀM RIÊNG TÍNH TỔNG SỐ ĐƠN VÀ DOANH THU
        private (int totalOrders, decimal totalRevenue) CalculatePaidOrdersSummary(IEnumerable<Order> orders)
        {
            var paidOrders = orders.Where(o => o.IsPaid).ToList();
            int totalCount = paidOrders.Count;
            decimal totalSum = paidOrders.Sum(o => o.TotalPrice);
            
            return (totalCount, totalSum);
        }

        // SHOW ORDERS
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");

            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            _context.ClearNullOrders();

            var orders = await _context.Orders.OrderByDescending(o => o.OrderId).ToListAsync();
            var (totalCount, totalRevenue) = CalculatePaidOrdersSummary(orders);

            ViewBag.TotalPaidOrders = totalCount;
            ViewBag.TotalRevenue = totalRevenue;
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int? id)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");

            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                TempData["ErrorMessage"] = Messages.OrderNotFound;
                return RedirectToAction("OrderList");
            }

            List<OrderProduct> orderProducts = await _context.OrderProducts
                .Where(op => op.OrderId == id)
                .ToListAsync();

            List<int> productIds = orderProducts.Select(op => op.ProductId).ToList();

            List<Product> products = await _context.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            Dictionary<int, int> productIdQuantityPairs = orderProducts
                .ToDictionary(op => op.ProductId, op => op.Quantity);

            var tuple = Tuple.Create(order, products, productIds, productIdQuantityPairs);
            return View(tuple);
        }

        // GET: Barista/ProductList
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");

            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                TempData["ErrorMessage"] = Messages.OrderNotFound;
                return RedirectToAction("OrderList");
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int orderId)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuth");
            if (!Convert.ToBoolean(isAuthenticated))
            {
                return RedirectToAction("Login");
            }

            List<OrderProduct> orderProducts = await _context.OrderProducts
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
            _context.OrderProducts.RemoveRange(orderProducts);

            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = Messages.OrderDeleted;
            }

            return RedirectToAction("OrderList", "Barista");
        }
    }
}
