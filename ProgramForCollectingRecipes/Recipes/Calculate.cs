using ProgramForCollectingRecipes.Recipes.Objeсts;

namespace ProgramForCollectingRecipes.Recipes;

public class Calculate
{
    public static void EnergyValue(Recipe recipe)
    {
        recipe.EnergyValue.Calories = CalculateCaloriesInRecipe(recipe);
        recipe.EnergyValue.Carbohydrates = CalculateCarbohydratesInRecipe(recipe);
        recipe.EnergyValue.Proteins = CalculateProteinsInRecipe(recipe);
        recipe.EnergyValue.Fats = CalculateFatsInRecipe(recipe);
    }
    public static float CalculateCaloriesInRecipe(Recipe recipe)
    {
        var sum = 0f;
        foreach (var ingridient in recipe.Ingredients)
        {
            sum += ingridient.Value * ingridient.Calories / 100;
        }
        return sum / recipe.Amount * 100;
    }

    public static float CalculateCarbohydratesInRecipe(Recipe recipe)
    {
        var sum = 0f;
        foreach (var ingridient in recipe.Ingredients)
        {
            sum += ingridient.Value * ingridient.Carbohydrates / 100;
        }
        return sum / recipe.Amount * 100;
    }

    public static float CalculateProteinsInRecipe(Recipe recipe)
    {
        var sum = 0f;
        foreach (var ingridient in recipe.Ingredients)
        {
            sum += ingridient.Value * ingridient.Proteins / 100;
        }
        return sum / recipe.Amount * 100;
    }

    public static float CalculateFatsInRecipe(Recipe recipe)
    {
        var sum = 0f;
        foreach (var ingridient in recipe.Ingredients)
        {
            sum += ingridient.Value * ingridient.Fats / 100;
        }
        return sum / recipe.Amount * 100;
    }
}
