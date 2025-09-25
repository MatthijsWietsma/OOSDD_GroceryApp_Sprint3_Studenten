using Grocery.Core.Interfaces.Repositories;
using Moq;
using Grocery.Core.Models;
using Grocery.Core.Services;

namespace TestCore;

public class TestSearchbar
{
    [SetUp]
    public void Setup()
    {
    }

    private static readonly object[] FilterCases =
    {
        new object[] { "Pasta", new List<Product> { new Product(4, "Pasta", 3) } },
        new object[] { "yoghurt", new List<Product> { new Product(2, "Yoghurt", 2) } },
        new object[] { "ch", new List<Product> { new Product(1, "Chips", 1), new Product(3, "Chocolade", 3) } }
    };

    [TestCaseSource(nameof(FilterCases))]
    public void TestFilterAvailableProductsReturnsFilteredList(string searchInput, List<Product> expectedOutput)
    {
        // Arrange
        var mockGroceryListItemsRepository = new Mock<IGroceryListItemsRepository>();
        var mockProductRepository = new Mock<IProductRepository>();

        var groceryListItemsService =
            new GroceryListItemsService(mockGroceryListItemsRepository.Object, mockProductRepository.Object);

        List<Product> products = new List<Product>
        {
            new Product(1, "Chips", 1),
            new Product(2, "Yoghurt", 2),
            new Product(3, "Chocolade", 3),
            new Product(4, "Pasta", 3),
            new Product(5, "Limonade", 3),
            new Product(6, "Notenmix", 3),
        };

        // Act
        List<Product> filteredList = groceryListItemsService.FilterAvailableProducts(searchInput, products);
        filteredList = filteredList.OrderBy(p => p.Id).ToList();

        // Assert
        Assert.That(filteredList.Select(p => p.Id).ToList(),
            Is.EqualTo(expectedOutput.Select(p => p.Id).ToList()));
    }
}
