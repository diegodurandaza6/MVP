using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Utils;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text.RegularExpressions;
using Web.SolrClient.Helpers;

namespace Web.SolrClient
{

    public class SolrSearch
    {
        private static readonly string perFieldSnippetCountExpr = @"f.{0}.hl.snippets";
        private static readonly string approximateSearchTermRegex = @"(?s)(?<={0}).+?(?={1})";

        private ISolrOperations<SearchDocumentResult> solrInstance
        {
            get
            {
                return SearchServerConnection.SolrSearchInstance();
            }
        }

        #region public function


        public List<SearchDocumentResultForView> ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems, out string holder)
        {
            holder = null;
            var result = ExecuteSearchInternal(searchOption, pageNumber, pageSize, out totalItems);
            return result;
        }


        public List<SearchDocumentResultForView> ExecuteSearchAsSearchResult_Admin(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems, out string holder)
        {
            holder = null;
            var result = ExecuteSearchInternal_Admin(searchOption, pageNumber, pageSize, out totalItems);
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
                    //searchResult.candidateid = SafeDataUtils.SafeInt(searchResultDoc.id);
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
            if (string.IsNullOrEmpty(searchOption.Name) == false)
            {
                string filterBy = searchOption.Name;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(' ');
                foreach (string filterVal in filterValues)
                {
                    if (filterVal != "" || filterVal != null || filterVal != " ")
                    {
                        filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.full_name, "*" + filterVal + "*") { Quoted = false });
                    }
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }

            if (string.IsNullOrEmpty(searchOption.Phone) == false)
            {
                var mobile = new SolrQueryByField(SearchDocumentMetadataNew.mobile, searchOption.Phone.ToString()) { Quoted = true };
                queryList.Add(mobile);
            } 

