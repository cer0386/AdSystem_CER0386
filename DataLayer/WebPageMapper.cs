using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class WebPageMapper
    {
        public WebPage FindWebPage(int wpID)
        {
            string sql = ("Select * from webpage where webPageID = @wpID");
            WebPage webPage = new WebPage();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@wpID", wpID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            webPage = MapWPtoObject(reader);
                        }
                    }
                }
            }
            return webPage;
        }

        private static WebPage MapWPtoObject(MySqlDataReader reader)
        {
            WebPage webPage = new WebPage();
            int i = -1;
            webPage.webPageID = reader.GetInt32(++i);
            webPage.url = reader.GetString(++i);
            if (!reader.IsDBNull(++i))
                webPage.product = reader.GetString(i);
            webPage.category = new Category();
            webPage.category.categoryID = reader.GetInt32(++i);
            return webPage;
        }
    }
}
