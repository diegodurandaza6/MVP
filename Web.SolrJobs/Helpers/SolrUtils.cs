using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Web.SolrJobs.Helpers
{
    internal enum SearchResultFieldType
    {
        Display,
        Highlight
    }

    public class SolrUtils
    {
        private readonly static List<string> searchDisplayFields;
        private readonly static List<string> searchHighlightFields;

        static SolrUtils()
        {
            searchDisplayFields = GetSolrSearchResultFields(SearchResultFieldType.Display);
            searchHighlightFields = GetSolrSearchResultFields(SearchResultFieldType.Highlight);
        }

        public static List<string> GetSolrSearchDisplayFields()
        {
            return searchDisplayFields;
        }

        public static List<string> GetSolrSearchHighlightFields()
        {
            return searchHighlightFields;
        }

        private static List<string> GetSolrSearchResultFields(SearchResultFieldType searchResultFieldType)
        {
            List<string> result = null;

            var searchResultFields = GetSearchResultFields();
            IEnumerable<PropertyInfo> fields = new List<PropertyInfo>();

            if (searchResultFields.IsNotNullAndEmpty())
            {
                switch (searchResultFieldType)
                {
                    case SearchResultFieldType.Display:
                        fields = from p in searchResultFields
                                 from a in p.GetCustomAttributes(typeof(SearchResultAttribute), false)
                                 where ((SearchResultAttribute)a).Display
                                 select p;
                        break;

                    case SearchResultFieldType.Highlight:
                        fields = from p in searchResultFields
                                 from a in p.GetCustomAttributes(typeof(SearchResultAttribute), false)
                                 where ((SearchResultAttribute)a).Highlight
                                 select p;
                        break;

                    default:
                        break;
                }

                if (fields.IsNotNullAndEmpty())
                {
                    result = new List<string>(fields.Count());
                    fields.ToListEx().ForEach(p => result.Add((string)p.GetValue(null, null)));
                }
            }

            return result;
        }

        private static IEnumerable<PropertyInfo> GetSearchResultFields()
        {
            return typeof(SearchDocumentMetadataNew).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.GetCustomAttributes(typeof(SearchResultAttribute), false).Any());
        }
    }
}
