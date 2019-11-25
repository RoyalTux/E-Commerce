using System;
using System.Security.Claims;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;

namespace ECommerce.BLL.Extensibility
{
    public interface IAccountService : IDisposable
    {
        OperationDetailsBll Create(UserProfileDto userDto);

        ClaimsIdentity Authenticate(UserProfileDto userDto);
    }
}
