using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part2_PROG6221_ST10040092;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_PROG6221_ST10040092.Tests
{
    [TestClass()]
    public class RecipeMethodsTests
    {
        // Testing the method to assert true with total calories exceed 300
        [TestMethod]
        public void calcTotalCalories_AssertTrue()
        {
            // Arrange:  recipe ingredients with total calories higher than 300
            var recipeIngredients = new List<Ingredient>
            {
                new Ingredient { NameOfIngredient = "Sugar", CaloriesAmount = 210 },
                new Ingredient { NameOfIngredient = "Rice", CaloriesAmount = 1440 }
            };

            // prepared ingredients
            var recipe = new RecipeData { Ingredients = recipeIngredients };

          // calculate total calories
            double totalCalories = recipe.CalculateTotalCalories();

            // total calories exceed 300 Assert true
            Assert.IsTrue(totalCalories > 300);
        }

        //  assert false when total calories do not exceed 300
        [TestMethod]
        public void calcTotalCalories_AssertFalse()
        {
            // total calories not exceeding 300
            var recipeIngredients = new List<Ingredient>
            {
                new Ingredient { NameOfIngredient = "Sugar", CaloriesAmount = 50 },
                new Ingredient { NameOfIngredient = "Rice", CaloriesAmount = 100 }
            };

            // e prepared ingredients
            var recipe = new RecipeData { Ingredients = recipeIngredients };

            //  calculate total calories
            double totalCalories = recipe.CalculateTotalCalories();

            //total calories do not exceed 300
            Assert.IsFalse(totalCalories > 300);
        }
    }
}
