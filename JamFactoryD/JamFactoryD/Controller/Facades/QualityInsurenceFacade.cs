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
    class QualityInsurenceFacade
    {
        private static string _connect = "Server=ealdb1.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";
        /// <summary>
        /// Fetches Control and Activities from database
        /// </summary>
        /// 
        internal static List<Model.QualityControl> GetQualityInsurence()
        {
            List<Model.QualityControl> ControlList = new List<Model.QualityControl>();
            SqlConnection connect = new SqlConnection(_connect);
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("3_GetControl", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    
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
