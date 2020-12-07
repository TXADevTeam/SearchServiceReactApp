using System;
using Xunit;
using SearchService.API;
using SearchService.Model.Models;
using SearchService.Model;
using SearchService.API.Controllers;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace SearchService.Test
{
    public class SearchControllerTest
    {
        [Fact]
        public void CheckConstructor()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
            Assert.NotNull(controller);
        }

        [Fact]
        public void Get_BadRequestCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            var res1 = controller.Get(null);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public void Get_NoContentCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResult("ра")).Returns(Array.Empty<SearchResult>());
            var res = controller.Get("ра");
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public void Get_OkStatusCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            SearchResult[] data = new SearchResult[]
               {
                  new SearchResult {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Abay",
                    Description = "Один из лучших ресторанов национальный кухни с колоритным интерьером на КОК-ТОБЕ и потрясающим панорамным видом открывает подборку",
                    Address = "г. Алматы, ул. Омаровой, 41/2 (Кок Тобе)",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue1.png"},
               };

            A.CallTo(() => service.GetSearchResult("на")).Returns(data);
            var res4 = controller.Get("на");
            Assert.IsType<OkObjectResult>(res4.Result);
        }

        [Fact]
        public async Task Get2_BadRequestCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);

            var res1 = await controller.Get2(null, CancellationToken.None);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public async Task Get2_NoContentCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResultAsync("ра", CancellationToken.None)).ReturnsLazily(() => Array.Empty<SearchResult>());
            var res = await controller.Get2("ра", CancellationToken.None);
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public async Task Get2_OkStatusCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            SearchResult[] data1 = new SearchResult[]
               {
                  new SearchResult {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Abay",
                    Description = "Один из лучших ресторанов национальный кухни с колоритным интерьером на КОК-ТОБЕ и потрясающим панорамным видом открывает подборку",
                    Address = "г. Алматы, ул. Омаровой, 41/2 (Кок Тобе)",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue1.png"},
               };

            A.CallTo(() => service.GetSearchResultAsync("ов", CancellationToken.None)).ReturnsLazily(() => data1);
            var res4 = await controller.Get2("ов", CancellationToken.None);
            Assert.IsType<OkObjectResult>(res4.Result);
        }
    }
}
