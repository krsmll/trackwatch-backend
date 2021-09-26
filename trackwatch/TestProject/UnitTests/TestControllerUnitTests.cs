using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain.App;
using Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Controllers;
using WebApp.ViewModels.Test;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using Moq;

namespace TestProject.UnitTests
{
    public class TestControllerUnitTests
    {
        private readonly TestController _testController;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly AppDbContext _ctx;
        private readonly Mock<HttpClientAdapter> _adapter;

        // ARRANGE - common
        public TestControllerUnitTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            // set up db context for testing - using InMemory db engine
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // provide new random database name here
            // or parallel test methods will conflict each other
            optionBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _ctx = new AppDbContext(optionBuilder.Options);
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<TestController>();

            // create the mocked adapter
            _adapter = new Mock<HttpClientAdapter>();

            _adapter.Setup(x =>
                x.GetPageLength(
                    It.Is<string>(a => a == "https://postimees.ee"))).Returns(1024);
            _adapter.Setup(x =>
                x.GetPageLength(
                    It.Is<string>(a => a == "https://delfi.ee"))).Returns(2024);

            // SUT
            _testController = new TestController(logger, _ctx, _adapter.Object);
        }

        [Fact]
        public async Task Action_Test__Returns_ViewModel()
        {
            var result = await _testController.Test();
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);

            var vm = viewResult!.Model;
            Assert.IsType<TestViewModel>(vm);

            var testVm = vm as TestViewModel;
            Assert.NotNull(testVm!.Characters);
            Assert.Equal(0, testVm.Characters.Count);
        }

        [Fact]
        public async Task Action_Test__Returns_ViewModel_With_Data()
        {
            await SeedData(5);

            var result = await _testController.Test();
            Assert.NotNull(result);

            var testVm = (result as ViewResult)?.Model as TestViewModel;
            Assert.NotNull(testVm);

            Assert.Equal(5, testVm!.Characters.Count);
        }

        [Fact]
        public async Task Action_Test__Delete_Works()
        {
            await SeedData(2);
            
            var testVm = (await _testController.Test() as ViewResult)?.Model as TestViewModel;
            Assert.Equal(2, testVm!.Characters.Count);

            var first = testVm!.Characters.First();
            _ctx.Characters.Remove(first);
            await _ctx.SaveChangesAsync();

            testVm = (await _testController.Test() as ViewResult)?.Model as TestViewModel;
            Assert.Equal(1, testVm!.Characters.Count);

            var exists =
                await _ctx.Characters.FirstOrDefaultAsync(c => c.Id == first.Id) != default;
            Assert.False(exists);
        }

        [Fact]
        public async Task Action_Test__Update_Works()
        {
            await SeedData();
            var first = ((await _testController.Test() as ViewResult)?.Model as TestViewModel)!.Characters.First();

            first.FirstName = "Test";
            first.LastName = "Successful";

            _ctx.Characters.Update(first);
            await _ctx.SaveChangesAsync();

            var exists =
                await _ctx.Characters.FirstOrDefaultAsync(c => c.FirstName == "Test" && c.LastName == "Successful") !=
                default;
            Assert.True(exists);
        }

        private async Task SeedData(int count = 1)
        {
            var r = new Random();
            for (int i = 0; i < count; i++)
            {
                _ctx.Characters.Add(new Character
                {
                    FirstName = Path.GetRandomFileName().Replace(".", ""),
                    LastName = Path.GetRandomFileName().Replace(".", ""),
                    Age = r.Next(1, 100),
                    Birthdate = new DateTime(r.Next(1900, 2021), r.Next(1, 12), r.Next(1, 28))
                });
            }

            await _ctx.SaveChangesAsync();
        }
    }

    // public class CountGenerator : IEnumerable<object[]>
    // {
    //     private static List<object[]> _data
    //     {
    //         get
    //         {
    //             var res = new List<Object[]>();
    //             for (int i = 1; i <= 100; i++)
    //             {
    //                 res.Add(new object[] {i});
    //             }
    //
    //             return res;
    //         }
    //     }
    //
    //     public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
    //     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    // }
}