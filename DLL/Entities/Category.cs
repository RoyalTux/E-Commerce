// ReSharper disable once UnusedMember.Global

using System.Collections.Generic;

namespace DLL.Entities
{
    internal class Category
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
