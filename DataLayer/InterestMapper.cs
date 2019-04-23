using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class InterestMapper
    {
        public Interest FindInterest(int iID)
        {
            string sql = ("Select * from Interest where interestID = @iID");
            Interest interest = new Interest();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@iID", iID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interest = MapItoObject(reader);
                        }
                    }
                }
            }
            return interest;
        }

        private static Interest MapItoObject(MySqlDataReader reader)
        {
            Interest interest = new Interest();
            int i = -1;
            interest.interestID = reader.GetInt32(++i);
            interest.interestName = reader.GetString(++i);
            if (!reader.IsDBNull(++i))
                interest.description = reader.GetString(i);
            return interest;
        }
    }
}
