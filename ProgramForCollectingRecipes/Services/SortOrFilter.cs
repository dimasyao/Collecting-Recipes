using ProgramForCollectingRecipes.Recipes.Objeсts;

namespace ProgramForCollectingRecipes.Services;

public class SortOrFilter
{
    public static List<Recipe> SortByNameAsc(List<Recipe> recipes)
    {
        return recipes.OrderBy(recipe => recipe.Name).ToList();
    }

    public static List<Recipe> SortByNameDesc(List<Recipe> recipes)
    {
        return recipes.OrderByDescending(recipe => recipe.Name).ToList();
    }

    public static List<Recipe> SortByCaloriesAsc(List<Recipe> recipes)
    {
        return recipes.OrderBy(recipe => recipe.EnergyValue.Calories).ToList();
    }

    public static List<Recipe> SortByCaloriesDesc(List<Recipe> recipes)
    {
        return recipes.OrderByDescending(recipe => recipe.EnergyValue.Calories).ToList();
    }

    public static List<Recipe> FilterByName(List<Recipe> recipes)
    {
        Console.Clear();
        Console.WriteLine("\nEnter the name of the product with which you want to find recipes: ");
        var productName = Console.ReadLine();

        return (from recipe in recipes
                from ingridient in recipe.Ingredients
                where ingridient.Name == productName
                select recipe).ToList();

    }

    public static List<Recipe> FilterByCalories(string mode, float n, List<Recipe> recipes)
    {
        Console.Clear();
        return mode == "more"
            ? (from recipe in recipes
               where recipe.EnergyValue.Calories >= n
               select recipe).ToList()
            : (from recipe in recipes
               where recipe.EnergyValue.Calories <= n
               select recipe).ToList();
    }
    public static List<Recipe> FilterByCarbohydrates(string mode, float n, List<Recipe> recipes)
    {
        Console.Clear();
        return mode == "more"
            ? (from recipe in recipes
               where recipe.EnergyValue.Carbohydrates >= n
               select recipe).ToList()
            : (from recipe in recipes
               where recipe.EnergyValue.Carbohydrates <= n
               select recipe).ToList();
    }

    public static List<Recipe> FilterByProteins(string mode, float n, List<Recipe> recipes)
    {
        Console.Clear();
        return mode == "more"
            ? (from recipe in recipes
               where recipe.EnergyValue.Proteins >= n
               select recipe).ToList()
            : (from recipe in recipes
               where recipe.EnergyValue.Proteins <= n
               select recipe).ToList();
    }

    public static List<Recipe> FilterByFats(string mode, float n, List<Recipe> recipes)
    {
        Console.Clear();
        return mode == "more"
            ? (from recipe in recipes
               where recipe.EnergyValue.Fats >= n
               select recipe).ToList()
            : (from recipe in recipes
               where recipe.EnergyValue.Fats <= n
               select recipe).ToList();
    }
}
