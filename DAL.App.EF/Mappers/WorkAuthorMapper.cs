using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkAuthorMapper : BaseMapper<DAL.App.DTO.WorkAuthor, Domain.App.WorkAuthor>,
        IBaseMapper<DAL.App.DTO.WorkAuthor, Domain.App.WorkAuthor>
    {
        public WorkAuthorMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}