// ReSharper disable once UnusedMember.Global

using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    public class CategoryDataEntity
    {
        public CategoryDataEntity()
        {
            this.SubCategoryDataEntities = new List<CategoryDataEntity>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public virtual CategoryDataEntity ParentCategoryDataEntity { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryDataEntity> SubCategoryDataEntities { get; set; }
    }
}
