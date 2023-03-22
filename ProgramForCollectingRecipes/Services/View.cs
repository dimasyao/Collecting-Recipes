using ProgramForCollectingRecipes.Recipes.Objeсts;

namespace ProgramForCollectingRecipes.Services;

public class View
{
    public static void ShowRecipe(Recipe recipe)
    {
        CustomConsole.WriteLineCyan("Recipe name: " + recipe.Name);
        IngridientsListToScreen(recipe);
        Console.WriteLine("\nСalories per 100 grams of recipe: " + Math.Round(recipe.EnergyValue.Calories, 3));
        Console.WriteLine("Carbohydrates per 100 grams of recipe: " + Math.Round(recipe.EnergyValue.Carbohydrates, 3));
        Console.WriteLine("Proteins per 100 grams of recipe: " + Math.Round(recipe.EnergyValue.Proteins, 3));
        Console.WriteLine("Fats per 100 grams of recipe: " + Math.Round(recipe.EnergyValue.Fats, 3));
        Console.WriteLine("\nDescription: " + recipe.Description);
    }

    public static void IngridientsListToScreen(Recipe recipe)
    {
        CustomConsole.WriteLineCyan("\nList of ingredients: ");
        foreach (var ingridient in recipe.Ingredients)
        {
            Console.WriteLine("\t" + (recipe.Ingredients.IndexOf(ingridient) + 1) + "." + ingridient.Name);
        }
    }

    public static void RecipesListToScreen(List<Recipe> recipes)
    {
        Console.WriteLine("\n\tYour recipes:\n");
        foreach (var recipe in recipes)
        {
            CustomConsole.WriteLineCyan($"{recipes.IndexOf(recipe) + 1}. {recipe.Name}" +
                $" Cal/100g: {Math.Round(recipe.EnergyValue.Calories, 3)}" +
                $" C/100g: {Math.Round(recipe.EnergyValue.Carbohydrates, 3)}" +
                $" P/100g: {Math.Round(recipe.EnergyValue.Proteins, 3)}" +
                $" F/100g: {Math.Round(recipe.EnergyValue.Fats, 3)}");
        }
    }
}
