using SolrNet.Attributes;

namespace Web.SolrJobs.Helpers
{
    public class SearchDocumentResult : SearchJobNew
    {
        [SolrField("score")]
        public double Score { get; set; }
    }
}
