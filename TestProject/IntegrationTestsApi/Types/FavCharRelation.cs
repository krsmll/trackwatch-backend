using System;

namespace TestProject.IntegrationTestsApi.Types
{
    public class FavCharRelation
    {
        public Guid CharacterId { get; set; }
        public Guid FavCharacterListId { get; set; }
    }
}