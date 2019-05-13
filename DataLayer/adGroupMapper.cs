using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DomainLayer.HelpClasses;

namespace DataLayer
{
    public class AdGroupMapper
    {
        public AdGroup FindAdGroup(int agID)
        {
            string sql = ("Select * from AdGroup where adGroupID = @agID");
            AdGroup adGroup = new AdGroup();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@agID", agID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adGroup = MapAdGtoObject(reader);
                        }
                    }
                }
            }
            return adGroup;
        }

        public int FindNoViews(int agID)
        {
            string sql = ("SELECT count(av.viewIDOF) FROM adgroup ag join Ad ad on ag.adGroupID = ad.adGroupID JOIN adview av on av.adID = ad.adID WHERE ag.adGroupID = @agID");
            int views = 0;
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@agID", agID);
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
        public int FindNoClicks(int agID)
        {
            string sql = ("SELECT count(av.clickIDOF) FROM adgroup ag join Ad ad on ag.adGroupID = ad.adGroupID JOIN adClick av on av.adID = ad.adID WHERE ag.adGroupID = @agID");
            int clicks = 0;
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@agID", agID);
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

        public List<GraphDataViews> FindViewsG(int agID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.viewed, count(av.viewIDOF) FROM adgroup ag join ad on ag.adGroupID=ad.adID join adview av "+
                "on ad.adID = av.adID where ag.adGroupID = @agID AND av.viewed >= @from AND av.viewed <= @to group by av.viewed");
            GraphDataViews dataView = new GraphDataViews();
            List<GraphDataViews> dataViews = new List<GraphDataViews>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@agID", agID);
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

        public List<GraphDataClicks> FindClicksG(int agID, DateTime from, DateTime to)
        {
            string sql = ("SELECT av.clicked, count(av.clickIDOF) FROM adgroup ag join ad on ag.adGroupID=ad.adID join adclick av "+
                "on ad.adID = av.adID where ag.adGroupID = @agID AND av.clicked >= @from AND av.clicked <= @to group by av.clicked");
            GraphDataClicks dataClick = new GraphDataClicks();
            List<GraphDataClicks> dataClicks = new List<GraphDataClicks>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@agID", agID);
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

        public List<AdGroup> FindAdGroups(int cID)
        {
            string sql = ("SELECT * from adgroup Where campaignID = @cID");
            List<AdGroup> adGroups = new List<AdGroup>();
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
                            AdGroup adGroup = new AdGroup();
                            adGroup = MapAdGtoObject(reader);
                            adGroups.Add(adGroup);
                        }
                    }
                }
            }
            return adGroups;
        }

        public List<AdGroup> FindActiveAdGroups()
        {
            string sql = ("SELECT ag.* from adgroup ag JOIN adcampaign ac on ac.campaignID = ag.campaignID where (ending > @today OR ending IS NULL) AND STATUS = 1");
            List<AdGroup> adGroups = new List<AdGroup>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdGroup adGroup = new AdGroup();
                            adGroup = MapAdGtoObject(reader);
                            adGroups.Add(adGroup);
                        }
                    }
                }
            }
            return adGroups;
        }

        public int FindAdGroupMaxID()
        {
            string sql = ("Select MAX(adGroupID) from AdGroup");
            int maxID = 0;
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

        public static int Insert(AdGroup adGroup)
        {

            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO adGroup (adGroupName,adGroupStatus,adGroupBudget, maxCostPer, requiredViews, campaignID)");
                sb.Append("VALUES (@adGroupName, @adGroupStatus, @adGroupBudget, @maxCostPer,@requiredViews,@campaignID);");
                string sql = sb.ToString();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@adGroupName", adGroup.adGroupName);
                    command.Parameters.AddWithValue("@adGroupStatus", adGroup.adGroupStatus);
                    command.Parameters.AddWithValue("@adGroupBudget", adGroup.adGroupBudget);
                    command.Parameters.AddWithValue("@maxCostPer", adGroup.maxCostPer);
                    command.Parameters.AddWithValue("@requiredViews", adGroup.requiredViews);
                    command.Parameters.AddWithValue("@campaignID", adGroup.adCampaign.campaignId);

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

        private static AdGroup MapAdGtoObject(MySqlDataReader reader)
        {
            AdGroup adGroup = new AdGroup();
            int i = -1;
            adGroup.adGroupId = reader.GetInt32(++i);
            adGroup.adGroupName = reader.GetString(++i);
            adGroup.adGroupStatus = reader.GetBoolean(++i);
            if(!reader.IsDBNull(++i))
                adGroup.adGroupBudget = reader.GetDouble(i);
            if (!reader.IsDBNull(++i))
                adGroup.maxCostPer = reader.GetDouble(i);
            adGroup.requiredViews = reader.GetInt32(++i);
            adGroup.adCampaign = new AdCampaign();
            adGroup.adCampaign.campaignId = reader.GetInt32(++i);

            return adGroup;
        }
    }
}
