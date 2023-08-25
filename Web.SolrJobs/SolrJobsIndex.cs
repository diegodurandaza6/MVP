using Code7248.word_reader;
using iTextSharp.text.pdf.parser;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Web.SolrJobs.Helpers;


namespace Web.SolrJobs
{
    public class SolrJobsIndex
    {
        private static ISolrOperations<SearchJobNew> solrInstance
        {
            get
            {
                return SolrServerConnection.SolrIndexInstance();
            }
        }

        public static bool IndexJob(SearchJobNew doc, long candidateId, bool commit = false)
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

        public static bool DeleteCandidateIndex(long candidateId)
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

        public static bool UpdateCompanyName(SearchJobNew doc)
        {
            bool check = true;
            try
            { 

                solrInstance.Commit(); 
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        public static bool CreateYourCompany(SearchJobNew doc)
        {
            bool check = true;
            try
            {

                List<SearchJobNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.created_by, doc.Id.ToString()));
                if (solrdoc != null && solrdoc.Count > 0)
                {
                    for (int i = 0; i < solrdoc.Count; i++)
                    { 
                        IndexJob(solrdoc[i], doc.Id, false);
                    }
                     
                }

                solrInstance.Commit();

            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }
        public static bool UpdateCandidateIndex(SearchJobNew doc)
        {
            bool check = true;
            try
            {

                List<SearchJobNew> solrdoc = solrInstance.Query(new SolrQueryByField(SearchDocumentMetadataNew.id, doc.Id.ToString()));
                if (solrdoc != null && solrdoc.Count > 0)
                {
                    //solrdoc = new List<SearchJobNew>();
                    //solrdoc.Add(new SearchJobNew());
                    solrdoc[0].Id = doc.Id;
                    solrdoc[0].jobstatusid = doc.jobstatusid;
                    solrdoc[0].updated_date = doc.updated_date;

                    IndexJob(solrdoc[0], doc.Id, false);
                }

                solrInstance.Commit();

            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
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


    }
}
