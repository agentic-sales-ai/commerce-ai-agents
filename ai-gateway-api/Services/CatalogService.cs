using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class CatalogService
{
    private readonly ICommerceService
        _commerce;

    public CatalogService(
        ICommerceService commerce)
    {
        _commerce = commerce;
    }

    public List<ProductRecommendation>
        GetRecommendations(
            string intent,
            decimal? budget,
            string channelId)
    {
        var searchText =
            string.IsNullOrWhiteSpace(
                intent)
            ? ""
            : intent;

        var products =
            _commerce
            .SearchProductsAsync(
                searchText,
                channelId)
            .Result;

        if (budget.HasValue)
        {
            decimal runningTotal = 0;

            var filteredProducts =
                new List<ProductRecommendation>();

            foreach(var product in products)
            {
                if(runningTotal +
                    product.Price
                    <= budget.Value)
                {
                    filteredProducts
                        .Add(product);

                    runningTotal +=
                        product.Price;
                }
            }

            products =
                filteredProducts;
        }

        Console.WriteLine(
            $"Products returned: {products.Count}");

        if(products.Any())
        {
            Console.WriteLine(
                $"First result: {products[0].Name}");
        }

        return products;
    }
}