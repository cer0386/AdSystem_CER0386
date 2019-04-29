using DomainLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CampaignTypeMapper
    {
        
        public CampaignType FindCampaignType(int ctID)
        {
            string sql = ("Select * from CampaignType where campaignTypeID = @ctID");
            CampaignType campaignType = new CampaignType();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ctID", ctID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            campaignType = MapCampTToObject(reader);
                        }
                    }
                }
            }
            return campaignType;
        }

        public CampaignType FindCampaignType(string type)
        {
            string sql = ("Select * from CampaignType where type = @type");
            CampaignType campaignType = new CampaignType();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            campaignType = MapCampTToObject(reader);
                        }
                    }
                }
            }
            return campaignType;
        }

        public List<CampaignType> FindCampaignTypes()
        {
            string sql = ("Select * from CampaignType");
            List<CampaignType> campaignTypes = new List<CampaignType>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CampaignType campaignType = new CampaignType();
                            campaignType = MapCampTToObject(reader);
                            campaignTypes.Add(campaignType);
                        }
                    }
                }
            }
            return campaignTypes;
        }

        private static CampaignType MapCampTToObject(MySqlDataReader reader)
        {
            CampaignType campaignType = new CampaignType();
            int i = -1;
            campaignType.campaignTypeID = reader.GetInt32(++i);
            campaignType.type = reader.GetString(++i);
            return campaignType;
        }
    }
    
}
