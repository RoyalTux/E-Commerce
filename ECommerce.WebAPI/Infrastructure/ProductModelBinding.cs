using System.Web.Mvc;
using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.WebAPI.Infrastructure
{
    public class ProductModelBinding : IModelBinder
    {
        private const string SessionKey = "Product";

        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var product = (ProductDto)controllerContext.HttpContext.Session[SessionKey];

            if (product != null)
            {
                return product;
            }

            product = new ProductDto();
            if (true)
            {
                controllerContext.HttpContext.Session[SessionKey] = product;
            }

            return product;
        }
    }
}