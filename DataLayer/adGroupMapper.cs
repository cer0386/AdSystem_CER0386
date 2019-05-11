using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AdGroupMapper
    {
        public AdGroup FindAdGroup(int adID)
        {
            string sql = ("Select * from AdGroup where adID = @adID");
            AdGroup adGroup = new AdGroup();
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
                            adGroup = MapAdGtoObject(reader);
                        }
                    }
                }
            }
            return adGroup;
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
