using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AdClickMapper
    {
        public AdClick FindAdClick(int adCID)
        {
            string sql = ("Select * from AdClick where clickIDOF = @adCID");
            AdClick adClick = new AdClick();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@adCID", adCID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adClick = MapAdCtoObject(reader);
                        }
                    }
                }
            }
            return adClick;
        }

        private static AdClick MapAdCtoObject(MySqlDataReader reader)
        {
            AdClick adClick = new AdClick();
            int i = -1;
            adClick.clickIDOF = reader.GetInt32(++i);
            adClick.ad = new Ad();
            adClick.ad.adId = reader.GetInt32(++i);
            adClick.visitor = new Visitor();
            adClick.visitor.visitorId = reader.GetInt32(++i);
            adClick.clicked = reader.GetDateTime(++i);
            return adClick;
        }
    }
}
