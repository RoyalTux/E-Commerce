using System.Collections.Generic;

// ReSharper disable once UnusedMember.Global
// ReSharper disable CommentTypo
namespace DLL.Extensibility.Entities
{
    public class Category
    {
        public Category()
        {
            this.SubCategories = new List<SubCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}