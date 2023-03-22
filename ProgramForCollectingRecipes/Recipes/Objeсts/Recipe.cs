namespace ProgramForCollectingRecipes.Recipes.Objeсts;

public class Recipe
{
    public string? Name { get; set; }
    public List<Ingridient> Ingredients { get; set; } = new List<Ingridient>();
    public EnergyValue EnergyValue { get; set; } = new EnergyValue();
    public int Amount { get; set; }
    public string? Description { get; set; }
}
