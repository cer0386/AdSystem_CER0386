using DomainLayer;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        public List<Visitor> FindVisitors(int aID)
        {
            string sql = ("Select v.* from Visitor v JOIN InAudience i on i.visitorID=v.visitorID where audienceID = @aID");
            List<Visitor> visitors = new List<Visitor>();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@aID", aID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Visitor visitor = new Visitor();
                            visitor = MapVtoObject(reader);
                            visitors.Add(visitor);
                        }
                    }
                }
            }
            return visitors;
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
