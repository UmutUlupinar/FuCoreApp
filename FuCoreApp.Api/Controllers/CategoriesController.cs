using AutoMapper;
using FuCoreApp.Api.DTOs;
using FuCoreApp.Core.Models;
using FuCoreApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuCoreApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _catService;
        private IMapper _mapper;

        public CategoriesController(ICategoryService catService, IMapper mapper)
        {
            _catService = catService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            
            var cat =await _catService.Where(s => s.IsDeleted != true);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(cat));
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _catService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(cat));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto catDto)
        {
            var newCat = await _catService.AddAsync(_mapper.Map<Category>(catDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCat));                                                               //status201
        }

        [HttpPut]
        public IActionResult Update(CategoryDto catDto)
        {
            //catDto'dan kullanıcı kaynaklı update geldi. Catbul'a ise update metodu üzerinden date & by özellikleri eklendi.
            //catbul üzerinden update gerçekleşip cat'e atıldı.

            Task<Category> catBul = _catService.GetByIdAsync(catDto.ID);
            catBul.Result.Name=catDto.Name;
            var cat = _catService.Update(catBul.Result);
            //return NoContent();
            return Ok(_mapper.Map<CategoryDto>(cat));
        }

        [HttpDelete("{id:int}")]
         public IActionResult Remove(int id)
        {
            var cat = _catService.GetByIdAsync(id).Result;
            cat.IsDeleted = true;
            _catService.Update(cat);

           // _catService.Remove(cat);
            return NoContent();
        }

        [HttpGet("{id:int}/product")]

        public async Task<IActionResult> GetWithProductByIdAsync(int id)
        {
            var cat = await _catService.GetWithProductByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDto>(cat));
        }

    }
}
