using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkAuthorMapper : BaseMapper<BLL.App.DTO.WorkAuthor, DAL.App.DTO.WorkAuthor>,
        IBaseMapper<BLL.App.DTO.WorkAuthor, DAL.App.DTO.WorkAuthor>
    {
        public WorkAuthorMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}