using System;
using System.Collections.Generic;
using System.Security.Claims;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;

namespace ECommerce.BLL.Extensibility
{
    public interface IAccountService : IDisposable
    {
        OperationDetailsBll Create(UserDto userDto);

        ClaimsIdentity Authenticate(UserDto userDto);

        void SetInitialData(UserDto adminDto, List<string> roles);
    }
}
