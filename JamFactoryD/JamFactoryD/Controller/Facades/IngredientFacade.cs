using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JamFactory.Model;

namespace JamFactoryD.Controller.Facades {
    class IngredientFacade {

        private static string _connect = "Server=ealdb1.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";

        /// <summary>
        /// Fetches ingredientLines with ingredient from database
        /// </summary>
        /// <param name="recipe">The recipe you want the ingredients from</param>
        /// <returns>A List of ingredientLines with recipes</returns>
        internal static List<IngredientLine> GetIngredientsFromRecipe(Recipe recipe) {
            List<IngredientLine> ingredients = new List<IngredientLine>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetIngredientsAmountFromRecipeID", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@RecipeID", recipe.ID));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    Ingredient ingredient = new Ingredient((string)reader["Name"], Convert.ToDouble(reader["Price"]));
                    ingredients.Add(new IngredientLine((int)reader["Amount"], recipe, ingredient));
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                connect.Close();
                connect.Dispose();
            }

            return ingredients;
        }

        public static List<Ingredient> GetIngredient(int Price, double Amount, string Name)
        {
            SqlConnection connect = new SqlConnection(_connect);
            List<Ingredient> ingredients = new List<Ingredient>();
            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipeResources", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Price", Price));
                sqlCmd.Parameters.Add(new SqlParameter("@Amount", Amount));
                sqlCmd.Parameters.Add(new SqlParameter("@Name", Name));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                 while (reader.Read()) {
                       ingredients.Add(new Ingredient((string)reader["Price"], Convert.ToDouble(reader["Amount"]), Convert.ToInt32(reader["Name"])));
                 }
            } 
            catch (Exception e) {
                throw e;
            }
            finally {
                connect.Close();
                connect.Dispose();
            }
            return ingredients;
        }
    }
}
