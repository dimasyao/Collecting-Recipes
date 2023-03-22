using ProgramForCollectingRecipes.Recipes;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Menu;

internal class MainMenu
{
    private readonly MenuExistingRecipes _menuExistingRecipes = new();
    private readonly MenuRecipesEdit _menuRecipeEdit = new();
    public void Menu()
    {
        var flag = true;

        while (flag)
        {
            Console.Clear();
            CustomConsole.WriteLineCyan("\n\tMain Menu\n" +
                                          "\n1. Show existing recipes\n" +
                                          "2. Add a new recipe\n" +
                                          "3. Edit existing recipes\n" +
                                          "4. Exit");

            CustomConsole.WriteLineYellow("\nTip: Press the menu item number on the keyboard!");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _menuExistingRecipes.Menu();
                    break;
                case '2':
                    RecipeAction.AddNew();
                    break;
                case '3':
                    _menuRecipeEdit.Menu();
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
