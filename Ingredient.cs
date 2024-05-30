using System;

namespace Part2_PROG6221_ST10040092
{
    public class Ingredient
    {


        //Properties to hold name of the ingredient,quantity of the ingredient,original quantity of the ingredient ,unit of measurement for the ingredient,calorie amount for the ingredient
        //Property to hold the food group of the ingredient
        public string? NameOfIngredient{ get; set; }
        public double Quantity { get; set; }
        public double OriginalQuantity { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public double CaloriesAmount { get; set; }
        public string? FoodGroup { get; set; }
    }
}

// code attribution
// W3schools
// https://www.w3schools.com/cs/index.php



