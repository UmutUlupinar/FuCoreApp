using AutoMapper;
using FuCoreApp.Mvc.ApiService;
using FuCoreApp.Mvc.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FuCoreApp.Mvc.Controllers
{
    public class ProductApiController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;

        public ProductApiController(ProductApiService productApiService, IMapper mapper)
        {
            _productApiService = productApiService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var pro= _productApiService.GetAllAsync().Result;
            return View(_mapper.Map<IEnumerable<ProductDto>>(pro));
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(productDto);
                return RedirectToAction("Index");
            }
            return View(productDto);
        }
        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var pro= await _productApiService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDto>(pro));
        }

        [HttpPost]

        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(productDto);
                return RedirectToAction("Index");
            }
            return View(productDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
