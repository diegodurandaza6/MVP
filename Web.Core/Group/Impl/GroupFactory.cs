using System;
using System.Data;
using System.Linq;
using Web.Model.Candidate;
using Web.Model.Group;

namespace Web.Core.Group.Impl
{
    public class GroupFactory
    {

        internal void GetGrouplist(GroupListModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new GroupViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        Status = Convert.ToInt64(row["StatusId"]),
                                        Name = Convert.ToString(row["Name"]),
                                        Ids = EncryptDecrypt.encrypt(row["Id"].ToString()).ToString(),
                                        Date = Convert.ToDateTime(row["createdDate"]).ToString("dd MMM yyyy"),
                                        Description = Convert.ToString(row["Description"])
                                    }).ToList();
            }

        }

        internal void details(GroupViewModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["createdDate"]).ToString("dd MMM yyyy");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.CandidateCollection = (from DataRow row in ds.Tables[1].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["candidateid"].ToString())),
                                                 Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"]),
                                                 Title = Convert.ToString(row["Title"]),
                                                 Phone = Convert.ToString(row["PhoneNo"]),
                                                 Email = Convert.ToString(row["Email"]),
                                                 location = Convert.ToString(row["Location"]),
                                                 Zipcode = Convert.ToString(row["Zipcode"]),

                                             }).ToList();
            }


        }

        internal void GetGroupById(GroupViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Name = dt.Rows[0]["Name"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();

            }
        }
    }
}
