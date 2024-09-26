using MySql.Data.MySqlClient;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartStock.Controller
{
    internal class ShelfController
    {
        private MySQLDatabase db;

        public ShelfController()
        {
            db = new MySQLDatabase();
        }

        public List<Shelf> GetAllShelves()
        {
            List<Shelf> shelfList = new List<Shelf>();

            // Construct SELECT query
            string query = "SELECT * FROM Shelf ORDER BY OOS DESC";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Shelf object and populate it with data from the database
                    Shelf shelf = new Shelf
                    {
                        Area = reader.GetInt32("Area"),
                        OOS = reader.GetInt32("OOS"),
                        TotalItem = reader.GetInt32("TotalItem")
                    };

                    // Add the shelf object to the list
                    shelfList.Add(shelf);
                }
            }

            return shelfList;
        }

        public List<ShelfItem> GetShelfItem(int Area)
        {
            List<ShelfItem> shelfItemList = new List<ShelfItem>();

            // Define the list of product names for Area 1
            List<string> area1Products = new List<string>()
            {
                "V_SOY_ORIGINAL",
                "V_SOY_LOW_SUGUR",
                "V_SOY_MULTI",
                "V_SOY_GOLDEN",
                "HOMESOY_ORIGINAL",
                "HOMESOY_MUILTI",
                "HOMESOY_HONEY_MELON",
                "HOMESOY_BROWN_SUGUR",
                "MARIGOLD_ICE_LEMON_TEA",
                "MARIGOLD_LYCHEE",
                "MARIGOLD_SOYA_BEAN",
                "MARIGOLD_CHRYSANTHEMUM",
                "HERSHEY_CHOCOLATE",
                "AYATAKA",
                "JIA_DUO_BAO",
                "POKKA_BANANA",
                "POKKA_GREEN_TEA",
                "POKKA_KURMA",
                "POKKA_ROS",
                "POKKA_MANGGA",
                "SEASONS_LAICI",
                "SEASONS_ROS",
                "SEASONS_KRISANTIMUM",
                "SEASONS_KACANG",
                "DELITE_BLACKBERRY",
                "DELITE_ORANGE",
                "DELITE_MANGO",
                "DELITE_APPLE",
                "DELITE_SOYA",
                "DELITE_KRISANTIMUM",
                "DELITE_CRANBERI_APPLE",
                "DELITE_CRANBERI_AELIMA",
                "DELITE_BLACKCURRENT",
                "DELITE_MIXED_FRUIT",
                "HERSHEY_CHOCOLATE",
                "rexberry",
                "rextea",
                "epal"
            };

            // Define the list of product names for Area 2
            List<string> area2Products = new List<string>()
            {
                "MILO",
                "WHITE_COFFEE",
                "CHOCOLATE_MILK",
                "MILK",
                "NESCAFE",
                "CHOCOLATE_DRINK"
            };

            List<string> area3Products = new List<string>()
            {
                "V_SOY_ORIGINAL",
                "V_SOY_LOW_SUGUR",
                "V_SOY_MULTI",
                "V_SOY_GOLDEN",
                "HOMESOY_ORIGINAL",
                "HOMESOY_MUILTI",
                "HOMESOY_HONEY_MELON",
                "HOMESOY_BROWN_SUGUR",
                "MARIGOLD_ICE_LEMON_TEA",
                "MARIGOLD_LYCHEE",
                "MARIGOLD_SOYA_BEAN",
                "MARIGOLD_CHRYSANTHEMUM",
                "HERSHEY_CHOCOLATE",
                "AYATAKA",
                "JIA_DUO_BAO"
            };

            List<string> area4Products = new List<string>()
            {
                "PEANUT_BBQ",
                "PEANUT_CHICKEN",
                "SALTED_CASHEWS_KACANG",
                "SALTED_PISTACHIOS_MRBEST",
                "GARLIC_CASHEWS",
                "SALTED_CASHEWS",
                "SALTED_MACADAMAS",
                "HONEY_MACADAMIA",
                "SALTED_CASHEW_NUTS",
                "HONEY_ROASTED_CASHEW_NUTS",
                "SALTED_PISTACHIOS",
                "SALTED_CASHEW_NUTS_MIXED_MACADAMIAS",
                "HONEY_CASHEW_NUTS_MIXED_MACADAMIAS",
                "CASHEW_NUTS_MIXED_ALMONDS",
                "SALTED_ALMONDS",
                "HONEY_ALMONDS",
                "PARTY_SNACK"
            };



            // Construct the SELECT query with a WHERE clause based on Area
            string query;
            if (Area == 1)
            {
                //query = $"SELECT * FROM ShelfItem WHERE Area ={Area} ORDER BY Quantity ASC";
                query = $"SELECT * FROM ShelfItem WHERE Area ={Area} AND ProductName IN ({string.Join(",", area1Products.Select(p => "'" + p + "'"))}) ORDER BY Quantity ASC";
            }
            else if (Area == 2)
            {
                query = $"SELECT * FROM ShelfItem WHERE Area ={Area} AND ProductName IN ({string.Join(",", area2Products.Select(p => "'" + p + "'"))}) ORDER BY Quantity ASC";
            }
            else if (Area == 3)
            {
                query = $"SELECT * FROM ShelfItem WHERE Area ={Area} AND ProductName IN ({string.Join(",", area3Products.Select(p => "'" + p + "'"))}) ORDER BY Quantity ASC";
            }
            else if (Area == 4)
            {
                query = $"SELECT * FROM ShelfItem WHERE Area ={Area} AND ProductName IN ({string.Join(",", area4Products.Select(p => "'" + p + "'"))}) ORDER BY Quantity ASC";
            }
            else
            {
                query = $"SELECT * FROM ShelfItem WHERE Area ={Area} ORDER BY Quantity ASC";
            }

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new ShelfItem object and populate it with data from the database
                    ShelfItem shelfItem = new ShelfItem
                    {
                        Area = reader.GetInt32("Area"),
                        ProductName = reader.GetString("ProductName"),
                        Quantity = reader.GetInt32("Quantity")
                    };

                    // Add the shelf object to the list
                    shelfItemList.Add(shelfItem);
                }
            }

            return shelfItemList;
        }




    }
}
