using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace doga_2024_10_1
{
    public class databaseHandler
    {
        MySqlConnection connection;
        string tableName = "pekaru";
        public databaseHandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string database = "pekseg";

            string connectionString = $"user={username};password={password};server={host};database={database}";

            connection = new MySqlConnection(connectionString);
        }
        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string name = read.GetString(read.GetOrdinal("name"));
                    int amount = read.GetInt32(read.GetOrdinal("amount"));
                    int price = read.GetInt32(read.GetOrdinal("price"));

                    bakery oneBakery = new bakery();

                    oneBakery.id = id;
                    oneBakery.name = name;
                    oneBakery.amount = amount;
                    oneBakery.price = price;

                    bakery.bakerys.Add(oneBakery);


                }
                connection.Close();
                command.Dispose();
                read.Close();
                MessageBox.Show("Noice");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error: ");
            }

        }
        public void addOne(bakery oneBakery)
        {
            try
            {
                connection.Open();

                string query = $"INSERT INTO {tableName} (`id`,`name`, `amount`, `price`) VALUES ('{oneBakery.id}','{oneBakery.name}','{oneBakery.amount}','{oneBakery.price}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void deleteAll(bakery oneBakery)
        {
            try
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE ID = {oneBakery.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                bakery.bakerys.Remove(oneBakery);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            
        }
    }
}
