using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

public class MenuRecipesEdit
{
    public void Menu()
    {
        var flag = true;

        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tEdit recipes\n" +
                                          "\n1. Delete existing recipe\n" +
                                          "2. Edit existing recipes\n" +
                                          "3. Back");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.DeleteRecipe(recipesFromFile);
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '2':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowExistingRecipesToEdit(recipesFromFile);
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '3':
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
