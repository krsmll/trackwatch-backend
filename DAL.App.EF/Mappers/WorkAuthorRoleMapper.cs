using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkAuthorRoleMapper : BaseMapper<DAL.App.DTO.WorkAuthorRole, Domain.App.WorkAuthorRole>,
        IBaseMapper<DAL.App.DTO.WorkAuthorRole, Domain.App.WorkAuthorRole>
    {
        public WorkAuthorRoleMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}