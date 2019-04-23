using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AdMapper
    {
        public Ad FindAd(int adID)
        {
            string sql = ("Select * from Ad where adID = @adID");
            Ad ad = new Ad();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@adID", adID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ad = MapCtoObject(reader);
                        }
                    }
                }
            }
            return ad;
        }

        private static Ad MapCtoObject(MySqlDataReader reader)
        {
            Ad ad = new Ad();
            int i = -1;
            ad.adId = reader.GetInt32(++i);
            ad.targetUrl = reader.GetString(++i);
            ad.title = reader.GetString(++i);
            ad.title = reader.GetString(++i);
            ad.longTitle = reader.GetString(++i);
            ad.description = reader.GetString(++i);
            ad.companyName = reader.GetString(++i);
            if(!reader.IsDBNull(++i))
                ad.nOfViews = reader.GetInt32(i);
            ad.adGroup = new AdGroup();
            ad.adGroup.adGroupId = reader.GetInt32(++i);
            if (!reader.IsDBNull(++i))
            {
                ad.adImage = new AdImage();
                ad.adImage.imageId = reader.GetInt32(i);
            }
            ad.webPage = new WebPage();
            ad.webPage.webPageID = reader.GetInt32(++i);
            return ad;
        }
    }
}
