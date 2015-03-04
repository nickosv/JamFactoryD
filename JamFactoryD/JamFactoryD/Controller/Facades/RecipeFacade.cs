using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JamFactory.Model;

namespace JamFactoryD.Controller.Facades {
    static class RecipeFacade {

        private static string _connect = "Server=ealdb20.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";

        // Fetching recipes from DB
        internal static List<JamFactory.Model.Recipe> GetRecipes() {
            List<JamFactory.Model.Recipe> recipes = new List<JamFactory.Model.Recipe>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipes", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    recipes.Add(new Recipe((int)reader["ID"], reader["Name"].ToString(), reader["Documentation"].ToString(), reader["Correspondance"].ToString()));
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                connect.Close();
                connect.Dispose();
            }

            return recipes;
        }
    }
}
