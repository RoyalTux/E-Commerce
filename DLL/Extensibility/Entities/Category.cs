// ReSharper disable once UnusedMember.Global
// ReSharper disable CommentTypo

using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Entities
{
    public class Category
    {
        public Category()
        {
            this.SubCategory = new List<Category>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public string Name { get; set; }

        public ICollection<Category> SubCategory { get; set; }
    }
}