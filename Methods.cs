using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2_PROG6221_ST10040092
{
    public class Methods
    {
        private List<RecipeData> recipes = new List<RecipeData>();
        //List to store all recipes in the application above 
        // Delegate for calorie notification
        public delegate void CalorieNotification(string message);
        public event CalorieNotification Notify;

        public Methods()
        {
            Notify += DisplayNotification;// Subscribing  to the Notify event
        }

        public void RecipeDetails()      // Method for  inputting the recipe details
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;//color choice for text
            Console.WriteLine("Please enter below the  Recipe Details");
            Console.ResetColor();// resets the texts color


            Console.ForegroundColor = ConsoleColor.Green;//color choice for text
            Console.WriteLine("Please Enter the  Recipe Name");
           Console.ResetColor();// resets the texts color


          
            string NameOfRecipe = Console.ReadLine();

            List<Ingredient> ingredients = new List<Ingredient>();// storing ingredients to  list
            List<RecipeStep> steps = new List<RecipeStep>();// we want to store steps in this list



            // Prompting to the  user to we want to enter the number of ingredients
            int ingredientNumberCount;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;//color choice for text
                Console.Write("\n Please enter the number of ingredients for this recipe: ");
                Console.ResetColor();// resets the texts color


                if (!int.TryParse(Console.ReadLine(), out ingredientNumberCount) || ingredientNumberCount < 1)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("An Error has occured as there is a invalid input format or value. Input postive number value.");//validation
                    Console.ResetColor();// resets the texts color
                }
                else
                {
                    break;
                }
            }
            // Inputting the  details for each ingredient
            for (int i = 0; i < ingredientNumberCount; i++)
            {
                Console.WriteLine($"\nPlease input the details for the this  ingredient {i + 1}:");
                Console.Write(" The name of  the ingredient is : ");
                string nameOfRecipe = Console.ReadLine();
                double quantityOfIngredeint;

                while (true)
                {
                    Console.Write(" The Quantity of Ingredient: ");
                    if (!double.TryParse(Console.ReadLine(), out quantityOfIngredeint) || quantityOfIngredeint <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("An Error has occured as there is a invalid input format or value. Input postive number value.");//validation
                        Console.ResetColor();// resets the texts color
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Unit of Measure (e.g., ,litres,cups, spoons, grams): ");
                string unit = Console.ReadLine();

                double caloriesSize;
                while (true)
                {
                    Console.Write("Calories: ");
                    if (!double.TryParse(Console.ReadLine(), out caloriesSize) || caloriesSize < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Invalid input format or value. Please enter a valid non-negative number for calories.");//validation
                        Console.ResetColor();// resets the texts color
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                // Adding  a new ingredient to the list
                ingredients.Add(new Ingredient { NameOfIngredient = nameOfRecipe, Quantity = quantityOfIngredeint, OriginalQuantity = quantityOfIngredeint, UnitOfMeasurement = unit, CaloriesAmount = caloriesSize, FoodGroup = foodGroup });
            }

            // Prompting to the user to enter the number of steps as a number, parsing 

            int stepCount;
            while (true)
            {
                Console.Write("\nPlease enter the number of steps: ");
                if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid input format or value. Please enter a valid positive integer for step count.");//validation
                    Console.ResetColor();// resets the texts color
                }
                else
                {
                    break;
                }
            }
            // Inputting the necessary details for each step, they must input a description
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"\nPlease enter step {i + 1}: ");//incrementing
                string description = Console.ReadLine();
                steps.Add(new RecipeStep { Description = description });
            }

            recipes.Add(new RecipeData { Name = NameOfRecipe, Ingredients = ingredients, Steps = steps });

            // Check for calorie notification
            double totalCalories = ingredients.Sum(ingredient => ingredient.CaloriesAmount);
            if (totalCalories > 300) // condition of having a message when the calories are over a 300
            {
                Notify?.Invoke($"The recipe '{NameOfRecipe}' exceeds 300 calories with a total of {totalCalories} calories.");// message user sees when they finish inputting all the details
            }
        }

        public void DisplayAllRecipes() // Method to display a recipe
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("All Recipes");
          
            Console.ResetColor();

            if (recipes.Count == 0)
            {

                // if statement to check whether there is recipes 
                // when there is no recipes , the message below is outputted
                Console.WriteLine("No recipes available.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }


        // A Method  for displaying all the recipes

        public void DisplayARecipe()
        {

            // Display the list of all recipes first
            DisplayAllRecipes();

            if (recipes.Count == 0)
            {
                return;
            }
            // Prompting to the user to enter their recipe name  to display
            Console.Write("\nEnter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();

            // Finding a recipe by name
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }
            // Displaying the recipe details
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;//color choice
            Console.WriteLine("Recipe Details");
            Console.ResetColor();

            Console.WriteLine("Recipe Name: " + recipe.Name);
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.NameOfIngredient} ({ingredient.CaloriesAmount} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int a = 0; a < recipe.Steps.Count; a++)//incrementing
            {
                Console.WriteLine($"{a + 1}. {recipe.Steps[a].Description}");
            }

            double totalAmountOfCalories = recipe.Ingredients.Sum(ingredient => ingredient.CaloriesAmount);

            Console.ForegroundColor = ConsoleColor.Green;//color choice
            Console.WriteLine($"\n The total amount Calories: {totalAmountOfCalories}");
            Console.ResetColor();
            if (totalAmountOfCalories > 300) //what happens if the calories amount total exceeds 300
            {
                Console.ForegroundColor = ConsoleColor.Green;//color choice
                Console.WriteLine("Warning: This recipe exceeds 300 calories!"); // the warning message
                Console.ResetColor();
            }
        }
        // Method to scale the ingredients of a recipe
        public void ScaledResultedIngredients(double factorNumber)
        {

            // Prompting tp the user to enter the name of the recipe to scale
            Console.Write("Please enter the name of the recipe to scale up : ");
            string nameOfRecipe = Console.ReadLine();
            // Find the recipe by name
            var recipeChoice = recipes.FirstOrDefault(r => r.Name.Equals(nameOfRecipe, StringComparison.OrdinalIgnoreCase));

            if (recipeChoice == null)
            {
                Console.WriteLine("\n This recipe name was  not found.");
                return;
            }
            // Scaling the quantity of each of the  ingredient
            foreach (var ingredients in recipeChoice.Ingredients)
            {
                ingredients.Quantity *= factorNumber; // using the ingredient class to call the getters and setters , this time quantity
            }

            Console.Clear();   // Display the scaled recipe
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Scaled Recipe");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" The recipe Name: " + recipeChoice.Name);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n The scaled Recipe Ingredients are:");
            Console.ResetColor();
            foreach (var ingredients in recipeChoice.Ingredients)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ingredients.Quantity} {ingredients.UnitOfMeasurement} of {ingredients.NameOfIngredient}");
                Console.ResetColor();
            }
        }

        public void ResetingTheQuantities()        // Method to reset ingredient quantities to original values
        {
            Console.Write("Please enter the name of the recipe to reset: ");     // Prompt user to enter the name of the recipe to reset
            string recipeOfName = Console.ReadLine();
            // Find the recipe by name
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeOfName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nRecipe not found.");
                Console.ResetColor();
                return;
            }

            foreach (var ingredient in recipe.Ingredients)     // Reset the quantity of each ingredient to its original value
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        public void ClearTheData()      // Method to clear all recipes
        {
            recipes.Clear();
        }

        // Notification method
        private void DisplayNotification(string messageForCalorieCount)     // Notification method to display calorie warning
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(messageForCalorieCount);
            Console.ResetColor();
        }
    }
}

// code attribution
// W3schools
// https://www.w3schools.com/cs/index.php




