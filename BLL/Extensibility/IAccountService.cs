using System;
using System.Collections.Generic;
using System.Security.Claims;
using BLL.Extensibility.Dto;
using BLL.Extensibility.Infrastructure;

namespace BLL.Extensibility
{
    public interface IAccountService : IDisposable
    {
        OperationDetailsBll Create(UserDto userDto);

        ClaimsIdentity Authenticate(UserDto userDto);

        void SetInitialData(UserDto adminDto, List<string> roles);
    }
}