            if (string.IsNullOrEmpty(searchOption.Email) == false)
            {
                var Email = new SolrQueryByField(SearchDocumentMetadataNew.email, "*" + searchOption.Email.ToString() + "*") { Quoted = false };
                queryList.Add(Email);
            }
            if (string.IsNullOrEmpty(searchOption.UserIdByTitle) == false)
            {
                string filterBy = searchOption.UserIdByTitle;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.id, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            if (string.IsNullOrEmpty(searchOption.Title) == false)
            {
                List<SolrQueryByField> _filterForProduct = new List<SolrQueryByField>();

                _filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.current_job_title, searchOption.Title) { Quoted = true });
                _filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.DesiredTitle_1, searchOption.Title) { Quoted = true });
                _filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.DesiredTitle_2, searchOption.Title) { Quoted = true });
                queryList.Add(new SolrMultipleCriteriaQuery(_filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            //if (string.IsNullOrEmpty(searchOption.Title) == false)
            //{
            //    var _Title = new SolrQueryByField(SearchDocumentMetadataNew.current_job_title, searchOption.Title.ToString());
            //    queryList.Add(_Title);
            //}


            //if (string.IsNullOrEmpty(searchOption.Title) == false)
            //{
            //    string filterBy = searchOption.Title;
            //    List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
            //    string[] filterValues;
            //    filterValues = filterBy.Split(' ');
            //    foreach (string filterVal in filterValues)
            //    {
            //        if (filterVal != "" || filterVal != null || filterVal != " ")
            //        {
            //            filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.current_job_title, "*" + filterVal + "*") { Quoted = false });
            //        }
            //    }
            //    queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            //}
            if (string.IsNullOrEmpty(searchOption.Keyword) == false)
            {
                var Keyword = new SolrQueryByField(SearchDocumentMetadataNew.File_Content, searchOption.Keyword.ToString()) { Quoted = true };
                queryList.Add(Keyword);
            }

            if (string.IsNullOrEmpty(searchOption.location) == false)
            {
                string filterBy = searchOption.location;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(' ');
                foreach (string filterVal in filterValues)
                {
                   var filterVal1 = filterVal.Replace(",", "");
                    if (searchOption.Zip != filterVal1)
                    {
                        filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.location, "*" + filterVal1 + "*") { Quoted = false });
                    } 
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));


            }
            if (string.IsNullOrEmpty(searchOption.ZipCode) == false)
            {
                string filterBy = searchOption.ZipCode;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.Zip_Code, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            if (string.IsNullOrEmpty(searchOption.Jobtype) == false)
            {
                string filterBy = searchOption.Jobtype;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.job_TypeId, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            if (string.IsNullOrEmpty(searchOption.Jobcatagory) == false)
            {
                string filterBy = searchOption.Jobcatagory;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.Industry_Id, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            } 
            if (string.IsNullOrEmpty(searchOption.groupcandidateId) == false)
            {
                string filterBy = searchOption.groupcandidateId;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.id, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }


            if (string.IsNullOrEmpty(searchOption.experienceIds) == false)
            {
                string filterBy = searchOption.experienceIds;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.experienceid, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            } 

            //if (searchOption.experienceId > 0)
            //{
            //    var State = new SolrQueryByField(SearchDocumentMetadataNew.experienceid, searchOption.experienceId.ToString());
            //    queryList.Add(State);
            //}
            if (searchOption.IndustryId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.Industry_Id, searchOption.IndustryId.ToString());
                queryList.Add(State);
            }
            if (string.IsNullOrEmpty(searchOption.educationlavel) == false)
            {

                string filterBy = searchOption.educationlavel;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.EducationlevelName, filterVal) { Quoted = true });
                }

                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));

                //searchOption.educationlavel = searchOption.educationlavel.Trim();
                //var State = new SolrQueryByField(SearchDocumentMetadataNew.EducationlevelName, searchOption.educationlavel.ToString());
                //queryList.Add(State);
            }
            if (searchOption.ProfileCheckId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.ProfileCheckId, searchOption.ProfileCheckId.ToString());
                queryList.Add(State);
            } 
            if (searchOption.StatusId == 1)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.StatusId, searchOption.StatusId.ToString());
                queryList.Add(State);
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

        public ISolrQuery BuildSearchCriteria_Admin(IndexedSearchOption searchOption)
        {
            var queryList = new List<ISolrQuery>();

            if (string.IsNullOrEmpty(searchOption.Name) == false)
            {
                string filterBy = searchOption.Name;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(' ');
                foreach (string filterVal in filterValues)
                {
                    if (filterVal != "" || filterVal != null || filterVal != " ")
                    {
                        filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.full_name, "*" + filterVal + "*") { Quoted = false });
                    }
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }


            if (string.IsNullOrEmpty(searchOption.Phone) == false)
            {
                var mobile = new SolrQueryByField(SearchDocumentMetadataNew.mobile, searchOption.Phone.ToString()) { Quoted = true };
                queryList.Add(mobile);
            }


            if (string.IsNullOrEmpty(searchOption.Email) == false)
            {
                var Email = new SolrQueryByField(SearchDocumentMetadataNew.email, "*" + searchOption.Email.ToString() + "*") { Quoted = false };
                queryList.Add(Email);
            }


            if (string.IsNullOrEmpty(searchOption.Title) == false)
            {
                var _Title = new SolrQueryByField(SearchDocumentMetadataNew.current_job_title, searchOption.Title.ToString());
                queryList.Add(_Title);
            }


            if (string.IsNullOrEmpty(searchOption.Keyword) == false)
            {
                var Keyword = new SolrQueryByField(SearchDocumentMetadataNew.File_Content, searchOption.Keyword.ToString()) { Quoted = true };
                queryList.Add(Keyword);
            }


            if (string.IsNullOrEmpty(searchOption.ZipCode) == false)
            {
                string filterBy = searchOption.ZipCode;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.Zip_Code, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            else
            {
                if (string.IsNullOrEmpty(searchOption.location) == false)
                {
                    string filterBy = searchOption.location;
                    List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                    string[] filterValues;
                    filterValues = filterBy.Split(' ');
                    foreach (string filterVal in filterValues)
                    {
                        filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.location, "*" + filterVal + "*") { Quoted = false });
                    }
                    queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.AND));


                }
            }
            if (string.IsNullOrEmpty(searchOption.Jobtype) == false)
            {
                string filterBy = searchOption.Jobtype;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.job_TypeId, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }
            if (string.IsNullOrEmpty(searchOption.Jobcatagory) == false)
            {
                string filterBy = searchOption.Jobcatagory;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.Industry_Id, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }

            if (string.IsNullOrEmpty(searchOption.groupcandidateId) == false)
            {
                string filterBy = searchOption.groupcandidateId;
                List<SolrQueryByField> filterForProduct = new List<SolrQueryByField>();
                string[] filterValues;
                filterValues = filterBy.Split(',');
                foreach (string filterVal in filterValues)
                {
                    filterForProduct.Add(new SolrQueryByField(SearchDocumentMetadataNew.id, filterVal) { Quoted = false });
                }
                queryList.Add(new SolrMultipleCriteriaQuery(filterForProduct, SolrMultipleCriteriaQuery.Operator.OR));
            }

            if (searchOption.experienceId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.experienceid, searchOption.experienceId.ToString());
                queryList.Add(State);
            }
            if (searchOption.IndustryId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.Industry_Id, searchOption.IndustryId.ToString());
                queryList.Add(State);
            }
            if (string.IsNullOrEmpty(searchOption.educationlavel) == false)
            {
                searchOption.educationlavel = searchOption.educationlavel.Trim();
                var State = new SolrQueryByField(SearchDocumentMetadataNew.EducationlevelName, searchOption.educationlavel.ToString());
                queryList.Add(State);
            }
            if (searchOption.ProfileCheckId > 0)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.ProfileCheckId, searchOption.ProfileCheckId.ToString());
                queryList.Add(State);
            }

            if (searchOption.StatusId == 1)
            {
                var State = new SolrQueryByField(SearchDocumentMetadataNew.StatusId, searchOption.StatusId.ToString());
                queryList.Add(State);
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
        private static QueryOptions GetQueryOptions(int pageNumber, int pageSize)
        {
            var queryOptions = new QueryOptions();
            if (pageNumber == 0)
                pageNumber = 1;
            queryOptions.Start = (pageNumber - 1) * pageSize;
            queryOptions.Rows = pageSize;
            queryOptions.AddFields(SolrUtils.GetSolrSearchDisplayFields().ToArray());
            queryOptions.Highlight = ConfigureHighlighOptions();
            //queryOptions.OrderBy = new[] { new SortOrder("updated_date", Order.DESC) };
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

        private static QueryOptions GetQueryOptions_Admin(int pageNumber, int pageSize)
        {
            var queryOptions = new QueryOptions();
            if (pageNumber == 0)
                pageNumber = 1;
            queryOptions.Start = (pageNumber - 1) * pageSize;
            queryOptions.Rows = pageSize;
            queryOptions.AddFields(SolrUtils.GetSolrSearchDisplayFields().ToArray());
            queryOptions.Highlight = ConfigureHighlighOptions();
             queryOptions.OrderBy = new[] { new SortOrder("updated_date", Order.DESC) };
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

            if (results.Highlights != null && results.Highlights.ContainsKey(item.id))
            {
                var snippetsCollection = results.Highlights[item.id];
                var highlightFieldName = SolrUtils.GetSolrSearchHighlightFields().FirstOrDefault();

                if (highlightFieldName != null && snippetsCollection.ContainsKey(highlightFieldName))
                {
                    var snippets = snippetsCollection[highlightFieldName];

                    if (snippets.IsNullAndEmpty())
                        return snippetList;

                    snippetList = new List<string>(snippets.Count);
                    snippetList.AddRange(snippets.Select(snip => snip ?? "".Trim()));
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

            var options = GetQueryOptions(pageNumber, pageSize);
            var searchQuery = (AbstractSolrQuery)BuildSearchCriteria(searchOption);

            var results = solrInstance.Query(searchQuery, options);


            searchOption.TotalRecord = results.NumFound;
            if (searchOption.TotalRecord == 0)
            {
                return result;
            }
            result = SolrToPocoSearchResults(results, searchOption);
             
            totalItems = count(1, 3000, searchOption);
            return result;
        }

        private List<SearchDocumentResultForView> ExecuteSearchInternal_Admin(IndexedSearchOption searchOption, int pageNumber, int pageSize, out int totalItems)
        {

            List<SearchDocumentResultForView> result = new List<SearchDocumentResultForView>();
            totalItems = 0;

            var options = GetQueryOptions_Admin(pageNumber, pageSize);
            var searchQuery = (AbstractSolrQuery)BuildSearchCriteria_Admin(searchOption); 
            var results = solrInstance.Query(searchQuery, options);
            searchOption.TotalRecord = results.NumFound;
            if (searchOption.TotalRecord == 0)
            {
                return result;
            }
            result = SolrToPocoSearchResults(results, searchOption);

            result = result.OrderByDescending(a => a.updated_date).ToList();

            totalItems = count_Admin(1, 500, searchOption);
            return result;
        }


        public Int32 count(int pageNumber, int total, IndexedSearchOption searchOption)
        {
            var options = GetQueryOptions(pageNumber, total);
            var searchQuery = (AbstractSolrQuery)BuildSearchCriteria(searchOption); 

            var results = solrInstance.Query(searchQuery, options);
            searchOption.TotalRecord = results.NumFound;
            return results.Count();
        }
        public Int32 count_Admin(int pageNumber, int total, IndexedSearchOption searchOption)
        {
            var options = GetQueryOptions(pageNumber, total);
            var searchQuery = (AbstractSolrQuery)BuildSearchCriteria_Admin(searchOption); 
            var results = solrInstance.Query(searchQuery, options);
            searchOption.TotalRecord = results.NumFound;
            return results.Count();
        }
        #endregion


    }
}
