namespace FuCoreApp.Api.DTOs
{
    public class CategoryWithProductDto :CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }


    }
}
