using System;
using System.Collections.Generic;

namespace Web.SolrMyCandidate.Helpers
{
    [Serializable]
    public class SearchResults
    {
        private List<SearchDocumentResultForView> _searchResultCollection;

        public SearchResults()
        {
            _searchResultCollection = new List<SearchDocumentResultForView>();

        }

        public List<SearchDocumentResultForView> SearchResultCollection { get; set; }
        public int TotalResultsFound { get; set; }
        public string HighlightPreFormat { get; set; }
        public string HighlightPostFormat { get; set; }

        public SearchDocumentResult results { get; set; }
    }
}
