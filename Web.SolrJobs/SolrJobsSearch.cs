using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Web.SolrJobs;
using Web.SolrJobs.Helpers;
 
namespace Web.SolrJobsClient 
{
    public class SolrJobsSearch
    {
        private static readonly string perFieldSnippetCountExpr = @"f.{0}.hl.snippets";
        private static readonly string approximateSearchTermRegex = @"(?s)(?<={0}).+?(?={1})";
        private ISolrOperations<SearchDocumentResult> solrInstance
        {
            get
            {
                return SolrServerConnection.SolrSearchInstance();
            }
        }

        #region public function

        public SearchResults ExecuteSearchAsSearchResult(IndexedSearchOption searchOption, out string holder)
        {
            var totalItems = 0;
            var pageNumber = searchOption.PageNumber;
            var pageSize = searchOption.PageSize;
            return ExecuteSearchAsSearchResult(searchOption, pageNumber, pageSize, out totalItems, out holder);
        }
        public List<SearchDocumentResultForView> ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems, out string holder)
        {
            holder = null;
            var result = ExecuteSearchInternal(searchOption, pageNumber, pageSize, out totalItems);
            return result;
        }
        public SearchResults ExecuteSearchAsSearchResult(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems, out string holder)
        {
            holder = null;
            SearchResults searchResults = null;
            List<SearchDocumentResultForView> searchResultCollection = null;
            try
            {
                var result = ExecuteSearchInternal(searchOption, pageNumber, pageSize, out totalItems);
                searchResultCollection = new List<SearchDocumentResultForView>();

                if (result.IsNullAndEmpty())
                {
                    holder = "Search does not yield any results";// for parameter: {0}".FormatString(ObjectUtils.Dump(searchOption)));
                    return searchResults;
                }

                foreach (var searchResultDoc in result)
                {
                    if (searchResultDoc.Snippets.IsNullAndEmpty())
                        continue;

                    var snippet = searchResultDoc.Snippets.First();
                    var searchResult = new SearchDocumentResultForView();
                    // searchResult.candidateid = SafeDataUtils.SafeInt(searchResultDoc.id);
                    searchResult.HitCount = SafeDataUtils.SafeInt(searchResultDoc.HitCount); // This field is not calculated
                    searchResult.Score = SafeDataUtils.SafeInt(searchResultDoc.RelevanceScore);
                    searchResult.results = searchResultDoc.results;
                    searchResultCollection.Add(searchResult);
                }

                if (searchResultCollection.IsNotNullAndEmpty())
                {
                    searchResults = new SearchResults();
                    searchResults.SearchResultCollection = searchResultCollection;
                    searchResults.TotalResultsFound = totalItems;
                    // searchResults.results = searchResultCollection;
                    searchResults.HighlightPreFormat = HttpUtility.HtmlEncode(SearchConfig.HighlightPreFormatText);
                    searchResults.HighlightPostFormat = HttpUtility.HtmlEncode(SearchConfig.HighlightPostFormatText);
                }

                //Log.Trace("Returning from YLO.Service.Legacy.Search with {0} results".FormatString(searchResultCollection.Count));
                return searchResults;
            }
            catch (Exception ex)
            {
                totalItems = 0;
                holder = "Error executing the Search. Server error";// - for parameter: {0}".FormatString(ObjectUtils.Dump(searchOption));
                return null;
            }
        }

        public ISolrQuery BuildSearchCriteria(IndexedSearchOption searchOption)
        {
            var queryList = new List<ISolrQuery>();

            if (string.IsNullOrEmpty(searchOption.JobTitle) == false)
            {
                #region Boolean search 
                string filterBy = searchOption.JobTitle;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(' ');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.jobtitle, "*" + filterVal + "*") { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.AND));
                 
                //var exactTextQuery = new SolrQueryByField(SearchDocumentMetadataNew.FileContent, searchOption.JobTitle) { Quoted = searchOption.JobTitle.IsEnclosedInQuotes() };
                 
                //var exactTextQuery = new SolrQueryByField(SearchDocumentMetadataNew.jobtitle, "*"+searchOption.JobTitle+"*") { Quoted = false };
                //queryList.Add(exactTextQuery);

