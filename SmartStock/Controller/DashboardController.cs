using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Community.CsharpSqlite.Sqlite3;
using System.Windows.Forms;
using SmartStock.Model;
using MySql.Data.MySqlClient;

namespace SmartStock.Controller
{
    internal class DashboardController
    {
        private MySQLDatabase db;
        public DashboardController()
        {
            db = new MySQLDatabase();
        }
        public bool AddRestock(Restock restock)
        {
            try
            {
                string formattedDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO Restock (ProductName, Quantity, dateTime) VALUES " +
                               $"('{restock.ProductName}', {restock.Quantity}, '{formattedDateTime}')";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding restock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Restock> GetRestocksByProductName(string productName)
        {
            List<Restock> restockList = new List<Restock>();

            // Get today's date in the format 'yyyy-MM-dd'
            string todayDate = System.DateTime.Now.ToString("yyyy-MM-dd");

            // Construct SELECT query
            string query = $"SELECT ProductName, Quantity, dateTime " +
                           $"FROM Restock " +
                           $"WHERE DATE(dateTime) = '{todayDate}'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Restock object and populate it with data from the database
                    Restock restock = new Restock
                    {
                        ProductName = reader.GetString("ProductName"),
                        Quantity = reader.GetInt32("Quantity"),
                        dateTime = reader.GetDateTime("dateTime"),
                    };

                    // Add the restock object to the list
                    restockList.Add(restock);
                }
            }

            return restockList;
        }

        public List<Restock> GetTopRestockedProductsToday()
        {
            List<Restock> restockList = new List<Restock>();

            // Get today's date in the format 'yyyy-MM-dd'
            string todayDate = System.DateTime.Now.ToString("yyyy-MM-dd");

            // Construct SELECT query to get top 5 restocked products for today
            string query = $"SELECT ProductName, SUM(Quantity) AS TotalQuantity " +
                           $"FROM Restock " +
                           $"WHERE DATE(dateTime) = '{todayDate}' " +
                           $"GROUP BY ProductName " +
                           $"ORDER BY TotalQuantity DESC " +
                           $"LIMIT 5";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Restock object and populate it with data from the database
                    Restock restock = new Restock
                    {
                        ProductName = reader.GetString("ProductName"),
                        Quantity = reader.GetInt32("TotalQuantity")
                        // We are not setting dateTime as it's not relevant in the grouped result
                    };

                    // Add the restock object to the list
                    restockList.Add(restock);
                }
            }

