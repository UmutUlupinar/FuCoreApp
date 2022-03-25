using AutoMapper;
using FuCoreApp.Api.DTOs;
using FuCoreApp.Api.Filters;
using FuCoreApp.Core.Models;
using FuCoreApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuCoreApp.Api.Controllers
{   [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _proService;
        private IMapper _mapper;

        public ProductController(IProductService proService, IMapper mapper)
        {
            _proService = proService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pro= await _proService.Where(s=>s.IsDeleted!=true);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(pro));
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetByid(int id)
        {
            var pro = await _proService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(pro));
        }

        [HttpPost]

        public async Task<IActionResult> Save(ProductDto proDto)
        {
            var pro = await _proService.AddAsync(_mapper.Map<Product>(proDto));
           // return Ok((_mapper.Map<ProductDto>(pro));
            return Created(string.Empty, _mapper.Map<ProductDto>(pro));
        }

        [HttpPut]

        public IActionResult Update(ProductDto proDto)
        {
            var pro = _proService.Update(_mapper.Map<Product>(proDto));
            return NoContent();
        }


        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pro = _proService.GetByIdAsync(id).Result;
            pro.IsDeleted = true;
            _proService.Update(pro);
           // _proService.Remove(pro);
            return NoContent();

        }

        [HttpGet("{id:int}/Category")]  // buraya yazılan "id" ile parametre "id" aynı olmalı

        public async Task<IActionResult> GetWithCategoryByIdAsync(int id)
        {
            var pro= await _proService.GetWithByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(pro));
        }

    }
}
