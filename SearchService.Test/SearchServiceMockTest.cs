using System;
using Xunit;
using SearchService.Model.Models;
using SearchService.Mock;
using System.Collections.Generic;
using SearchService.API.Services;

namespace SearchService.Test
{
    public class SearchServiceMockTest
    {
        [Fact]
        public void CheckConstructor()
        {
            SearchServiceMock mock = new SearchServiceMock();
            var service = new SearchServiceRealizer(mock.data);
            Assert.NotNull(service);
            Assert.Throws<ArgumentNullException>(() => new SearchServiceRealizer(null));
        }

        [Fact]
        public void CheckOnExceptions()
        {
            SearchServiceMock mock = new SearchServiceMock();
            var service = new SearchServiceRealizer(mock.data);
            Assert.Throws<ArgumentException>(() => service.GetSearchResult(string.Empty));
            Assert.Throws<ArgumentNullException>(() => service.GetSearchResult(null));
        }

        [Fact]
        public void CheckOnPositiveResults()
        {
            IEnumerable<SearchResult> data = FakeData();
            var service = new SearchServiceRealizer(data);
            var result = service.GetSearchResult(Guid.NewGuid().ToString());
            var result2 = service.GetSearchResult("ку");
            Assert.Empty(result);
            Assert.NotEmpty(result2);
        }

        public static SearchResult[] FakeData()
        {
            var data = new SearchResult[]
           {
               new SearchResult() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Abay",
                    Description = "Один из лучших ресторанов национальный кухни с колоритным интерьером на КОК-ТОБЕ и потрясающим панорамным видом открывает подборку",
                    Address = "г. Алматы, ул. Омаровой, 41/2 (Кок Тобе)",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue1.png"},
                new SearchResult() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Villa dei Fiori",
                    Description = "Изысканный ресторан итальянской кухни с высококлассным дизайном в VILLA BOUTIQUES & RESTAURANTS.",
                    Address = "г.Алматы, пр. Аль-Фараби, 140а",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue2.png"},
                new SearchResult() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "INZHU",
                    Description = "Авторская и средиземноморская кухня этого великолепного ресторана, вместе с панорамным видом, делает его одним из самых роскошных в городе.",
                    Address = "г. Алматы, ул. Омаровой, 41/2 (Кок Тобе)",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue3.png"},
           };
            return data;
        }
    }
}
