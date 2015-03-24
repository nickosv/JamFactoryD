using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JamFactory.Model;

namespace JamFactoryD.Controller.Facades
{
    public static class QualityInsurenceFacade
    {
        private static string _connect = "Server=ealdb1.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";
        /// <summary>
        /// Fetches Control and Activities from database
        /// </summary>
        /// 
        internal static List<Model.QualityControl> GetQualityInsurence(int productID)
        {
            List<Model.QualityControl> ControlList = new List<Model.QualityControl>();
            List<Model.QualityActivity> ActivityList = new List<Model.QualityActivity>();
            SqlConnection connect = new SqlConnection(_connect);
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("3_GetControl", connect);
                sqlCmd.Parameters.Add(new SqlParameter("@C_ProductID", productID));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    ActivityList.Add(new Model.QualityActivity(Convert.ToString(reader["AL_Title"]), Convert.ToString(reader["AL_Description"]), Convert.ToString(reader["AL_Details"]), Convert.ToDateTime(reader["AL_Time"])));
                    ControlList.Add(new Model.QualityControl(
                                    Convert.ToString(reader["c.Name"]),
                                    Convert.ToString(reader["c.Description"]), 
                                    Convert.ToString(reader["Person.Name"]), 
                                    Convert.ToString(reader["p.Variant"]), 
                                    Convert.ToString(reader["c.TimeCheck"]), 
                                    ActivityList));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }

            return ControlList;
        }
    }
}
