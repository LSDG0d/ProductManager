using Dapper;
using Microsoft.Data.Sqlite;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Data
{
    internal class DataBaseService
    {
        public static List<UserModel> GetUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>("Select * from User", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<ProductModel> GetProducts()
        {
            using (IDbConnection cnn =new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("Select * from Product", new DynamicParameters());
                return output.ToList();
            }
        }
        public static bool AddUser(UserModel user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into User (Login, Password, Role) values (@Login, @Password, @Role)", user);
            }
            return true;
        }
        public static bool AddProduct(ProductModel product)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("insert into Product (Name, Description, Cost, Count) values (@Name, @Description, @Cost, @Count)", product);
            }
            return true;
        }
        public static bool DeleteUser(int user)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("delete from User where Id = @Id", new {Id = user});
            }
            return true;
        }
        public static bool DeleteProduct(int product)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("delete from Product where Id = @Id", new { Id = product });
            }
            return true;
        }
        public static bool UpdateUser(UserModel user)
        {
            using(IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("Update User set Login = @Login, Password = @Password, Role = @Role where Id = @Id", user);
            }
            return true;
        }
        public static bool UpdateProduct(ProductModel product)
        {
            using( IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("Update Product set Name = @Name, Description = @Description, Count = @Count, Cost = @Cost where Id = @Id", product);
            }
            return true;
        }
        public static List<ProductModel> SearchProductsByName(string productName)
        {
            productName = "%" + productName + "%";
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<ProductModel>("select * from Product where Name like @query", new {query = productName});
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string Id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[Id].ConnectionString;
        }
    }
}
