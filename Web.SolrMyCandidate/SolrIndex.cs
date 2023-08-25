using Code7248.word_reader;
using iTextSharp.text.pdf.parser;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Web.SolrMyCandidate.Helpers;

namespace Web.SolrMyCandidate
{
    public class SolrIndex
    {
        private static ISolrOperations<SearchDocumentNew> solrInstance
        {
            get
            {
                return SearchServerConnection.SolrIndexInstance();
            }
        }

        public static bool IndexCandidate(SearchDocumentNew doc, long candidateId, bool commit = false)
        {
            try
            {
                var addParam = new AddParameters();
                addParam.CommitWithin = 10000;
                solrInstance.Add(doc, addParam);
                if (commit)
                {
                    solrInstance.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IndexCandidate(SearchDocumentNew doc, long candidateId, out string errorMsg, bool commit = false)
        {
            errorMsg = null;
            try
            {
                var indexDocList = new List<SearchDocumentNew>();
                indexDocList.Add(doc);

                var addParam = new AddParameters();
                addParam.CommitWithin = 10000;
                solrInstance.AddRange(indexDocList, addParam);
                if (commit)
                {
                    solrInstance.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public static void AddUpdateSkills(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {


                solrdoc[0].updated_date = DateTime.Now;


                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }

        public static void UpdateWorkExperience(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {

                solrdoc[0].current_job_title = SearchDocument.current_job_title;

                //solrdoc[0].current_employer = SearchDocument.current_employer;

                solrdoc[0].updated_date = DateTime.Now;


                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }

        public static void UpdateEducation(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {

                // solrdoc[0].qualification = SearchDocument.qualification;
                solrdoc[0].updated_date = DateTime.Now;
                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }

        public static void UpdateResumeContent(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {

                solrdoc[0].Resume_Content = SearchDocument.Resume_Content;
                // solrdoc[0].ActiveProfileId = SearchDocument.ActiveProfileId;
                solrdoc[0].updated_date = DateTime.Now;
                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }
        public static void LastActive(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {


                // solrdoc[0].LastActive =Convert.ToString(DateTime.Now);
                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }

        public static void AddUpdateProfileLocation(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {

                solrdoc[0].first_name = SearchDocument.first_name;
                solrdoc[0].mobile = SearchDocument.mobile;
                // solrdoc[0].CurrentLocation = SearchDocument.CurrentLocation;       
                // solrdoc[0].yrs_of_exp = SearchDocument.yrs_of_exp;
                // solrdoc[0].Skills = SearchDocument.Skills;
                solrdoc[0].Resume_Content = SearchDocument.Resume_Content;
                // solrdoc[0].ActiveProfileId = SearchDocument.ActiveProfileId;
                solrdoc[0].updated_date = DateTime.Now;

                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }


        public static void AddUpdateLocation(SearchDocumentNew SearchDocument)
        {
            List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, SearchDocument.id.ToString()));
            if (solrdoc != null && solrdoc.Count > 0)
            {

                solrdoc[0].first_name = SearchDocument.first_name;
                solrdoc[0].mobile = SearchDocument.mobile;
                
                solrdoc[0].updated_date = DateTime.Now;


                IndexCandidate(solrdoc[0], Convert.ToInt64(SearchDocument.id), false);
            }
        }

        public static string GetTxtFromFile(string filePath)
        {
            string ext = System.IO.Path.GetExtension(filePath);
            if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
            {
                return DocFileReader(filePath);
            }
            if (ext.ToLower() == ".rtf")
            {
                return RtfFileReader(filePath);
            }
            if (ext.ToLower() == ".pdf")
            {
                return PdfFileReader(filePath);
            }

            return "";

        }

        private static string RtfFileReader(string filePath)
        {
            string text = "";
            RichTextBox rt = new RichTextBox();
            rt.LoadFile(filePath, System.Windows.Forms.RichTextBoxStreamType.RichText);

            foreach (string line in rt.Lines)
            {
                text += line;
            }
            rt.Dispose();
            return text;
        }

        private static string PdfFileReader(string filePath)
        {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(filePath);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
            return text;
        }

        public static string DocFileReader(string filePath)
        {
            try
            {
                TextExtractor extractor = new TextExtractor(filePath);
                var text = extractor.ExtractText();
                return text;
            }
            catch (Exception)
            {
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.FileStream f = System.IO.File.Create(filePath);
                    f.Close();
                }
                TextExtractor extractor = new TextExtractor(filePath);
                var text = extractor.ExtractText();
                return text;
                // return string.Empty;
            }
        }

        public static bool DeleteCandidateIndex(string candidateId)
        {
            bool check = true;
            try
            {

                ResponseHeader r = solrInstance.Delete(candidateId.ToString());
                solrInstance.Commit();

            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }


        public static bool UpdateCandidateIndex(long candidateId, string first_name, string last_name, string mobile, string profile_image)
        {
            bool check = true;
            try
            {
                
                List<SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, candidateId.ToString()));
                if (solrdoc != null && solrdoc.Count > 0)
                {

                    solrdoc[0].first_name = first_name;
                    solrdoc[0].last_name = last_name;
                    solrdoc[0].mobile = mobile;
                    solrdoc[0].profile_image = profile_image;
                    solrdoc[0].updated_date = DateTime.Now;
                  
                    IndexCandidate(solrdoc[0], candidateId, false);
                }
                 
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        public static bool UpdatefavouriteCandidate(string current_job_title, string location, long candidateId, bool commit = false)
        {
            bool check = true;
            try
            {
                List<Web.SolrMyCandidate.Helpers.SearchDocumentNew> solrdoc = solrInstance.Query(new SolrQueryByField(Web.SolrMyCandidate.Helpers.SearchDocumentMetadataNew.CandidateId, candidateId.ToString()));
                for (int i = 0; i < solrdoc.Count; i++)
                {
                    solrdoc[0].current_job_title = current_job_title;
                    solrdoc[0].Job_location = location;
                    solrdoc[0].updated_date = DateTime.Now;
                      

                    IndexCandidate(solrdoc[0], candidateId, false);
                } 

            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

    }


}