                //queryList.Add(exactTextQuery);
                #endregion
            } 
            if (string.IsNullOrEmpty(searchOption.jobIds) == false)
            { 
            }

            if (string.IsNullOrEmpty(searchOption.Tags) == false)
            {
                #region Boolean search
                var exactTextQuery = new SolrQueryByField(SearchDocumentMetadataNew.File_Content, searchOption.Tags.ToString()) { Quoted = true };
                //  var exactTextQuery = new SolrQueryByField(SearchDocumentMetadataNew._Tags, "*" + searchOption.Tags + "*") { Quoted = false };
                queryList.Add(exactTextQuery);
                #endregion
            }
            if (searchOption.CategoryId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.CategoryId, searchOption.CategoryId.ToString());
                queryList.Add(State);
            }
            


            if (string.IsNullOrEmpty(searchOption.location) == false)
            {

                string filterBy = searchOption.location;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(' ');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew._location, "*" + filterVal + "*") { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.AND));
                 
            }

            if (Convert.ToInt64(searchOption.salertchangeId) > 0)
            {
                if (Convert.ToInt64(searchOption.MinSalary) > 0)
                { 
                    var exactTextQuery = new SolrQueryByRange <decimal>("MinSalary", Convert.ToInt64(searchOption.MinSalary), Convert.ToInt64(searchOption.MaxSalary));
                    queryList.Add(exactTextQuery);
                     
                }
            }
            if (Convert.ToInt64(searchOption.salertchangeId) > 0)
            {
                if (Convert.ToInt64(searchOption.MinSalary) > 0)
                { 
                    var MaxSalaryexactTextQuery = new SolrQueryByRange<decimal>("MaxSalary", Convert.ToInt64(searchOption.MinSalary), Convert.ToInt64(searchOption.MaxSalary));
                    queryList.Add(MaxSalaryexactTextQuery);
                }
            }

            if (searchOption.Days > 0)
            {
                DateTime d2 = DateTime.Now.AddDays(-searchOption.Days);

                var date1 = Convert.ToDateTime(d2);
                var date2 = Convert.ToDateTime(DateTime.Now.AddDays(1));




                var exactTextQuery = new SolrQueryByRange<DateTime>(SearchDocumentMetadataNew.created_date, Convert.ToDateTime(d2), Convert.ToDateTime(DateTime.Now.AddDays(1)));
                queryList.Add(exactTextQuery);
            }
             
            if (string.IsNullOrEmpty(searchOption.JobType) == false)
            {
                string filterBy = searchOption.JobType;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.jobtypeid, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }

            if (string.IsNullOrEmpty(searchOption.zipcode) == false)
            {
                string filterBy = searchOption.zipcode;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.zip_code, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }

            ISolrQuery query;
            if (queryList.Count > 0)
            {
                if (searchOption.SearchType == 1)
                {
                    query = new SolrMultipleCriteriaQuery(queryList, SolrMultipleCriteriaQuery.Operator.AND);
                }
                else
                {
                    query = new SolrMultipleCriteriaQuery(queryList, SolrMultipleCriteriaQuery.Operator.OR);
                }
            }
            else
                query = null;
            return query;
        }

        #endregion

        #region private function
        private static QueryOptions GetQueryOptions(int pageNumber, int pageSize, int AscDescId)
        {
            var queryOptions = new QueryOptions();

            if (pageNumber == 0)
                pageNumber = 1;
            queryOptions.Start = (pageNumber - 1) * pageSize;
            queryOptions.Rows = pageSize;

            queryOptions.AddFields(SolrUtils.GetSolrSearchDisplayFields().ToArray());

            queryOptions.Highlight = ConfigureHighlighOptions();
            if (AscDescId == 2)
            {
                queryOptions.OrderBy = new[] { new SortOrder("updated_date", Order.DESC) };
            }
            else
            {
                queryOptions.OrderBy = new[] { new SortOrder("updated_date", Order.ASC) };
            }

            var maxNumberOfSnippets = SearchConfig.MaxNumberOfSnippets;
            var extraParams = new Dictionary<string, string>();
            foreach (var fieldName in SolrUtils.GetSolrSearchHighlightFields())
            {
                var snippetExpr = perFieldSnippetCountExpr.FormatString(fieldName);
                extraParams.Add(snippetExpr, maxNumberOfSnippets.ToString());
            }

            queryOptions.ExtraParams = extraParams;

            return queryOptions;
        }

        private static HighlightingParameters ConfigureHighlighOptions()
        {
            var highlights = new HighlightingParameters();
            highlights.Fields = SolrUtils.GetSolrSearchHighlightFields();
            highlights.HighlightMultiTerm = true;

            highlights.BeforeTerm = SearchConfig.HighlightPreFormatText;
            highlights.AfterTerm = SearchConfig.HighlightPostFormatText;
            highlights.Fragsize = SearchConfig.FragmentSize;

            if (!SearchConfig.UseRegexFragmenter)
            {
                highlights.Fragmenter = SolrHighlightFragmenter.Gap;
            }
            else
            {
                highlights.Fragmenter = SolrHighlightFragmenter.Regex;
                highlights.RegexSlop = 0.5;
                highlights.RegexMaxAnalyzedChars = highlights.Fragsize;
                highlights.MaxAnalyzedChars = -1;
                highlights.RegexPattern = SearchConfig.HighlightRegexPattern;
            }

            return highlights;
        }

        private static List<SearchDocumentResultForView> SolrToPocoSearchResults(SolrQueryResults<SearchDocumentResult> results, IndexedSearchOption searchOption)
        {
            var result = new List<SearchDocumentResultForView>(results.Count);
            foreach (var item in results)
            {
                var searchResultDoc = new SearchDocumentResultForView
                {
                    Snippets = GetHighlightedSnippets(results, item),
                    Score = item.Score,
                    results = item
                };

                ObjectUtils.CopyPropertyValues(item, searchResultDoc);
                searchResultDoc.Snippets = GetHighlightedSnippets(results, item);
                searchResultDoc.Score = item.Score;

                result.Add(searchResultDoc);
            }

            var maxScore = result.Max(s => s.Score);
            // result.ForEach(s => s.RelevanceScore = Convert.ToInt32(((s.Score / maxScore) * 100)));

            return result;
        }

        private static List<string> GetHighlightedSnippets(SolrQueryResults<SearchDocumentResult> results, SearchDocumentResult item)
        {
            List<string> snippetList = null;

            if (item.Description != null && results.Highlights != null && results.Highlights.ContainsKey(Convert.ToString(item.Description)))
            {
                var snippetsCollection = results.Highlights[item.Id.ToString()];
                var highlightFieldName = SolrUtils.GetSolrSearchHighlightFields().FirstOrDefault();

                if (highlightFieldName != null && snippetsCollection.ContainsKey(highlightFieldName))
                {
                    var snippets = snippetsCollection[highlightFieldName];

                    if (snippets.IsNullAndEmpty())
                        return snippetList;

                    snippetList = new List<string>(snippets.Count);
                    foreach (var snip in snippets)
                    {
                        snippetList.Add(snip ?? "".Trim());
                    }
                }
            }

            return snippetList;
        }

        private static int getHitCountForApproximateSearchSnippet(string input, string startDelim, string endDelim)
        {
            var hitCount = 0;
            var r = new Regex(string.Format(approximateSearchTermRegex, startDelim, endDelim), RegexOptions.IgnoreCase);
            if (r.IsMatch(input))
                hitCount = r.Matches(input).Count;
            return hitCount;
        }

        private List<SearchDocumentResultForView> ExecuteSearchInternal(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems)
        {

            List<SearchDocumentResultForView> result = new List<SearchDocumentResultForView>();
            totalItems = 0;

            var options = GetQueryOptions(pageNumber, pageSize, Convert.ToInt16(searchOption.AscDescId));
            var searchQuery = (AbstractSolrQuery)BuildSearchCriteria(searchOption);



            var results = solrInstance.Query(searchQuery, options);
            searchOption.TotalRecord = results.NumFound;
            totalItems = results.NumFound;
            if (searchOption.TotalRecord == 0)
            {
                return result;
            }
            result = SolrToPocoSearchResults(results, searchOption);
          
            return result;
        }
        #endregion
    }
}
