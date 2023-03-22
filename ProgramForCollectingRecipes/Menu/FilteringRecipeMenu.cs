using System.Globalization;
using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

public class FilteringRecipeMenu
{
    public void Menu()
    {
        var flag = true;

        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tFiltering recipes\n" +
                                            "\n1. Filter recipes by name\n" +
                                            "2. Filter recipes by count of Calories\n" +
                                            "3. Filter recipes by count of Carbohydrates\n" +
                                            "4. Filter recipes by count of Proteins\n" +
                                            "5. Filter recipes by count of Fats\n" +
                                            "6. Back");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        RecipeAction.ShowAll(SortOrFilter.FilterByName(recipesFromFile));
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
                        MoreLess(out var mode, out var n);
                        RecipeAction.ShowAll(SortOrFilter.FilterByCalories(mode, n, recipesFromFile));
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
                        MoreLess(out var mode, out var n);
                        RecipeAction.ShowAll(SortOrFilter.FilterByCarbohydrates(mode, n, recipesFromFile));
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
                        MoreLess(out var mode, out var n);
                        RecipeAction.ShowAll(SortOrFilter.FilterByProteins(mode, n, recipesFromFile));
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '5':
                {
                    var recipesFromFile = Data.ReadRecipesFromFile();
                    if (recipesFromFile != null && recipesFromFile.Count != 0)
                    {
                        MoreLess(out var mode, out var n);
                        RecipeAction.ShowAll(SortOrFilter.FilterByFats(mode, n, recipesFromFile));
                    }
                    else
                    {
                        Errors.NotExistRecipes();
                    }
                    break;
                }
                case '6':
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }

    private static void MoreLess(out string mode, out float n)
    {
        Console.Clear();
        mode = "";
        CustomConsole.WriteLineCyan("\nYou must select an option to filter:\n" +
            "1. More then N\n" +
            "2. Less then N\n");

        CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!\n");
        var flag = true;
        while (flag)
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                {
                    mode = "more";
                    flag = false;
                    break;
                }
                case '2':
                {
                    mode = "less";
                    flag = false;
                    break;
                }
                default:
                    break;
            }
        }

        while (true)
        {
            CustomConsole.WriteLineCyan("Enter N: ");
            var number = CustomConsole.ReadStringFloatFromConsole();
            if (float.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out n))
            {
                break;
            }
            else
            {
                CustomConsole.WriteLineError("\nYou number is not float!\n");
            }
        }
    }
}
