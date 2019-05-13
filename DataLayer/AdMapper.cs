using DomainLayer;
using DomainLayer.HelpClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public int FindNoViews(int adID)
        {
            string sql = ("SELECT count(av.viewIDOF) FROM ad join adview av on ad.adID = av.adID where ad.adID = @adID");
            int views = 0;
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
                            views = reader.GetInt32(0);
                        }
                    }
                }
            }
            return views;
        }

        public int FindNoClicks(int adID)
        {
            string sql = ("SELECT count(av.clickIDOF) FROM ad join adclick av on ad.adID = av.adID where ad.adID = @adID");
            int clicks = 0;
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
                            clicks = reader.GetInt32(0);
                        }
                    }
                }
            }
            return clicks;
        }

        public List<GraphDataViews> FindViewsG(int adID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.viewed, count(av.viewIDOF) FROM ad join adview av on ad.adID = av.adID where ad.adID = @adID AND av.viewed >= @from AND av.viewed <= @to group by av.viewed");
            GraphDataViews dataView = new GraphDataViews();
            List<GraphDataViews> dataViews = new List<GraphDataViews>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@adID", adID);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataView = MapToGDV(reader);
                            dataViews.Add(dataView);
                        }
                    }
                }
            }
            return dataViews;
        }

        public List<GraphDataClicks> FindClicksG(int adID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.clicked, count(av.clickIDOF) FROM ad join adclick av on ad.adID = av.adID where ad.adID = @adID AND av.clicked >= @from AND av.clicked <= @to group by av.clicked");
            GraphDataClicks dataClick = new GraphDataClicks();
            List<GraphDataClicks> dataClicks = new List<GraphDataClicks>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@adID", adID);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataClick = MapToGDC(reader);
                            dataClicks.Add(dataClick);
                        }
                    }
                }
            }
            return dataClicks;
        }

        public List<Ad> FindAds(int aGID)
        {
            string sql = ("Select * from Ad where adGroupID = @aGID");
            List<Ad> ads = new List<Ad>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@aGID", aGID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ad ad = new Ad();
                            ad = MapCtoObject(reader);
                            ads.Add(ad);
                        }
                    }
                }
            }
            return ads;
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

        private static GraphDataViews MapToGDV(MySqlDataReader reader)
        {
            GraphDataViews dataViews = new GraphDataViews();
            int i = -1;
            dataViews.date = reader.GetDateTime(++i);
            dataViews.views = reader.GetInt32(++i);

            return dataViews;
        }

        private static GraphDataClicks MapToGDC(MySqlDataReader reader)
        {
            GraphDataClicks dataViews = new GraphDataClicks();
            int i = -1;
            dataViews.date = reader.GetDateTime(++i);
            dataViews.clicks = reader.GetInt32(++i);

            return dataViews;
        }

        private static Ad MapCtoObject(MySqlDataReader reader)
        {
            Ad ad = new Ad();
            int i = -1;
            ad.adId = reader.GetInt32(++i);
            ad.targetUrl = reader.GetString(++i);
            ad.title = reader.GetString(++i);
            ad.longTitle = reader.GetString(++i);
            ad.description = reader.GetString(++i);
            ad.companyName = reader.GetString(++i);
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
