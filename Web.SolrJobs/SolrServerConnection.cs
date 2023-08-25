using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Impl;
using System.Configuration;
using Web.SolrJobs.Helpers;

namespace Web.SolrJobs
{
    public class SolrServerConnection
    {
        private readonly static SolrServerConnection connection = new SolrServerConnection();

        private SolrServerConnection()
        { 
            string url = ConfigurationManager.AppSettings["SolrJobsUrl"];
            //string url = "http://142.11.206.49:8984/solr/dev_jobs";
            Startup.Init<SearchJobNew>(new SolrConnection(url) { Timeout = 500000 });
            Startup.Init<SearchDocumentResult>(new SolrConnection(url) { Timeout = 500000 });
        }

        public SolrServerConnection Instance
        {
            get
            {
                return connection;
            }
        }

        private ISolrOperations<SearchJobNew> solrIndexInstance()
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchJobNew>>();
            return solr;
        }

        public static ISolrOperations<SearchJobNew> SolrIndexInstance()
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
