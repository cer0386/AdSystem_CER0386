using DomainLayer;
using MySql.Data.MySqlClient;

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
