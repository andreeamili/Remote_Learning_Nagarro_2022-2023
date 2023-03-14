using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ProductRepositoryDB : IProductRepository
    {
        public SQLiteConnection myConnection;
        private static List<Product> _products=new List<Product>();

        public  ProductRepositoryDB() 
        {
            myConnection=new SQLiteConnection("Data source= VandingMAchineDB.sqlite3");
            
            if(!File.Exists("VandingMAchineDB.sqlite3"))
            {
                SQLiteConnection.CreateFile("VandingMAchineDB.sqlite3");
                Console.WriteLine("DataBase file created");
            }
            ReadTheValues();
        }

        public void OpenConnection()
        {
            if(myConnection.State != System.Data.ConnectionState.Open )
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public void InsertTheValue(string columnId, string name, string price, string quantity  )
        {
            string query = "INSERT INTO Products (`ColumnId`,`Name`,`Price`,`Quantity`) VALUES (@ColumnId,@Name,@Price,@Quantity)";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@ColumnId", columnId);
            myCommand.Parameters.AddWithValue("@Name", name);
            myCommand.Parameters.AddWithValue("@Price", price);
            myCommand.Parameters.AddWithValue("@Quantity", quantity);
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public void ReadTheValues()
        {
            string query = "SELECT * FROM Products";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            OpenConnection();
            SQLiteDataReader readData = myCommand.ExecuteReader();
            if( readData.HasRows)
            {
                while( readData.Read())
                {
                     _products.Add(new Product {ColumnId= Convert.ToInt32(readData["ColumnId"]),
                                              Name= Convert.ToString(readData["Name"]), 
                                            Price= Convert.ToDecimal(readData["Price"]), 
                                          Quantity=Convert.ToInt32(readData["Quantity"]) }); 
                }
            }
            CloseConnection();
        }
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>(_products);
        }
        public Product GetByColumn(int column)
        {

            foreach (Product product in _products)
            {

                if (product.ColumnId == column)
                {
                    return product;
                }
            }
            return null;
        }
        public void UpdateProduct(Product newProduct, int columnId, int numberOfProducts)
        {
            if (numberOfProducts != 0)
            {
                foreach (Product product in _products)
                {
                    if (product.ColumnId == columnId)
                    {
                        product.Quantity += numberOfProducts;
                        Console.WriteLine();
                        Console.WriteLine("The product was supplied");
                        string query = "UPDATE Products SET Quantity=" + Convert.ToString(product.Quantity) + " WHERE ColumnId=" + Convert.ToString(columnId);
                        SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                        OpenConnection();
                        SQLiteDataReader readData = myCommand.ExecuteReader();
                        CloseConnection();
                        return;
                    }
                }
            }
            InsertTheValue(Convert.ToString(newProduct.ColumnId), newProduct.Name, Convert.ToString(newProduct.Price), Convert.ToString(newProduct.Quantity));
            Console.WriteLine();
            Console.WriteLine("The product was added");
        }
        public void DecrementPtoduct(Product requestProduct)
        {
            foreach (Product product in _products)
            {
                if (product.Name == requestProduct.Name)
                {
                    product.Quantity--;
                    string query = "UPDATE Products SET Quantity=" + Convert.ToString(product.Quantity) + " WHERE ColumnId=" + Convert.ToString(product.ColumnId);
                    SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                    OpenConnection();
                    SQLiteDataReader readData = myCommand.ExecuteReader();
                    CloseConnection();
                }
            }
        }

    }
}
