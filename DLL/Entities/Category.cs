using System.Collections.Generic;

// ReSharper disable once UnusedMember.Global
namespace DLL.Entities
{
    internal class Category
    {
        public Category()
        {
            this.Items = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Items { get; set; }
    }
}
