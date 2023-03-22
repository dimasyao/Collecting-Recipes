namespace ProgramForCollectingRecipes.Services;

public class Errors
{
    public static void NotExistRecipes()
    {
        CustomConsole.WriteLineError("\nThere are no recipes with the specified parameter!\nPress Enter!");
        while (true)
        {
            if (Console.ReadLine() != null)
            {
                break;
            }
        }
    }
}
