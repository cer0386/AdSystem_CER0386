using DomainLayer;
using MySql.Data.MySqlClient;
using System.Text;

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

        public static int Insert(Ad ad)
        {

            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO ad (targetURL,title,longtitle, description, companyName, nOfViews, adGroupID, imageID) ");
                sb.Append("VALUES (@targetURL, @title, @longtitle, @description,@companyName,@nOfViews,@adGroupID,@imageID);");
                string sql = sb.ToString();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@targetURL", ad.targetUrl);
                    command.Parameters.AddWithValue("@title", ad.title);
                    command.Parameters.AddWithValue("@longtitle", ad.longTitle);
                    command.Parameters.AddWithValue("@description", ad.description);
                    command.Parameters.AddWithValue("@companyName", ad.companyName);
                    command.Parameters.AddWithValue("@nOfViews", ad.nOfViews);
                    command.Parameters.AddWithValue("@adGroupID", ad.adGroup.adGroupId);
                    if(ad.adImage != null)
                    command.Parameters.AddWithValue("@imageID", ad.adImage.imageId);
                    else
                        command.Parameters.AddWithValue("@imageID", null);

                    command.ExecuteNonQuery();
                }
            }
            return 0;
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
            return ad;
        }
    }
}
