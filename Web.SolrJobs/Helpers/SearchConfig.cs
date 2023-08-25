using System.Configuration;

namespace Web.SolrJobs.Helpers
{
    public class SearchConfig
    {
        static SearchConfig()
        {
            NumberOfIndexThreads = 5;
            SearchServerName = "localhost";
            SearchServerPort = 80;
            SearchServerPath = "solr";
            SearchServerCore = "candidates_core";
            IndexQueName = "IndexQue";
            IndexThreadSleepTime = 10;
            SearchResultPageLimit = 500;
        }

        private const string HIGHLIGHTREGEXPATTERN = @"[-\w ,/\n\&quot;&apos;]{20,200}";
        private const string HIGHLIGHTPREFORMATTEXT = @"<em>";
        private const string HIGHLIGHTPOSTFORMATTEXT = @"</em>";
        private const int FRAGSIZE = 100;
        private const int MAXNUMBEROFSNIPPETS = 1;
        private const bool USEREGEXFRAGMENTER = true;

        const string DefaultDocTypes = "PDF,DOC,TXT";
        private string lockStr = "lock";

        public static int NumberOfIndexThreads { get; set; }

        public static string SearchServerName { get; set; }

        public static int SearchServerPort { get; set; }

        public static string SearchServerPath { get; set; }

        public static string SearchServerCore { get; set; }

        public static string IndexQueName { get; set; }

        public static int IndexThreadSleepTime { get; set; }

        public static int MaxNoSearchResults { get; set; }

        public static int MaxRetryCount { get; set; }

        public static int RetryTimeInMinutes { get; set; }


        public static bool UseRegexFragmenter
        {
            get
            {
                return SafeDataUtils.SafeBool(ConfigurationManager.AppSettings["UseRegexFragmenter"], USEREGEXFRAGMENTER);
            }
        }

        public static int FragmentSize
        {
            get
            {
                return SafeDataUtils.SafeInt(ConfigurationManager.AppSettings["FragmentSize"], FRAGSIZE);
            }
        }

        public static int MaxNumberOfSnippets
        {
            get
            {
                return SafeDataUtils.SafeInt(ConfigurationManager.AppSettings["MaxNumberOfSnippets"], MAXNUMBEROFSNIPPETS);
            }
        }

        public static string HighlightRegexPattern
        {
            get
            {
                return SafeDataUtils.SafeString(ConfigurationManager.AppSettings["HighlightRegexPattern"], HIGHLIGHTREGEXPATTERN);
            }
        }

        public static string HighlightPreFormatText
        {
            get
            {
                return SafeDataUtils.SafeString(ConfigurationManager.AppSettings["HighlightPreFormatText"], HIGHLIGHTPREFORMATTEXT);
            }
        }

        public static string HighlightPostFormatText
        {
            get
            {
                return SafeDataUtils.SafeString(ConfigurationManager.AppSettings["HighlightPostFormatText"], HIGHLIGHTPOSTFORMATTEXT);
            }
        }

        public static int SearchResultPageLimit { get; set; }

        public static string SolrUrl { get { return "http://{0}:{1}/{2}/{3}".FormatString(SearchServerName, SearchServerPort, SearchServerPath, SearchServerCore); } }

    }
}