            return restockList;
        }


        public List<AggregatedData> GetAggregatedDataByHoursIntervals()
        {
            List<AggregatedData> aggregatedDataList = new List<AggregatedData>();

            // Get the current date
            System.DateTime currentDate = System.DateTime.Now.Date;
            // Get the current hour
            int currentHour = System.DateTime.Now.Hour;

            // Construct the SQL query
            string query = @"
        SELECT
            DATE_FORMAT(all_hours.HourStart, '%Y-%m-%d %H:00:00') AS HourStart,
            COALESCE(
                (SELECT SUM(r.Quantity) FROM Restock r WHERE DATE_FORMAT(r.dateTime, '%Y-%m-%d %H') = DATE_FORMAT(all_hours.HourStart, '%Y-%m-%d %H')),
                0
            ) AS TotalQuantity,
            COALESCE(
                (SELECT MAX(c.Parked) FROM Car c WHERE DATE_FORMAT(c.dateTime, '%Y-%m-%d %H') = DATE_FORMAT(all_hours.HourStart, '%Y-%m-%d %H')),
                0
            ) AS ParkedCars,
            COALESCE(
                (SELECT MAX(p.Remain) FROM People p WHERE DATE_FORMAT(p.dateTime, '%Y-%m-%d %H') = DATE_FORMAT(all_hours.HourStart, '%Y-%m-%d %H')),
                0
            ) AS RemainingPeople
        FROM (
            -- Generate a sequence of hours for the current day, starting from 8:00 AM
            SELECT DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL hour HOUR), '%Y-%m-%d %H') AS HourStart
            FROM (
                SELECT 8 AS hour UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12 UNION ALL
                SELECT 13 UNION ALL SELECT 14 UNION ALL SELECT 15 UNION ALL SELECT 16 UNION ALL SELECT 17 UNION ALL
                SELECT 18 UNION ALL SELECT 19 UNION ALL SELECT 20 UNION ALL SELECT 21 UNION ALL SELECT 22 UNION ALL
                SELECT 23
            ) AS hours
        ) AS all_hours
        WHERE all_hours.HourStart <= DATE_FORMAT(CURDATE() + INTERVAL ?CurrentHour HOUR, '%Y-%m-%d %H:00:00')
        ORDER BY all_hours.HourStart;";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query, currentHour))
            {
                // Read the results and populate the aggregated data list
                while (reader.Read())
                {
                    AggregatedData aggregatedData = new AggregatedData
                    {
                        IntervalStart = reader.GetDateTime("HourStart"),
                        TotalQuantity = reader.GetInt32("TotalQuantity"),
                        ParkedCars = reader.GetInt32("ParkedCars"),
                        RemainingPeople = reader.GetInt32("RemainingPeople")
                    };
                    aggregatedDataList.Add(aggregatedData);
                }
            }
            return aggregatedDataList;
        }



        public int GetTotalRestockedQuantity()
        {
            int totalQuantity = 0;

            // Get today's date in the format 'yyyy-MM-dd'
            string todayDate = System.DateTime.Now.ToString("yyyy-MM-dd");

            // Construct SELECT query to get the total restocked quantity for today
            string query = $"SELECT SUM(Quantity) AS TotalQuantity " +
                           $"FROM Restock " +
                           $"WHERE DATE(dateTime) = '{todayDate}'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                if (reader.Read())
                {
                    // Read the total quantity
                    totalQuantity = reader.IsDBNull(reader.GetOrdinal("TotalQuantity")) ? 0 : reader.GetInt32("TotalQuantity");
                }
            }

            return totalQuantity;
        }


        public People GetCurrentPeople()
        {
            string query = "SELECT ClientIN, ClientOUT, Remain, dateTime FROM People ORDER BY dateTime DESC LIMIT 1";
            People newestPeople = null;

            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                if (reader.Read())
                {
                    newestPeople = new People
                    {
                        ClientIN = reader.GetInt32("ClientIN"),
                        ClientOUT = reader.GetInt32("ClientOUT"),
                        Remain = reader.GetInt32("Remain"),
                        dateTime = reader.GetDateTime("dateTime")
                    };
                }
            }
            return newestPeople;
        }

        public Car GetCurrentCar()
        {
            string query = "SELECT Parked, Free, dateTime FROM Car ORDER BY dateTime DESC LIMIT 1";
            Car newestCar = null;

            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                if (reader.Read())
                {
                    newestCar = new Car
                    {
                        Parked = reader.GetInt32("Parked"),
                        Free = reader.GetInt32("Free"),
                        dateTime = reader.GetDateTime("dateTime")
                    };
                }
            }

            return newestCar;
        }

        public int GetTotalOos()
        {
            string query = "SELECT SUM(OOS) AS total_oos FROM Shelf;";
            int totalOos = 0;

            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                if (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        // Handle null value (e.g., return a default value or log an error)
                        totalOos = 0; // Or any appropriate default value
                                      // You could also log an error message:
                        Console.WriteLine("No OOS data found in Shelf table.");
                    }
                    else
                    {
                        totalOos = reader.GetInt32(0);
                    }
                }

            }
            return totalOos;
        }

        public int GetTotalShelfItem()
        {
            string query = "SELECT SUM(TotalItem) AS total_Shelf FROM Shelf;";
            int totalShelf = 0;

            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                if (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        // Handle null value (e.g., return a default value or log an error)
                        totalShelf = 0; // Or any appropriate default value
                                      // You could also log an error message:
                        Console.WriteLine("No OOS data found in Shelf table.");
                    }
                    else
                    {
                        totalShelf = reader.GetInt32(0);
                    }
                }

            }
            return totalShelf;
        }

        public int GetTotalInventory()
        {
            string query = "SELECT SUM(Quantity) AS total_Inventory FROM Product;";
            int totalInventory = 0;

            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                if (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        // Handle null value (e.g., return a default value or log an error)
                        totalInventory = 0; // Or any appropriate default value
                                      // You could also log an error message:
                        Console.WriteLine("No OOS data found in Shelf table.");
                    }
                    else
                    {
                        totalInventory = reader.GetInt32(0);
                    }
                }

            }
            return totalInventory;
        }
    }
}
