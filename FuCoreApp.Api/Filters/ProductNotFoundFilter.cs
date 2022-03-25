using FuCoreApp.Api.DTOs;
using FuCoreApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FuCoreApp.Api.Filters
{
    public class ProductNotFoundFilter: ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault()!;      //! null kontrolünü kaldırdı. (int) object'i int'e çevirdi
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id'si {id} olan ürün bulunamadı!!!");       //// HATA VERDİ!!!
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }

    }
}
