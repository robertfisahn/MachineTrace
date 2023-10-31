using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineTrace.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoryService.Create(category);
            return RedirectToAction(nameof(Create));
        }
    }
}
