using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
             new { departmentName = newDepartmentName });
        }






        public void CreateProduct(string? productName, double price, int catID)
        {
            throw new NotImplementedException();
        }

        public object GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}

