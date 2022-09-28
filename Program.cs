
using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyBestPractices;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

Console.WriteLine("ENter a new department");
var newDepartment = Console.ReadLine();

departmentRepo.InsertDepartment(newDepartment);

IEnumerable<Department> departments = departmentRepo.GetAllDepartments();
foreach (var item in departments)
{
    Console.WriteLine(item.DepartmentID);
    Console.WriteLine(item.Name);
}


var productRepo = new DapperProductRepository(conn);

Console.WriteLine("Enter name of new product: ");
var productName = Console.ReadLine();
Console.WriteLine("Enter the price of your new product: ");
var price = double.Parse(Console.ReadLine());
Console.WriteLine("Enter the Category ID: ");

var catID = int.Parse(Console.ReadLine());
productRepo.CreateProduct(productName, price, catID);




var productsToUpdate = productRepo.GetProduct(940);
productsToUpdate.Name = "Migas Taco";
productsToUpdate.Price = 4.00;
productsToUpdate.StockLevel = 50;

productRepo.UpdateProduct(productsToUpdate);


//DELETE
productRepo.DeleteProduct(940);



//READ
var productCollection = productRepo.GetAllProducts();

foreach (var product in productCollection)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
}