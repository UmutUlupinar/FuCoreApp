namespace FuCoreApp.Mvc.DTOs
{
    public class CategoryWithProductDto :CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }


    }
}
