using System;
using System.Collections.Generic;

namespace Part2_PROG6221_ST10040092
{
    public class RecipeData
    {
        public string Name { get; set; } // Property to hold the name of the recipe
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();  // Listing to hold the ingredients of the recipe
        public List<RecipeStep> Steps { get; set; } = new List<RecipeStep>(); // Listing to hold the steps of the recipe


        public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);
        public static event CaloriesExceededEventHandler CaloriesExceeded;

        public double CalculateTotalCalories()  // Created method to calculate the total calories of the recipe
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)      // Sum up the calories of all ingredients
            {
                totalCalories += ingredient.CaloriesAmount;
            }

            if (totalCalories > 300)  // Check if total calories exceeding the limit of  300 calories
            {
                CaloriesExceeded?.Invoke(this, EventArgs.Empty);     // Trigger the CaloriesExceeded event 
            }

            return totalCalories;   // Returning  the total calorie count
        }

    }
}




