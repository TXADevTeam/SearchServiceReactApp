using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SearchService.Model;
using SearchService.Model.Models;

namespace SearchService.Mock
{
    public class SearchServiceMock 
    {
        public readonly SearchResult[] data;

        public SearchServiceMock()
        {
            data = new[]
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
                new SearchResult() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Oi-Qaragai Lesnaya Skazka",
                    Description = "Самым популярным центром семейного отдыха и досуга этим летом стал горный курорт OI-QARAGAI LESNAYA SKAZKA.",
                    Address = "г. Алматы, ущелье Ой-Карагай, 1",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue4.png"},
                new SearchResult() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Грузинский двор на Жандосова",
                    Description = "Еще одним популярным рестораном лета на интернет-портале RestoLife.kz, предлагающий один из лучших шашлыков в городе, стал Грузинский двор.",
                    Address = "г. Алматы, ул. Жандосова 27б (уг. Радостовца)",
                    Created = DateTime.Now,
                    MainPhoto = $"/images/venue5.png"}
            };
        }       
    }
}
