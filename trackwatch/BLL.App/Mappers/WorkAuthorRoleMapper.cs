using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkAuthorRoleMapper : BaseMapper<BLL.App.DTO.WorkAuthorRole, DAL.App.DTO.WorkAuthorRole>,
        IBaseMapper<BLL.App.DTO.WorkAuthorRole, DAL.App.DTO.WorkAuthorRole>
    {
        public WorkAuthorRoleMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}