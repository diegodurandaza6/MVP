using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Impl;
using System.Configuration;
using Web.SolrMyCandidate.Helpers;

namespace Web.SolrMyCandidate
{
    public class SearchServerConnection
    {
        private readonly static SearchServerConnection connection = new SearchServerConnection();

        private SearchServerConnection()
        {
             
            string url = ConfigurationManager.AppSettings["mvp_mycandidate"];

            Startup.Init<SearchDocumentNew>(new SolrConnection(url) { Timeout = 500000 });
            Startup.Init<SearchDocumentResult>(new SolrConnection(url) { Timeout = 500000 });
        }

        public SearchServerConnection Instance
        {
            get
            {
                return connection;
            }
        }

        private ISolrOperations<SearchDocumentNew> solrIndexInstance()
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchDocumentNew>>();
            return solr;
        }

        public static ISolrOperations<SearchDocumentNew> SolrIndexInstance()
        {
            return connection.solrIndexInstance();
        }

        private ISolrOperations<SearchDocumentResult> solrSearchInstance()
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchDocumentResult>>();
            return solr;
        }

        public static ISolrOperations<SearchDocumentResult> SolrSearchInstance()
        {
            return connection.solrSearchInstance();
        }
    }
}
