using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Recipes.Objeсts;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

public class MenuRecipeEdit
{
    public static Recipe EditRecipe(Recipe recipe)
    {
        var flag = true;
        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tEdit recipe\n" +
                                          "\n1. New name\n" +
                                          "2. Add new ingridient\n" +
                                          "3. Delete existing ingridient\n" +
                                          "4. New decription\n" +
                                          "5. Back");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    RecipeAction.EnterRecipeName(recipe);
                    break;
                }
                case '2':
                {
                    RecipeAction.AddIngridient(recipe);
                    Calculate.EnergyValue(recipe);
                    break;
                }
                case '3':
                {
                    RecipeAction.DeleteIngridient(recipe);
                    Calculate.EnergyValue(recipe);
                    break;
                }
                case '4':
                {
                    RecipeAction.EnterDescription(recipe);
                    break;
                }
                case '5':
                    flag = false;
                    break;
                default:
                    break;
            }
        }
        return recipe;
    }
}
