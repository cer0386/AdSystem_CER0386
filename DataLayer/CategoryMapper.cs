using DomainLayer;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DataLayer
{
    public class CategoryMapper
    {
        public Category FindCategory(int catID)
        {
            string sql = ("Select * from Category where categoryID = @catID");
            Category category = new Category();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@catID", catID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category = MapCatToObject(reader);
                        }
                    }
                }
            }
            return category;
        }

        public List<Category> FindCategories(int interestID)
        {
            string sql = ("Select c.categoryID, c.categoryName from category c join ininterest i on i.categoryID =c.categoryID where i.interestID = @interestID");
            List<Category> inInterests = new List<Category>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@interestID", interestID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category inInterest = new Category();
                            inInterest = MapCatToObject(reader);
                            inInterests.Add(inInterest);
                        }
                    }
                }
            }
            return inInterests;
        }

        public List<Category> FindCategories()
        {
            string sql = ("Select * from category");
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category();
                            category = MapCatToObject(reader);
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }

        private static Category MapCatToObject(MySqlDataReader reader)
        {
            Category category = new Category();
            int i = -1;
            category.categoryID = reader.GetInt32(++i);
            category.categoryName = reader.GetString(++i);
            return category;
        }
    }
}
