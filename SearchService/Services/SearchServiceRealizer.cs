using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SearchService.Model;
using SearchService.Model.Models;

namespace SearchService.API.Services
{
    public class SearchServiceRealizer : ISearchService
    {
        private readonly SearchResult[] _data;

        public SearchServiceRealizer(SearchResult[] data)
        {
            _data = data?.ToArray() ?? throw new ArgumentNullException(nameof(data));
        }

        public SearchServiceRealizer(IEnumerable<SearchResult> data)
        {
            _data = data?.ToArray() ?? throw new ArgumentNullException(nameof(data));
        }

        public IReadOnlyCollection<SearchResult> GetSearchResult(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Length == 0)
            {
                throw new ArgumentException("Should not be empty.", nameof(word));
            }

            return _data
                .Where(w => w.Name.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                            w.Description.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                            w.Address.Contains(word, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Task<IReadOnlyCollection<SearchResult>> GetSearchResultAsync(string word, CancellationToken cancellationToken)
        {
            var result = GetSearchResult(word);
            return Task.FromResult(result);
        }
    }
}
