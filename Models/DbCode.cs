using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class DbCode
    {
        public static SqlConnection GetConnction()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=true";

            conn.Open();

            return conn;
        }
        public static List<Product> GetProducts()
        {
            SqlConnection conn = GetConnction();

            SqlCommand selectProducts = new SqlCommand();
            selectProducts.Connection = conn;
            selectProducts.CommandType = System.Data.CommandType.StoredProcedure;
            selectProducts.CommandText = "GetProducts";

            SqlDataReader reader = selectProducts.ExecuteReader();

            Product product = null;
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                product = new Product();

                product.ProductId = (int)reader["ProductId"];
                product.ProductName = (string)reader["ProductName"];
                product.Rate = (decimal)reader["Rate"];
                product.Description = (string)reader["Description"];
                product.CategoryName = (string)reader["CategoryName"];

                products.Add(product);
            }

            reader.Close();
            conn.Close();

            return products;
        }

        public static Product GetProduct(int id)
        {
            SqlConnection conn = GetConnction();

            SqlCommand selectProduct = new SqlCommand();
            selectProduct.Connection = conn;
            selectProduct.CommandType = System.Data.CommandType.StoredProcedure;
            selectProduct.CommandText = "GetProduct";
            selectProduct.Parameters.AddWithValue("ProductId",id);

            SqlDataReader reader = selectProduct.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = (string)reader["ProductName"];
                product.Rate = (decimal)reader["Rate"];
                product.Description = (string)reader["Description"];
                product.CategoryName = (string)reader["CategoryName"];
            }

            reader.Close();

            return product;
        }

        public static void UpdateProduct(int id, Product product)
        {
            SqlConnection conn = GetConnction();

            SqlCommand updateProduct = new SqlCommand();
            updateProduct.Connection = conn;
            updateProduct.CommandType = System.Data.CommandType.StoredProcedure;
            updateProduct.CommandText = "UpdateProduct";
            updateProduct.Parameters.AddWithValue("ProductName", product.ProductName);
            updateProduct.Parameters.AddWithValue("Rate", product.Rate);
            updateProduct.Parameters.AddWithValue("Description", product.Description);
            updateProduct.Parameters.AddWithValue("CategoryName", product.CategoryName);
            updateProduct.Parameters.AddWithValue("ProductId", product.ProductId);

            updateProduct.ExecuteNonQuery();

            conn.Close();
        }
    }
}