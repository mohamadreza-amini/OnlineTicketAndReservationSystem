using DataTransferObject;
using Mapster;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public abstract class ServiceBase<Entity, DTO, KeyTypeId> : IServiceBase<Entity, DTO, KeyTypeId> where Entity : class where DTO : BaseDTO<KeyTypeId> where KeyTypeId : struct
{
    public DTO TranslateToDTO(Entity entity)
    {
        return entity.Adapt<DTO>();
    }

    public Entity TranslateToEntity(DTO dto)
    {
        return dto.Adapt<Entity>();
    }
}
