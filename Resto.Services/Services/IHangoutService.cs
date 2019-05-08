using System;
using System.Collections.Generic;
using Resto.Shared.Dtos;

namespace Resto.Services.Services
{
    public interface IHangoutService
    {
        IEnumerable<HangoutPlaceDto> Get();
        HangoutPlaceDto Get(Guid id);
        Guid Save(HangoutPlaceDto entity);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
