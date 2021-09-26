using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain.App;
using Domain.Base;
using Microsoft.AspNetCore.Mvc.Testing;
using TestProject.Helpers;
using TestProject.IntegrationTestsApi.Types;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace TestProject.IntegrationTestsApi
{
    public class CharactersApiControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;


        public CharactersApiControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory,
            ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
            _client = factory
                .WithWebHostBuilder(builder => { builder.UseSetting("test_database_name", Guid.NewGuid().ToString()); })
                .CreateClient(new WebApplicationFactoryClientOptions()
                    {
                        AllowAutoRedirect = false
                    }
                );
        }

        [Fact]
        public async Task Api_Test__Adding_Character_To_Favorite_Character_List()
        {
            // ARRANGE
            const string characterUri = "/api/v1/Characters";
            const string registerUri = "/api/v1/Account/Register";
            var favoriteCharUri = "/api/v1/FavCharacterLists/User/";
            const string characterInListUri = "/api/v1/CharacterInLists";

            var jsonString = JsonHelper.SerializeToString(new RegisterForm
                {Email = "test@test.com", Password = "Test123.", UserName = "Test"}) ?? string.Empty;
            
            _testOutputHelper.WriteLine(jsonString);
            // ACT
            var postRegisterResponse = await _client.PostAsync(registerUri,
                new StringContent(jsonString, Encoding.UTF8, "application/json"));
            postRegisterResponse.EnsureSuccessStatusCode();

            var registerBody = await postRegisterResponse.Content.ReadAsStringAsync();
            var registerData = JsonHelper.DeserializeWithWebDefaults<LoginResponse>(registerBody);
            
            Assert.NotNull(registerData);

            favoriteCharUri += registerData!.UserName;
            var token = registerData!.Token;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var getCharacterResponse = await _client.GetAsync(characterUri);
            getCharacterResponse.EnsureSuccessStatusCode();

            var body = await getCharacterResponse.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);
            var data = JsonHelper.DeserializeWithWebDefaults<List<DAL.App.DTO.Character>>(body);
            
            Assert.NotNull(data);
            Assert.NotEmpty(data!);

            var character = data!.Find(c => $"{c.FirstName} {c.LastName}" == "Kristjan Mill");
            
            Assert.True(character != default);

            
            var getFavCharListResponse = await _client.GetAsync(favoriteCharUri);
            getFavCharListResponse.EnsureSuccessStatusCode();

            var favCharListBody = await getFavCharListResponse.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(favCharListBody);

            var favCharListData = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.FavCharacterList>(favCharListBody);
            Assert.NotNull(favCharListData);

            var relationString = JsonHelper.SerializeToString(new FavCharRelation()
                {FavCharacterListId = favCharListData!.Id, CharacterId = character!.Id}) ?? string.Empty;
            
           var postCharInListResponse = await _client.PostAsync(characterInListUri,
                new StringContent(relationString, Encoding.UTF8, "application/json"));
           postCharInListResponse.EnsureSuccessStatusCode();

           var charInListBody = await postCharInListResponse.Content.ReadAsStringAsync();
           var charInListData = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.CharacterInList>(charInListBody);
           
           Assert.NotNull(charInListData);
           Assert.True(charInListData!.CharacterId == character.Id && charInListData!.FavCharacterListId == favCharListData.Id);
        }
    }
}