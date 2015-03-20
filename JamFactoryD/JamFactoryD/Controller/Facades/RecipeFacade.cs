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

        private static string _connect = "Server=ealdb1.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";

        /// <summary>
        /// Fetches all recipes form database
        /// </summary>
        /// <returns>A list of recipes</returns>
        internal static List<Recipe> GetRecipes() {
            List<Recipe> recipes = new List<Recipe>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipes", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    recipes.Add(new Recipe((int)reader["ID"], reader["Name"].ToString(), reader["Documentation"].ToString(), reader["Correspondence"].ToString()));
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

        /// <summary>
        /// Fetches products from database
        /// </summary>
        /// <param name="recipe">The recipe the products belongs to</param>
        /// <returns>A List of products</returns>
        internal static List<Product> GetProductsFromRecipe(Recipe recipe) {
            List<Product> products = new List<Product>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetProductsFromRecipeID", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@RecipeID", recipe.ID));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    products.Add(new Product((string)reader["Variant"], (int)reader["Size"], (int)reader["FruitContent"], Convert.ToDouble(reader["Price"])));
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                connect.Close();
                connect.Dispose();
            }

            return products;
        }

        internal static List<Recipe> GetRecipeByType(string variant) {
            List<Recipe> recipes = new List<Recipe>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipeByType", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Variant", variant));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    recipes.Add(new Recipe((int)reader["ID"], reader["Name"].ToString(), reader["Documentation"].ToString(), reader["Correspondence"].ToString()));
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
