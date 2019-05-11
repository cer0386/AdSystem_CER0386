using DomainLayer;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DataLayer
{
    public class AssignedExcludedMapper
    {
        public AssignedExcluded FindAssignedExcluded(int aeID)
        {
            string sql = ("Select * from AssignedExcluded where aeIDOF = @aeID");
            AssignedExcluded assignedExcluded = new AssignedExcluded();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@aeID", aeID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assignedExcluded = MapAEtoObject(reader);
                        }
                    }
                }
            }
            return assignedExcluded;
        }

        public List<AssignedExcluded> FindAssignedExcludedAGID(int agID)
        {
            string sql = ("Select * from AssignedExcluded where adGroupID = @agID");
            List<AssignedExcluded> assignedExcluded = new List<AssignedExcluded>();
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
                            AssignedExcluded ae = new AssignedExcluded();
                            ae = MapAEtoObject(reader);
                            assignedExcluded.Add(ae);
                        }
                    }
                }
            }
            return assignedExcluded;
        }

        private static AssignedExcluded MapAEtoObject(MySqlDataReader reader)
        {
            AssignedExcluded assignedExcluded = new AssignedExcluded();
            int i = -1;
            assignedExcluded.audienceIDOF = reader.GetInt32(++i);
            assignedExcluded.audience = new Audience();
            assignedExcluded.audience.audienceID = reader.GetInt32(++i);
            assignedExcluded.adGroup = new AdGroup();
            assignedExcluded.adGroup.adGroupId = reader.GetInt32(++i);
            assignedExcluded.action = reader.GetBoolean(++i);
            return assignedExcluded;
        }
    }
}
