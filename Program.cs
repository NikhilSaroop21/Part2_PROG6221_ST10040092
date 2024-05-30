using Part2_PROG6221_ST10040092;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2_PROG6221_ST10040092
{
    class Recipe
    {
        
        Methods methods = new Methods();

        static void Main(string[] args)
        {
            // Creating the  instance of Recipe to access non-static methods
            Recipe recipe = new Recipe();

            // Main loop for  displaying the  menu and process user input
            while (true)
            {
                Console.Clear();

                // Display welcome message and menu options below
                Console.WriteLine("Welcome to Recipe App");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nSelect an option:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Enter Recipe Details");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. Display All Recipes");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Display Specific Recipe");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("4. Scale Recipe");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("5. Reset Quantities");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("6. Clear Data");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("7. Exit");

                // Read user input and validate it
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("\nError: Invalid input. Please enter a number.");//error handling
                    Console.ReadLine();
                    continue;
                }

                // Switch statement to handle menu options
                switch (option)
                {
                    case 1:
                        // Enter recipe details
                        recipe.methods.RecipeDetails();//method calling for method class
                        Console.WriteLine("\nRecipe details entered successfully.");//success message
                        Console.ReadLine();
                        break;
                    case 2:
                        // Display all recipes
                        recipe.methods.DisplayAllRecipes();//method calling for method class
                        Console.ReadLine();
                        break;
                    case 3:
                        // Display a specific recipe
                        recipe.methods.DisplayARecipe();//method calling for method class
                        Console.ReadLine();
                        break;
                    case 4:
                        // Scale a recipe
                        double factor;
                        Console.Write("\nPlease enter a scaling factor (0.5, 2, or 3): ");
                        if (!double.TryParse(Console.ReadLine(), out factor))
                        {
                            Console.WriteLine("\nError: Invalid input. Please enter a number.");
                            Console.ReadLine();
                            continue;
                        }
                        if (factor != 0.5 && factor != 2 && factor != 3)
                        {
                            Console.WriteLine("\nError: Invalid scaling factor. Please enter 0.5, 2, or 3.");
                            Console.ReadLine();
                            continue;
                        }
                        recipe.methods.ScaledResultedIngredients(factor);
                        Console.WriteLine("\nRecipe scaled successfully.");
                        Console.ReadLine();
                        break;
                    case 5:
                        // Reset recipe quantities
                        recipe.methods.ResetingTheQuantities();//method calling for method class
                        Console.WriteLine("\nRecipe quantities reset successfully.");
                        Console.ReadLine();
                        break;
                    case 6:
                        // Clear all recipe data
                        recipe.methods.ClearTheData();//method calling for method class
                        Console.WriteLine("\nData cleared successfully.");
                        Console.ReadLine();
                        break;
                    case 7:
                        // Exit the application
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle invalid menu option
                        Console.WriteLine("\nError: Invalid option.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
