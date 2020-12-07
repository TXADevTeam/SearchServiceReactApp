using System;
using System.Collections.Generic;
using System.Text;

namespace SearchService.Model.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public string MainPhoto { get; set; }
    }
}
