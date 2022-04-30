using AutoMapper;
using FuCoreApp.Mvc.ApiService;
using FuCoreApp.Mvc.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuCoreApp.Mvc.Controllers
{
    public class CategoryApiController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryApiController(CategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var cat = _categoryApiService.GetAllAsync().Result;
            return View(_mapper.Map<IEnumerable<CategoryDto>>(cat));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async  Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.AddAsync(categoryDto);
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }
   
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
       public async Task<IActionResult> Update(CategoryDto categoryDto) 
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
