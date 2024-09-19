using ECommerce.Business.Abstract;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    // [Authorize(Roles = "Admin,Editor")]
    public class AdminController : Controller
    {
        //[Authorize(Roles = "Admin")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[Authorize(Roles = "Editor")]
        //public IActionResult Index2()
        //{
        //    return View();
        //}

        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var items = await _productService.GetAllByCategoryAsync(category);

            var model = new ProductListViewModel
            {
                Products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View(model);
        }
    }
}
