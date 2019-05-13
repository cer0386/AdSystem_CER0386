using DomainLayer;
using DomainLayer.HelpClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class AdCampaignMapper
    {
        public AdCampaign FindAdCampaign(int cID)
        {
            string sql = ("Select * from AdCampaign where campaignID = @cID");
            AdCampaign adCampaign = new AdCampaign();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@cID", cID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adCampaign = MapCampToObject(reader);
                        }
                    }
                }
            }
            return adCampaign;
        }

        public int FindAdCampaignMaxID()
        {
            string sql = ("Select MAX(campaignID) from AdCampaign");
            int maxID =0;
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maxID = reader.GetInt32(0);
                        }
                    }
                }
            }
            return maxID;
        }

        public int FindNoViews(int acID)
        {
            string sql = ("SELECT count(av.viewIDOF) FROM adcampaign ac JOIN adgroup ag on ac.campaignID = ag.campaignID join Ad ad on ag.adGroupID = ad.adGroupID "+
                "JOIN adview av on av.adID = ad.adID WHERE ac.campaignID = @acID");
            int views = 0;
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@acID", acID);
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
        public int FindNoClicks(int acID)
        {
            string sql = ("SELECT count(av.clickIDOF) FROM adcampaign ac JOIN adgroup ag on ac.campaignID = ag.campaignID join Ad ad on ag.adGroupID = ad.adGroupID "+
                "JOIN adclick av on av.adID = ad.adID WHERE ac.campaignID = @acID");
            int clicks = 0;
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@acID", acID);
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

        public List<GraphDataViews> FindViewsG(int acID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.viewed, count(av.viewIDOF) FROM adcampaign ac JOin adgroup ag on ag.campaignID=ac.campaignID join ad "+
                "on ag.adGroupID=ad.adID join adview av on ad.adID = av.adID where ac.campaignID = @acID AND av.viewed >= @from AND av.viewed <= @to group by av.viewed");
            GraphDataViews dataView = new GraphDataViews();
            List<GraphDataViews> dataViews = new List<GraphDataViews>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@acID", acID);
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

        public List<GraphDataClicks> FindClicksG(int acID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.clicked, count(av.clickIDOF) FROM adcampaign ac JOin adgroup ag on ag.campaignID=ac.campaignID join ad "+
                "on ag.adGroupID=ad.adID join adclick av on ad.adID = av.adID where ac.campaignID = @acID AND av.clicked >= @from AND av.clicked <= @to group by av.clicked");
            GraphDataClicks dataClick = new GraphDataClicks();
            List<GraphDataClicks> dataClicks = new List<GraphDataClicks>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@acID", acID);
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

        public List<GraphDataViews> FindViewsG(DateTime from, DateTime to)
        {
            string sql = ("SELECT av.viewed, count(av.viewIDOF) FROM adcampaign ac JOin adgroup ag on ag.campaignID=ac.campaignID join ad " +
                "on ag.adGroupID=ad.adID join adview av on ad.adID = av.adID where av.viewed >= @from AND av.viewed <= @to group by av.viewed order by av.viewed");
            GraphDataViews dataView = new GraphDataViews();
            List<GraphDataViews> dataViews = new List<GraphDataViews>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
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

        public List<GraphDataClicks> FindClicksG(DateTime from, DateTime to)
        {
            string sql = ("SELECT av.clicked, count(av.clickIDOF) FROM adcampaign ac JOin adgroup ag on ag.campaignID=ac.campaignID join ad " +
                "on ag.adGroupID=ad.adID join adclick av on ad.adID = av.adID where av.clicked >= @from AND av.clicked <= @to group by av.clicked order by av.clicked");
            GraphDataClicks dataClick = new GraphDataClicks();
            List<GraphDataClicks> dataClicks = new List<GraphDataClicks>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
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

        public List<AdCampaign> FindAdCampaigns(int cID)
        {
            string sql = ("Select * from AdCampaign where companyID = @cID");
            List<AdCampaign> adCampaigns = new List<AdCampaign>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@cID", cID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdCampaign adCampaign = new AdCampaign();
                            adCampaign = MapCampToObject(reader);
                            adCampaigns.Add(adCampaign);
                        }
                    }
                }
            }
            return adCampaigns;
        }

        public static int Insert(AdCampaign campaign)
        {
            
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO adcampaign (name,status,budget, costPer, start, ending, companyID, campaignTypeID)");
                sb.Append("VALUES (@name, @status, @budget, @costPer,@start,@ending,@companyID,@campaignTypeID);");
                string sql = sb.ToString();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", campaign.name);
                    command.Parameters.AddWithValue("@status", campaign.status);
                    command.Parameters.AddWithValue("@budget", campaign.budget);
                    command.Parameters.AddWithValue("@costPer", campaign.costPer);
                    command.Parameters.AddWithValue("@start", campaign.start);
                    command.Parameters.AddWithValue("@ending", campaign.ending);
                    command.Parameters.AddWithValue("@companyID", campaign.company.crn);
                    command.Parameters.AddWithValue("@campaignTypeID", campaign.campaignType.campaignTypeID);

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

        private static AdCampaign MapCampToObject(MySqlDataReader reader)
        {
            AdCampaign adCampaign = new AdCampaign();
            int i = -1;
            adCampaign.campaignId = reader.GetInt32(++i);
            adCampaign.name = reader.GetString(++i);
            
            adCampaign.status = reader.GetBoolean(++i);
            adCampaign.budget = reader.GetDouble(++i);
            adCampaign.costPer = reader.GetDouble(++i);
            adCampaign.start = reader.GetDateTime(++i);
            i++;
            if(reader.IsClosed)
                adCampaign.ending = reader.GetDateTime(i);
            adCampaign.company = new Company();
            adCampaign.company.crn = reader.GetInt32(++i);
            adCampaign.campaignType = new CampaignType();
            adCampaign.campaignType.campaignTypeID = reader.GetInt32(++i);
            return adCampaign;
        }
    }
}
