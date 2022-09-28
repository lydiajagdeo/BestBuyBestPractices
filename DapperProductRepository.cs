using System;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {

        private readonly IDbConnection _connection;


        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }


        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM products WHERE product ID = @id", new { id = id});
        }



        public void UpdateProductName(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name,"+
                "Price = @price," +
                "CategoryID = @categoryID,"+
                "OnSale = @onSale," +
                "StockLevel = @stockLevel,"+
                "WHERE ProductId = @productId",


                new {
                name = product.Name,
                price = product.Price,
                categoryID = product.CategoryID,
                productID = product.ProductID,
                onSale = product.OnSale,
                stockleverl = product.StockLevel
                });
        }




        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @id;",
                new { id = id });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @id;",
               new { id = id });

            _connection.Execute("DELETE FROM products WHERE ProductID = @id;",
               new { id= id });
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

