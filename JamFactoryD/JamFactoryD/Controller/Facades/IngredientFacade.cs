﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JamFactory.Model;

namespace JamFactoryD.Controller.Facades {
    class IngredientFacade {

        private static string _connect = "Server=ealdb20.eal.local;" + "Database=EJL20_DB;" + "User Id=ejl20_usr;" + "Password=Baz1nga20";

        // Fetching recipes from DB
        internal static List<IngredientLine> GetIngredientsFromRecipe(Recipe recipe) {
            List<IngredientLine> ingredients = new List<IngredientLine>();

            SqlConnection connect = new SqlConnection(_connect);

            try {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("4_GetRecipes", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read()) {
                    Ingredient ingredient = new Ingredient((string)reader["Name"], (double)reader["Price"]);
                    ingredients.Add(new IngredientLine((int)reader["Amount"], recipe, ingredient);
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