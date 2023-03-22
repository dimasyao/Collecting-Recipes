using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

public class RecipeSotringMenu
{

    public void Menu()
    {
        var flag = true;

        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tSorting recipes\n" +
                                            "\n1. Sort by Name ascending\n" +
                                            "2. Sort by Name descending\n" +
                                            "3. Sort by Calories ascending\n" +
                                            "4. Sort by Calories descending\n" +
                                            "5. Back");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowAll(SortOrFilter.SortByNameAsc(recipesFromFile));
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
                        RecipeAction.ShowAll(SortOrFilter.SortByNameDesc(recipesFromFile));
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '3':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowAll(SortOrFilter.SortByCaloriesAsc(recipesFromFile));
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '4':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowAll(SortOrFilter.SortByCaloriesDesc(recipesFromFile));
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '5':
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
