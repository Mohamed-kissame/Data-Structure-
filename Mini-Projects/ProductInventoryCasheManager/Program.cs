using System;
using BLL;
using Models;




namespace ProductInventoryCacheConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();

            Console.WriteLine("========== 1. Load Products From Database ==========\n");
            manager.LoadProductsFromDatabase();

            Console.WriteLine("\n========== 2. Show Initial Cache Statistics ==========\n");
            manager.ShowCacheStatistics();

            Console.WriteLine("\n========== 3. Search Existing Product From Cache ==========\n");
            Product product = manager.GetProductFromCache("P100");

            if (product != null)
            {
                Console.WriteLine($"Found Product: {product.ProductCode} | {product.ProductName} | {product.Price} | Stock: {product.StockQuantity}");
            }

            Console.WriteLine("\n========== 4. Search Missing Product From Cache ==========\n");
            manager.GetProductFromCache("P999");

            Console.WriteLine("\n========== 5. Add New Product ==========\n");

            Product newProduct = new Product(
                -1,
                "P900",
                "Gaming Headset",
                "Accessories",
                650m,
                20,
                true,
                DateTime.Now,
                null
            );

            manager.AddProduct(newProduct);

            Console.WriteLine("\n========== 6. Try Adding Duplicate Product Code ==========\n");

            Product duplicateProduct = new Product(
                -1,
                "p900",
                "Duplicate Gaming Headset",
                "Accessories",
                700m,
                10,
                true,
                DateTime.Now,
                null
            );

            manager.AddProduct(duplicateProduct);

            Console.WriteLine("\n========== 7. Update Product Price ==========\n");
            manager.UpdateProductPrice("P900", 720m);

            Console.WriteLine("\n========== 8. Update Product Stock ==========\n");
            manager.UpdateStock("P900", 35);

            Console.WriteLine("\n========== 9. Deactivate Product ==========\n");
            manager.DeactivateProduct("P900");

            Console.WriteLine("\n========== 10. Try Deactivating Same Product Again ==========\n");
            manager.DeactivateProduct("P900");

            Console.WriteLine("\n========== 11. Show Active Products From Cache ==========\n");
            manager.ShowProducts(manager.GetActiveProductsFromCache());

            Console.WriteLine("\n========== 12. Show Products By Category From Cache ==========\n");
            manager.ShowProducts(manager.GetProductsByCategoryFromCache("accessories"));

            Console.WriteLine("\n========== 13. Show Low Stock Products ==========\n");
            manager.ShowProducts(manager.GetLowStockProductsFromCache(25));

            Console.WriteLine("\n========== 14. Compare Database Count Vs Cache Count Before Cache-Only Remove ==========\n");
            manager.CompareDatabaseVsCacheCount();

            Console.WriteLine("\n========== 15. Remove Product From Cache Only ==========\n");
            manager.RemoveProductFromCacheOnly("P900");

            Console.WriteLine("\n========== 16. Search Removed Product In Cache ==========\n");
            manager.GetProductFromCache("P900");

            Console.WriteLine("\n========== 17. Compare Database Count Vs Cache Count After Cache-Only Remove ==========\n");
            manager.CompareDatabaseVsCacheCount();

            Console.WriteLine("\n========== 18. Refresh Product From Database ==========\n");
            manager.RefreshProductFromDatabase("P900");

            Console.WriteLine("\n========== 19. Search Product Again After Refresh ==========\n");
            Product refreshedProduct = manager.GetProductFromCache("P900");

            if (refreshedProduct != null)
            {
                Console.WriteLine($"Found Again: {refreshedProduct.ProductCode} | {refreshedProduct.ProductName} | {refreshedProduct.Price} | Active: {refreshedProduct.IsActive}");
            }

            Console.WriteLine("\n========== 20. Compare Database Count Vs Cache Count After Refresh ==========\n");
            manager.CompareDatabaseVsCacheCount();

            Console.WriteLine("\n========== 21. Delete Product From Database And Cache ==========\n");
            manager.DeleteProductFromDatabaseAndCache("P900");

            Console.WriteLine("\n========== 22. Search Deleted Product In Cache ==========\n");
            manager.GetProductFromCache("P900");

            Console.WriteLine("\n========== 23. Compare Database Count Vs Cache Count After Permanent Delete ==========\n");
            manager.CompareDatabaseVsCacheCount();

            Console.WriteLine("\n========== 24. Refresh All Cache ==========\n");
            manager.RefreshAllCache();

            Console.WriteLine("\n========== 25. Show Final Cache Statistics ==========\n");
            manager.ShowCacheStatistics();

            Console.WriteLine("\n========== 26. Test Invalid Inputs ==========\n");

            manager.GetProductFromCache("");
            manager.UpdateProductPrice("P100", 0);
            manager.UpdateStock("P100", -5);
            manager.GetProductsByCategoryFromCache("   ");
            manager.GetLowStockProductsFromCache(-1);

            Console.WriteLine("\n========== TEST FINISHED ==========");
            Console.ReadLine();
        }
    }
}