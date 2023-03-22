using ProgramForCollectingRecipes.Items;
using ProgramForCollectingRecipes.Menu;

namespace ProgramForCollectingRecipes;

internal class CollectingRecipesApplication
{
    private readonly MainMenu _mainMenu = new();
    public ReturnCode Run()
    {
        _mainMenu.Menu();
        return ReturnCode.Success;
    }
}
