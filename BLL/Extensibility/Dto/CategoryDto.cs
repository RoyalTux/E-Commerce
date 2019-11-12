using System.Collections.Generic;
using DLL.Extensibility.Entities;

namespace BLL.Extensibility.Dto
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            this.SubCategories = new List<SubCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
