using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class CatalogService
{
    public List<ProductRecommendation>
        GetRecommendations(
            string intent,
            decimal? budget)
    {
        var products =
            new List<ProductRecommendation>();

        if(intent.Contains(
            "vegetarian",
            StringComparison.OrdinalIgnoreCase))
        {
            products.Add(
                new ProductRecommendation
{
    ItemId="V1001",
    Name="Veg Deluxe Meal",
    Price=499,
    Category="Meal"
});

            products.Add(
                new ProductRecommendation
{
    ItemId="V1002",
    Name="Fresh Lime Soda",
    Price=79,
    Category="Drink"
});
        }

        else if(intent.Contains(
            "family",
            StringComparison.OrdinalIgnoreCase))
        {
            products.Add(
                new ProductRecommendation
                {
                    ItemId="F1001",
                    Name="Family Dinner Combo",
                    Price=1299,
                    Category="Meal"
                });
        }

        else
        {
            products.Add(
                new ProductRecommendation
{
    ItemId="G1001",
    Name="Chef Special Combo",
    Price=399,
    Category="Meal"
});
        }

        if (budget.HasValue)
{
    decimal runningTotal = 0;

    var filteredProducts =
        new List<ProductRecommendation>();

    foreach(var product in products)
    {
        if(runningTotal + product.Price
            <= budget.Value)
        {
            filteredProducts.Add(product);

            runningTotal +=
                product.Price;
        }
    }

    products = filteredProducts;
}

if(!products.Any(
    x=>x.Category=="Meal"))
{
    return new List<ProductRecommendation>();
}

return products;
    }
}