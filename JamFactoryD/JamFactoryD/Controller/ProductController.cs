﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using JamFactory.Model;
using JamFactoryD.Controller.Facades;

// Controller for group D
namespace JamFactoryD.Controller {
    class ProductController {

        List<Recipe> recipes;
        public Recipe selectedRecipe;

        /// <summary>
        /// Fetches recipes and ingredients from database
        /// </summary>
        /// <returns>List of recipes with ingredients in a string format</returns>
        public List<string> GetRecipes() {
            recipes = RecipeFacade.GetRecipes();
            List<string> recipesString = new List<string>();
            // Adding ingredients to recipes
            foreach (Recipe recipe in recipes) {
                List<string> ingredients = new List<string>();
                recipe.Ingredients = IngredientFacade.GetIngredientsFromRecipe(recipe);

                foreach (IngredientLine ingredient in recipe.Ingredients) {
                    ingredients.Add(ingredient.Ingredient.Name);
                }

                recipesString.Add(recipe.Name + " | " + string.Join(", ", ingredients));
            }

            return recipesString;
        }

        /// <summary>
        /// Opens the details window for recipe
        /// </summary>
        /// <param name="index">The index for a recipe in recipes list</param>
        internal void ShowDetailsForRecipe(int index) {
            try {
                // Sets the clicked recipe to selected to use when the window is opened
                selectedRecipe = recipes[index];
            }
            catch (Exception e) {
                System.Windows.MessageBox.Show(e.Message);
            }

            // Making the view and showing it
            View.Group_D.RecipeDetailsWindow view = new View.Group_D.RecipeDetailsWindow();
            view.Show();

            // Binds this controller to the view so it can fetch selected recipe later
            view.SetController(this);
        }

        /// <summary>
        /// Recipes basic information
        /// </summary>
        /// <returns>Dictonary with recipe info</returns>
        internal Dictionary<string, string> GetSelectedRecipe() {
            Dictionary<string,string> recipe = new Dictionary<string,string>();
            recipe.Add("Name", selectedRecipe.Name);
            recipe.Add("Documentation", selectedRecipe.Documentation);
            recipe.Add("Correspondence", selectedRecipe.Correspondence);
            return recipe;
        }
        
        /// <summary>
        /// Fetches products from database by recipe
        /// </summary>
        /// <returns>Dictionary with Variant and Size from each product</returns>
        internal Dictionary<string, int> GetProducts() {
            Dictionary<string, int> productList = new Dictionary<string, int>();
            List<Product> products = RecipeFacade.GetProductsFromRecipe(selectedRecipe);

            foreach (Product product in products) {
                productList.Add(product.Variant, product.Size);
            }

            return productList;
        }

        public List<string> GetRecipeByType(List<string> parameters) {

            List<string> recipesString = new List<string>();
            recipes.Clear();

            recipes = RecipeFacade.GetRecipeByType(parameters);

            // Adding ingredients to recipes
            foreach (Recipe recipe in recipes) {
                List<string> ingredients = new List<string>();
                recipe.Ingredients = IngredientFacade.GetIngredientsFromRecipe(recipe);

                foreach (IngredientLine ingredient in recipe.Ingredients) {
                    ingredients.Add(ingredient.Ingredient.Name);
                }
                string stringRecipe = recipe.Name + " | " + string.Join(", ", ingredients);

                recipesString.Add(stringRecipe);

                // Removes Dups
                //if (!recipesString.Contains(stringRecipe)) {
                //    recipesString.Add(stringRecipe);
                    
                //}
            }

            return recipesString;
        }

        public List<string> GetIngredient()
        {
            List<Ingredient> ingredients = IngredientFacade.GetIngredient(selectedRecipe.ID);
            List<string> ingredientsString = new List<string>();

            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsString.Add(ingredient.Name);
            } 

            return ingredientsString;
        }

        public void SetTestVariant()
        {
            RecipeFacade.SetTestVariant(selectedRecipe.ID);
        }

        public bool CheckTestVariant(){
            return RecipeFacade.CheckTestVariant(selectedRecipe.ID);
        }
    }
}
