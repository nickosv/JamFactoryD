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

                while (reader.Read() && reader.HasRows)
                {
                    ActivityList.Add(new Model.QualityActivity(Convert.ToString(reader["AL_Title"]), Convert.ToString(reader["AL_Description"]), Convert.ToString(reader["AL_Details"]), Convert.ToDateTime(reader["AL_Time"])));
                    ControlList.Add(new Model.QualityControl(
                                    Convert.ToString(reader["C_Name"]),
                                    Convert.ToString(reader["Description"]),
                                    Convert.ToString(reader["Name"]),
                                    Convert.ToString(reader["Variant"]),
                                    Convert.ToString(reader["TimeCheck"])
                                    ) { ActivityList = ActivityList });

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

        internal static int GetProductsFromRecipe(Recipe recipe)
        {
            int productID = 0;
            SqlConnection connect = new SqlConnection(_connect);
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetProductsFromRecipeID", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@RecipeID", recipe.ID));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    productID = (int)reader["ID"];
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
            return productID;
        }

    }
}
