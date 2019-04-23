using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class VisitorMapper
    {
        public Visitor FindVisitor(int vID)
        {
            string sql = ("Select * from Visitor where visitorID = @visitorID");
            Visitor visitor = new Visitor();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@visitorID", vID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            visitor = MapVtoObject(reader);
                        }
                    }
                }
            }
            return visitor;
        }

        private static Visitor MapVtoObject(MySqlDataReader reader)
        {
            Visitor visitor = new Visitor();
            int i = -1;
            visitor.visitorId = reader.GetInt32(++i);
            if (!reader.IsDBNull(++i))
                visitor.name = reader.GetString(i);
            if (!reader.IsDBNull(++i))
                visitor.location = reader.GetString(i);
            return visitor;
        }
    }
}
