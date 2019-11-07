using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductView> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}