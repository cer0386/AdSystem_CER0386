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

        private static AdGroup MapAdGtoObject(MySqlDataReader reader)
        {
            AdGroup adGroup = new AdGroup();
            int i = -1;
            adGroup.adGroupId = reader.GetInt32(++i);
            adGroup.adGroupName = reader.GetString(++i);
            adGroup.adGroupStatus = reader.GetBoolean(++i);
            if(!reader.IsDBNull(++i))
                adGroup.adGroupBudget = reader.GetInt32(i);
            if (!reader.IsDBNull(++i))
                adGroup.maxCostPer = reader.GetInt32(i);
            adGroup.requiredViews = reader.GetInt32(++i);
            adGroup.company = new Company();
            adGroup.company.crn = reader.GetInt32(++i);

            return adGroup;
        }
    }
}
