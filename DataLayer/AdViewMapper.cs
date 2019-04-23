using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AdViewMapper
    {
        public AdView FindAd(int vID)
        {
            string sql = ("Select * from AdView where viewIDOF = @vID");
            AdView adView = new AdView();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@vID", vID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adView = MapCtoObject(reader);
                        }
                    }
                }
            }
            return adView;
        }

        private static AdView MapCtoObject(MySqlDataReader reader)
        {
            AdView adView = new AdView();
            int i = -1;
            adView.viewIDOF  = reader.GetInt32(++i);
            adView.ad = new Ad();
            adView.ad.adId = reader.GetInt32(++i);
            adView.visitor = new Visitor();
            adView.visitor.visitorId = reader.GetInt32(++i);
            adView.viewed = reader.GetDateTime(++i);
            return adView;
        }
    }
}
