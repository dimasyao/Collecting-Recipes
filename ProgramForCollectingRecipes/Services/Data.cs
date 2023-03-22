using System.Text;
using System.Text.Json;
using ProgramForCollectingRecipes.Recipes.Objeсts;

namespace ProgramForCollectingRecipes.Services;

public class Data
{
    private static readonly string _dataProductsFilename = "..\\..\\..\\Data\\DataProducts.json";
    private static readonly string _dataRecipesFilename = "..\\..\\..\\Data\\DataRecipes.json";
    private static readonly FileService _fileService = new();

    public static List<Product>? GetListWithProducts()
    {
        var listWithProducts = new List<Product>();

        if (_fileService.Exists(_dataProductsFilename))
        {
            string? text;

            using (var sr = new StreamReader(_fileService.Read(_dataProductsFilename)))
            {
                text = sr.ReadToEnd();
            }

            listWithProducts = JsonSerializer.Deserialize<List<Product>>(text);
        }

        return listWithProducts;
    }

    public static void WriteNewListOfProductsInFile(List<Product> products)
    {
        var text = JsonSerializer.Serialize(products);
        Stream contentStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        _fileService.Write(_dataProductsFilename, contentStream);
    }

    public static void WriteRecipesListInFile(List<Recipe> recipes)
    {
        var text = JsonSerializer.Serialize(recipes);
        Stream contentStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        _fileService.Write(_dataRecipesFilename, contentStream);
    }
    public static void WriteNewRecipeInFile(Recipe recipe)
    {
        var recipes = ReadRecipesFromFile();
        recipes.Add(recipe);
        var text = JsonSerializer.Serialize(recipes);
        Stream contentStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        _fileService.Write(_dataRecipesFilename, contentStream);
    }

    public static List<Recipe>? ReadRecipesFromFile()
    {
        var recipes = new List<Recipe>();

        if (_fileService.Exists(_dataRecipesFilename))
        {
            string? textFromFile;

            using (var sr = new StreamReader(_fileService.Read(_dataRecipesFilename)))
            {
                textFromFile = sr.ReadToEnd();
            }

            if (!string.IsNullOrWhiteSpace(textFromFile))
            {
                recipes = JsonSerializer.Deserialize<List<Recipe>>(textFromFile);
            }
        }

        return recipes;
    }
}
