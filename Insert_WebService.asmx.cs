using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for TestService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestService : System.Web.Services.WebService
    {
           [WebMethod]
        public int InsertDetail(string PersonName, string PersonCity)
        {
            int retRecord = 0;
            try
            {
                
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDetail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("PersonName", SqlDbType.VarChar, 100).Value = PersonName;
                        cmd.Parameters.Add("PersonCity", SqlDbType.VarChar, 100).Value = PersonCity;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        retRecord = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return retRecord;
        }
    }
}
