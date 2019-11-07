using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ItemsListViewModel
    {
        public IEnumerable<ProductView> Items { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}