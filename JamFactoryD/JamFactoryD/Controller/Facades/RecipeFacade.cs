﻿using System;
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
                    products.Add(new Product((int)reader["ID"], (string)reader["Variant"], (int)reader["Size"], (int)reader["FruitContent"], Convert.ToDouble(reader["Price"])));
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

        internal static List<Recipe> GetRecipeByType(List<string> variants) {
            List<Recipe> recipes = new List<Recipe>();
            List<Recipe> NoDupRecipes = new List<Recipe>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipeByType", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Variant1", variants[0]));
                sqlCmd.Parameters.Add(new SqlParameter("@Variant2", variants[1]));
                sqlCmd.Parameters.Add(new SqlParameter("@Variant3", variants[2]));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    Recipe _recipe = new Recipe((int)reader["ID"], reader["Name"].ToString(), reader["Documentation"].ToString(), reader["Correspondence"].ToString());
                    recipes.Add(_recipe);  
                }
                Dictionary<string, int> dups = new Dictionary<string, int>();

                for (int i = 0; i < recipes.Count; i++){
			         if(!dups.ContainsKey(recipes[i].Name)){
                         dups.Add(recipes[i].Name, i);
                     }
			    }
                
                for (int i = 0; i < recipes.Count; i++) {
                    if (dups.ContainsValue(i)) {
                        NoDupRecipes.Add(recipes[i]);
                    }
                }
                
                //for (int i = 0; i < recipes.Count; i++) {
                //    if (!dups.ContainsValue(i)) {
                //        recipes.RemoveAt(i);
                //    }
                //}

            }
            catch (Exception e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                connect.Close();
                connect.Dispose();
            }

            return NoDupRecipes;
        }

        public static void SetTestVariant(int RecipeID)
        {
             SqlConnection connect = new SqlConnection(_connect);
            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("MoveRecipeFromDevelopment", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@RecipeID", RecipeID));
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                connect.Close();
                connect.Dispose();
            }
        }

        public static bool CheckTestVariant(int RecipeID)
        {
            SqlConnection connect = new SqlConnection(_connect);
            bool testVariant = new bool();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetTestVariantFromRecipeID", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@RecipeID", RecipeID));
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    testVariant = Convert.ToBoolean(reader["TestVariant"]);
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }
            return testVariant;
        }
    }
}
