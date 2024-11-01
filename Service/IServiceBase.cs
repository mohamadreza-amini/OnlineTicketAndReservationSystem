using DataTransferObject;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceBase<Entity, DTO, KeyTypeId> where Entity : class where DTO : BaseDTO<KeyTypeId> where KeyTypeId : struct
    {
        DTO TranslateToDTO(Entity entity);
        Entity TranslateToEntity(DTO dto);

    }
}
