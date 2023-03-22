namespace ProgramForCollectingRecipes.Services;

public class CustomConsole
{
    public static void WriteLineCyan(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
    }
    public static void WriteLineYellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void WriteLineError(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void WriteLineSuccess(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
    public static string? ReadStringFloatFromConsole()
    {
        var number = Console.ReadLine();
        if (number != null)
            number = number.Replace(',', '.');
        return number;
    }
}
