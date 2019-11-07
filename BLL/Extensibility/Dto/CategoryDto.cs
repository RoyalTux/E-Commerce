using System.Collections.Generic;

namespace BLL.Extensibility.Dto
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            this.Items = new List<ProductDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductDto> Items { get; set; }
    }
}
