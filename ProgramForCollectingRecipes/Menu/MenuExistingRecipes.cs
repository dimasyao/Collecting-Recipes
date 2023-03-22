using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

public class MenuExistingRecipes
{
    private readonly RecipeSotringMenu _recipeSortingMenu = new();
    private readonly FilteringRecipeMenu _filteringRecipeSortingMenu = new();

    public void Menu()
    {
        var flag = true;

        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tExisting recipes\n" +
                                            "\n1. Show all recipes\n" +
                                            "2. Show sorted recipes\n" +
                                            "3. Apply filtering to recipess\n" +
                                            "4. Back");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowAll(recipesFromFile);
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '2':
                    _recipeSortingMenu.Menu();
                    break;
                case '3':
                    _filteringRecipeSortingMenu.Menu();
                    break;
                case '4':
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
