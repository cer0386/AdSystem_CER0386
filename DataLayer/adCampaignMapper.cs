using DomainLayer;
using MySql.Data.MySqlClient;
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
