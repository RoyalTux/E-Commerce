using System.Collections.Generic;

namespace ECommerce.WebAPI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductView> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}