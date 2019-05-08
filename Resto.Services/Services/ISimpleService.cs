using System;
using System.Collections.Generic;
using Resto.Shared.Dtos;

namespace Resto.Services.Services
{
    public interface ISimpleService<TDto>
        where TDto : IDto
    {
        IEnumerable<TDto> Get();
        TDto Get(Guid id);
        Guid Save(TDto dto);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
