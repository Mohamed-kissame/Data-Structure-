using System;
using System.Collections.Generic;

namespace ProductCatalogLookupSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductCatalog catalog = new ProductCatalog();

            Console.WriteLine("========== 1. Add Products ==========\n");

            catalog.AddProduct("P100", "Laptop", 7500m, "Electronics", 10);
            catalog.AddProduct("P200", "Mouse", 120m, "Accessories", 50);
            catalog.AddProduct("P300", "Keyboard", 350m, "Accessories", 30);
            catalog.AddProduct("P400", "Monitor", 1800m, "Electronics", 15);
            catalog.AddProduct("P500", "Office Chair", 950m, "Furniture", 8);
            catalog.AddProduct("P600", "Desk", 1400m, "Furniture", 5);

            catalog.ShowAllProducts();

            Console.WriteLine("\n========== 2. Try Duplicate Product Code ==========\n");
            catalog.AddProduct("P100", "Gaming Laptop", 12000m, "Electronics", 3);

            Console.WriteLine("\n========== 3. Try Invalid Inputs ==========\n");
            catalog.AddProduct("", "Invalid Product", 100m, "Test", 5);
            catalog.AddProduct("P700", "", 100m, "Test", 5);
            catalog.AddProduct("P800", "Invalid Category Product", 100m, "", 5);

            Console.WriteLine("\n========== 4. Try Invalid Price ==========\n");
            catalog.AddProduct("P900", "Free Product", 0m, "Test", 5);

            Console.WriteLine("\n========== 5. Try Invalid Stock ==========\n");
            catalog.AddProduct("P901", "Bad Stock Product", 100m, "Test", -1);

            Console.WriteLine("\n========== 6. AddOrUpdate Existing Product ==========\n");
            catalog.AddOrUpdateProduct("P200", "Wireless Mouse", 180m, "Accessories", 60);
            catalog.ShowAllProducts();

            Console.WriteLine("\n========== 7. AddOrUpdate New Product ==========\n");
            catalog.AddOrUpdateProduct("P700", "USB Cable", 50m, "Accessories", 100);
            catalog.ShowAllProducts();

            Console.WriteLine("\n========== 8. Get Existing Product ==========\n");

            Product product = catalog.GetProductByCode("p100");

            if (product != null)
            {
                Console.WriteLine($"Found Product: {product.Code} | {product.Name} | {product.Price}");
            }

            Console.WriteLine("\n========== 9. Get Missing Product ==========\n");
            catalog.GetProductByCode("P999");

            Console.WriteLine("\n========== 10. Update Price ==========\n");
            catalog.UpdatePrice("P300", 420m);
            catalog.GetProductByCode("P300");

            Console.WriteLine("\n========== 11. Try Invalid Price Update ==========\n");
            catalog.UpdatePrice("P300", -20m);

            Console.WriteLine("\n========== 12. Update Stock ==========\n");
            catalog.UpdateStock("P400", 25);

            Console.WriteLine("\n========== 13. Try Invalid Stock Update ==========\n");
            catalog.UpdateStock("P400", -5);

            Console.WriteLine("\n========== 14. Deactivate Product ==========\n");
            catalog.DeactivateProduct("P500");

            Console.WriteLine("\n========== 15. Try Deactivating Same Product Again ==========\n");
            catalog.DeactivateProduct("P500");

            Console.WriteLine("\n========== 16. Contains Product ==========\n");
            Console.WriteLine($"Contains P100: {catalog.ContainsProduct("P100")}");
            Console.WriteLine($"Contains P999: {catalog.ContainsProduct("P999")}");

            Console.WriteLine("\n========== 17. Remove Product ==========\n");
            catalog.RemoveProduct("P600");

            Console.WriteLine("\n========== 18. Try Removing Missing Product ==========\n");
            catalog.RemoveProduct("P999");

            Console.WriteLine("\n========== 19. Show All Products ==========\n");
            catalog.ShowAllProducts();

            Console.WriteLine("\n========== 20. Show Active Products ==========\n");
            catalog.ShowActiveProducts();

            Console.WriteLine("\n========== 21. Get Products By Category: Accessories ==========\n");
            List<Product> accessories = catalog.GetProductsByCategory("accessories");
            catalog.ShowProducts(accessories);

            Console.WriteLine("\n========== 22. Get Products By Invalid Category ==========\n");
            List<Product> invalidCategory = catalog.GetProductsByCategory("   ");
            catalog.ShowProducts(invalidCategory);

            Console.WriteLine("\n========== 23. Get Products Above Price 500 ==========\n");
            List<Product> expensiveProducts = catalog.GetProductsAbovePrice(500m);
            catalog.ShowProducts(expensiveProducts);

            Console.WriteLine("\n========== 24. Get Products Above Invalid Price ==========\n");
            List<Product> invalidPriceFilter = catalog.GetProductsAbovePrice(-1m);
            catalog.ShowProducts(invalidPriceFilter);

            Console.WriteLine("\n========== 25. Get Sorted By Price ==========\n");
            List<Product> sortedByPrice = catalog.GetSortedByPrice();
            catalog.ShowProducts(sortedByPrice);

            Console.WriteLine("\n========== 26. Get Top 3 Expensive Products ==========\n");
            List<Product> topExpensive = catalog.GetTopExpensiveProducts(3);
            catalog.ShowProducts(topExpensive);

            Console.WriteLine("\n========== 27. Get Top Expensive With Invalid Count ==========\n");
            List<Product> invalidTop = catalog.GetTopExpensiveProducts(0);
            catalog.ShowProducts(invalidTop);

            Console.WriteLine("\n========== 28. Show Products Grouped By Category ==========\n");
            catalog.ShowProductsGroupedByCategory();

            Console.WriteLine("\n========== 29. Show Statistics ==========\n");
            catalog.ShowStatistics();

            Console.WriteLine("\n========== 30. Clear Catalog ==========\n");
            catalog.ClearCatalog();

            Console.WriteLine("\n========== 31. Show All After Clear ==========\n");
            catalog.ShowAllProducts();

            Console.WriteLine("\n========== 32. Show Statistics After Clear ==========\n");
            catalog.ShowStatistics();

            Console.WriteLine("\n========== 33. Clear Again ==========\n");
            catalog.ClearCatalog();

            Console.WriteLine("\n========== TEST FINISHED ==========");


            Console.ReadLine();
        }
    }
}