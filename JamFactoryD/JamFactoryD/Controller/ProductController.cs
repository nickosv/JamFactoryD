using System;
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
        public List<string> GetRecipes() {
            recipes = RecipeFacade.GetRecipes();
            List<string> recipesString = new List<string>();
            // Adding ingredients to recipes
            foreach (Recipe recipe in recipes) {
                recipe.Ingredients = IngredientFacade.GetIngredientsFromRecipe(recipe);
            }

            return recipesString;
        }
    }
}
