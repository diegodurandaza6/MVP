using System.Collections.Generic;

namespace Web.SolrJobs.Helpers
{
    public class SearchDocumentResultForView : SearchDocumentResult
    {
        public List<string> Snippets { get; set; }

        public int HitCount { get; set; }

        public double Score { get; set; }

        public int RelevanceScore { get; set; }


        public SearchDocumentResult results { get; set; }

    }

}
