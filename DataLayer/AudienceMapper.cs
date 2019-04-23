using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AudienceMapper
    {
        public Audience FindAudience(int auID)
        {
            string sql = ("Select * from Audience where audienceID = @auID");
            Audience audience = new Audience();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@auID", auID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            audience = MapAuToObject(reader);
                        }
                    }
                }
            }
            return audience;
        }

        private static Audience MapAuToObject(MySqlDataReader reader)
        {
            Audience audience = new Audience();
            int i = -1;
            audience.audienceID = reader.GetInt32(++i);
            audience.nameOfAudience = reader.GetString(++i);
            if (reader.IsDBNull(++i))
            {
                audience.interest = new Interest();
                audience.interest.interestID = reader.GetInt32(i);
            }
            if (reader.IsDBNull(++i))
            {
                audience.category = new Category();
                audience.interest.interestID = reader.GetInt32(i);
            }
            return audience;
        }
    }
}
