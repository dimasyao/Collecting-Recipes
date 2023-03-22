using System.Globalization;
using ProgramForCollectingRecipes.Services;

namespace ProgramForCollectingRecipes.Recipes.Objeсts;

public class Product : EnergyValue
{
    public string? Name { get; set; }

    public static Product CreateNewProduct(string productName)
    {
        var newProduct = new Product
        {
            Name = productName
        };
        Console.WriteLine("\nOur database does not contain such a product. So you need to add it and enter some information about this product.\n");
        while (true)
        {
            Console.Write("Enter the number of calories per 100 grams of product: ");
            var number = CustomConsole.ReadStringFloatFromConsole();
            if (float.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueOfCaloriesInProduct))
            {
                newProduct.Calories = valueOfCaloriesInProduct;
                break;
            }
            else
            {
                CustomConsole.WriteLineError("Amount of calories must be entered as a number. Try again!");
            }
        }
        while (true)
        {
            Console.Write("Enter the number of carbohydrates per 100 grams of product: ");
            var number = CustomConsole.ReadStringFloatFromConsole();
            if (float.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueOfCarbohydratesInProduct))
            {
                newProduct.Carbohydrates = valueOfCarbohydratesInProduct;
                break;
            }
            else
            {
                CustomConsole.WriteLineError("Amount of carbonhydrates must be entered as a number. Try again!");
            }
        }

        while (true)
        {
            Console.Write("Enter the number of proteins per 100 grams of product: ");
            var number = CustomConsole.ReadStringFloatFromConsole();
            if (float.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueOfProteinsInProduct))
            {
                newProduct.Proteins = valueOfProteinsInProduct;
                break;
            }
            else
            {
                CustomConsole.WriteLineError("Amount of proteins must be entered as a number. Try again!");
            }
        }

        while (true)
        {
            Console.Write("Enter the number of fats per 100 grams of product: ");
            var number = CustomConsole.ReadStringFloatFromConsole();
            if (float.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueOfFatsInProduct))
            {
                newProduct.Fats = valueOfFatsInProduct;
                break;
            }
            else
            {
                CustomConsole.WriteLineError("Amount of fats must be entered as a number. Try again!");
            }
        }

        CustomConsole.WriteLineSuccess($"Product \"{newProduct.Name}\" successfully added to database!\n");

        return newProduct;
    }
}
