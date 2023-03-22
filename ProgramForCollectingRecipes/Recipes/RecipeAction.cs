using ProgramForCollectingRecipes.Services;
using ProgramForCollectingRecipes.Recipes.Objeсts;
using ProgramForCollectingRecipes.Menu;

namespace ProgramForCollectingRecipes.Recipes;

public class RecipeAction
{
    public static void ShowAll(List<Recipe> recipes)
    {
        Console.Clear();

        View.RecipesListToScreen(recipes);

        while (true)
        {
            CustomConsole.WriteLineYellow("\nTo view the full recipe, enter its number: ");

            if (int.TryParse(Console.ReadLine(), out var result) && result - 1 >= 0 && result - 1 < recipes.Count)
            {
                Console.Clear();
                View.ShowRecipe(recipes[result - 1]);
                CustomConsole.WriteLineYellow("Press enter to continue!");
                if (Console.ReadLine() != null)
                    break;
            }
            else
            {
                CustomConsole.WriteLineError("\nIt looks like you've entered a number that doesn't exist. Please try again!");
            }
        }
    }
    public static void AddNew()
    {
        Console.Clear();
        CustomConsole.WriteLineCyan("\n Add a new recipe\n");
        var recipe = new Recipe();

        EnterRecipeName(recipe);

        AddIngridient(recipe);

        Calculate.EnergyValue(recipe);

        EnterDescription(recipe);

        Data.WriteNewRecipeInFile(recipe);

        CustomConsole.WriteLineSuccess($"Recipe \"{recipe.Name}\" successfully added!");
    }

    public static void ShowExistingRecipesToEdit(List<Recipe> recipes)
    {
        Console.Clear();

        View.RecipesListToScreen(recipes);

        while (true)
        {
            CustomConsole.WriteLineYellow("\nTo edit recipe, enter its number: ");

            if (int.TryParse(Console.ReadLine(), out var result) && result - 1 >= 0 && result - 1 < recipes.Count)
            {
                var updateRecipe = MenuRecipeEdit.EditRecipe(recipes[result - 1]);
                recipes[result - 1] = updateRecipe;
                Data.WriteRecipesListInFile(recipes);
                break;
            }
            else
            {
                CustomConsole.WriteLineError("\nIt looks like you've entered a number that doesn't exist. Please try again!");
            }
        }
    }


    public static void AddIngridient(Recipe recipe)
    {
        CustomConsole.WriteLineCyan("\nSo, add products!");
        var listWithProducts = Data.GetListWithProducts();
        var namesOfIgridientsInRecipe = (from Ingridient in recipe.Ingredients
                                         select Ingridient.Name).ToList();
        var createNewProduct = true;
        while (createNewProduct)
        {
            var ingridientName = "";
            while (true)
            {
                CustomConsole.WriteLineCyan("Enter product name: ");
                ingridientName = Console.ReadLine();
                if (!string.IsNullOrEmpty(ingridientName))
                {
                    ingridientName = ingridientName.ToLowerInvariant();
                    break;
                }
                else
                {
                    CustomConsole.WriteLineError("You must enter a product name!");
                }
            }

            var ingridient = new Ingridient();
            while (true)
            {
                if (ingridientName != null)
                {
                    var product = new Product();
                    var flag = false;
                    foreach (var prod in listWithProducts)
                    {
                        if (prod.Name == ingridientName)
                        {
                            product = prod;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        product = Product.CreateNewProduct(ingridientName);
                        listWithProducts.Add(product);
                        Data.WriteNewListOfProductsInFile(listWithProducts);
                    }

                    ingridient.Name = ingridientName;
                    ingridient.Calories = product.Calories;
                    ingridient.Carbohydrates = product.Carbohydrates;
                    ingridient.Proteins = product.Proteins;
                    ingridient.Fats = product.Fats;
                    break;
                }
                else
                {
                    CustomConsole.WriteLineError("You must enter a product name!");
                }
            }

            if (!namesOfIgridientsInRecipe.Contains(ingridientName))
            {
                int valueOfProduct;
                while (true)
                {
                    CustomConsole.WriteLineCyan("Enter the amount of product in grams: ");
                    if (int.TryParse(Console.ReadLine(), out var result))
                    {
                        valueOfProduct = result;
                        break;
                    }
                    else
                    {
                        CustomConsole.WriteLineError("Amount must be entered as an integer. Try again!");
                    }
                }

                namesOfIgridientsInRecipe.Add(ingridientName);
                ingridient.Value = valueOfProduct;
                recipe.Amount += ingridient.Value;
                recipe.Ingredients.Add(ingridient);
            }
            else
            {
                CustomConsole.WriteLineError("This product is already in the recipe!");
            }

            CustomConsole.WriteLineYellow("\nDo you want to add another product?\n1.Yes \n2.No - Press any button.\n");

            if (Console.ReadLine() != "1")
            {
                createNewProduct = false;
            }
        }
    }

    public static void EnterDescription(Recipe recipe)
    {
        CustomConsole.WriteLineCyan("\nEnter description of recipe: ");
        recipe.Description = Console.ReadLine();
    }

    public static void EnterRecipeName(Recipe recipe)
    {
        Console.Clear();
        while (true)
        {
            Console.Write("\nEnter recipe name: ");
            var recipeName = Console.ReadLine();
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipe.Name = recipeName;
                break;
            }
            else
            {
                CustomConsole.WriteLineError("\nYou must enter a recipe name!");
            }
        }
    }

    public static void DeleteRecipe(List<Recipe> recipes)
    {
        Console.Clear();

        View.RecipesListToScreen(recipes);

        while (true)
        {
            CustomConsole.WriteLineYellow("\nTo delete recipe, enter its number: ");

            if (int.TryParse(Console.ReadLine(), out var result) && result - 1 >= 0 && result - 1 < recipes.Count)
            {
                recipes.RemoveAt(result - 1);
                Data.WriteRecipesListInFile(recipes);
                CustomConsole.WriteLineYellow("Press enter to continue!");
                if (Console.ReadLine() != null)
                    break;
            }
            else
            {
                CustomConsole.WriteLineError("\nIt looks like you've entered a number that doesn't exist. Please try again!");
            }
        }
    }

    public static void DeleteIngridient(Recipe recipe)
    {
        Console.Clear();

        View.IngridientsListToScreen(recipe);

        while (true)
        {
            CustomConsole.WriteLineYellow("\nTo delete ingridient, enter its number: ");

            if (int.TryParse(Console.ReadLine(), out var result) && result - 1 >= 0 && result - 1 < recipe.Ingredients.Count)
            {
                recipe.Ingredients.RemoveAt(result - 1);
                CustomConsole.WriteLineYellow("Press enter to continue!");
                if (Console.ReadLine() != null)
                    break;
            }
            else
            {
                CustomConsole.WriteLineError("\nIt looks like you've entered a number that doesn't exist. Please try again!");
            }
        }
    }
}
