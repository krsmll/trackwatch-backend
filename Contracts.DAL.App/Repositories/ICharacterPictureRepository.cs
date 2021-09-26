using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICharacterPictureRepository : IBaseRepository<CharacterPicture>, ICharacterPictureRepositoryCustom<CharacterPicture>
    {
    }
    
    public interface ICharacterPictureRepositoryCustom<TEntity>
    {
          
    }
}