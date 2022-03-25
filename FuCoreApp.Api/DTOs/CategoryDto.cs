using System.ComponentModel.DataAnnotations;

namespace FuCoreApp.Api.DTOs
{
    public class CategoryDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage="{0} alani gereklidir.")]
        public string Name { get; set; }
    }
}
