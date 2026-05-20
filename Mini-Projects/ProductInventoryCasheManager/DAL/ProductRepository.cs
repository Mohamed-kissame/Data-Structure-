using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class ProductRepository
    {
        private static string connectionString
        {
            get
            {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

                builder.DataSource = ".";
                builder.InitialCatalog = "ProductInventoryDB";

                
                builder.UserID = "sa";
                builder.Password = "sa123456";
                builder.IntegratedSecurity = false;
                return builder.ToString();
            }
        }

        static public List<Product> GetAllProducts()
        {
          

            List<Product> pr = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductId, ProductCode, ProductName, Category, Price, StockQuantity, IsActive, CreatedAt, UpdatedAt FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {

                                pr.Add(
                                      new Product(
                                    (int)reader["ProductId"],
                                    (string)reader["ProductCode"],
                                    (string)reader["ProductName"],
                                    (string)reader["Category"],
                                    (decimal)reader["Price"],
                                    (int)reader["StockQuantity"],
                                    (bool)reader["IsActive"],
                                    (DateTime)reader["CreatedAt"],
                                    reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["UpdatedAt"]
                              
                                  ));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                      
                        Console.WriteLine(ex.Message);
                    }
                }
            }


            return pr;
        }

        static public Product GetProductByCode(string ProductCode)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductCode = @ProductCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", ProductCode);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product(
                                    (int)reader["ProductId"],
                                    (string)reader["ProductCode"],
                                    (string)reader["ProductName"],
                                    (string)reader["Category"],
                                    (decimal)reader["Price"],
                                    (int)reader["StockQuantity"],
                                    (bool)reader["IsActive"],
                                    (DateTime)reader["CreatedAt"],
                                    reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["UpdatedAt"]
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return product;
        }
    
            


        static public int InsertProduct(Product product)
        {
            int newId = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductCode, ProductName, Category, Price, StockQuantity, IsActive, CreatedAt, UpdatedAt) VALUES (@ProductCode, @ProductName, @Category, @Price, @StockQuantity, @IsActive, @CreatedAt, @UpdatedAt); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    command.Parameters.AddWithValue("@IsActive", product.IsActive);
                    command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);

                    if (product.UpdatedAt != null)
                    {
                        command.Parameters.AddWithValue("@UpdatedAt", product.UpdatedAt);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@UpdatedAt", DBNull.Value);
                    }

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int insertedId))
                            {
                                newId = insertedId;
                            }
                            else
                            {
                                newId = -1;
                            }
                        }
                        catch (Exception ex)
                        {
                            newId = -1;
                        }
                }
            }

            return newId;
        }

        static public bool UpdateProductStock(string ProductCode , int newStock)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET " +
                               " StockQuantity = @StockQuantity ,  UpdatedAt = GETDATE() WHERE ProductCode = @ProductCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                 
                    command.Parameters.AddWithValue("@ProductCode", ProductCode);
                   
                    command.Parameters.AddWithValue("@StockQuantity", newStock);
                
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }


        static public bool UpdateProductPrice(string ProductCode, decimal newPrice)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET " +
                               " Price = @Price ,  UpdatedAt = GETDATE() WHERE ProductCode = @ProductCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ProductCode", ProductCode);

                    command.Parameters.AddWithValue("@Price", newPrice);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }


        static public bool DeactivateProduct(string ProductCode)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET " +
                               " IsActive = 0 , UpdatedAt = GETDATE() WHERE ProductCode = @ProductCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ProductCode", ProductCode);

                   

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        static public int GetProductsCount()
        {
            int Count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select Count(*) From Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                   

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CountResult))
                        {
                            Count = CountResult;
                        }
                        else
                        {
                            Count = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
            }

            return Count;
        }

        static public bool DeleteProduct(string ProductCode)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductCode = @ProductCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", ProductCode);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

    }
}
