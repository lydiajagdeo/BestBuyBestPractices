
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

Console.WriteLine( "ENter a new department");
var newDepartment = Console.ReadLine();

departmentRepo.InsertDepartment(newDepartment);

IEnumerable<Department> departments = departmentRepo.GetAllDepartments();
foreach (var item in departments)
{
    Console.WriteLine(item.DepartmentID);
    Console.WriteLine(item.Name);
}