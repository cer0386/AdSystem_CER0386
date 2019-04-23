using DomainLayer;
using MySql.Data.MySqlClient;

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

        private static AdCampaign MapCampToObject(MySqlDataReader reader)
        {
            AdCampaign adCampaign = new AdCampaign();
            int i = -1;
            adCampaign.campaignId = reader.GetInt32(++i);
            adCampaign.type = reader.GetString(++i);
            adCampaign.status = reader.GetBoolean(++i);
            adCampaign.budget = reader.GetDouble(++i);
            adCampaign.costPer = reader.GetDouble(++i);
            adCampaign.start = reader.GetDateTime(++i);
            if(!reader.IsDBNull(++i))
                adCampaign.ending = reader.GetDateTime(i);
            adCampaign.company = new Company();
            adCampaign.company.crn = reader.GetInt32(++i);
            return adCampaign;
        }
    }
}
