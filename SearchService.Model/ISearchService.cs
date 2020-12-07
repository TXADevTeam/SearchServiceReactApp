using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SearchService.Model.Models;

namespace SearchService.Model
{
    public interface ISearchService
    {
        IReadOnlyCollection<SearchResult> GetSearchResult(string word);
        Task<IReadOnlyCollection<SearchResult>> GetSearchResultAsync(string word, CancellationToken cancellationToken);
    }
}
