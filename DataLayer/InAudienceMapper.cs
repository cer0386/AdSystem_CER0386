using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class InAudienceMapper
    {
        public InAudience FindInAudience(int iaID)
        {
            string sql = ("Select * from InAudience where inAIDOF = @iaID");
            InAudience inAudience = new InAudience();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@iaID", iaID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inAudience = MapIAtoObject(reader);
                        }
                    }
                }
            }
            return inAudience;
        }

        private static InAudience MapIAtoObject(MySqlDataReader reader)
        {
            InAudience inAudience = new InAudience();
            int i = -1;
            inAudience.inAIDOF = reader.GetInt32(++i);
            inAudience.audience = new Audience();
            inAudience.audience.audienceID = reader.GetInt32(++i);
            inAudience.visitor = new Visitor();
            inAudience.visitor.visitorId = reader.GetInt32(++i);
            return inAudience;
        }
    }
}
