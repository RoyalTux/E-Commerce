using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    public class CartDataEntity
    {
        public CartDataEntity()
        {
            this.CartLineDataEntities = new List<CartLineDataEntity>();
        }

        public int Id { get; set; }

        public ICollection<CartLineDataEntity> CartLineDataEntities { get; set; }

        public UserProfileDataEntity UserProfile { get; set; }
    }
}
