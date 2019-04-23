using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class VisitMapper
    {
        public Visit FindVisit(int vID)
        {
            string sql = ("Select * from Visit where visitIDOF = @vID");
            Visit visit = new Visit();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@vID", vID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            visit = MapVisitToObject(reader);
                        }
                    }
                }
            }
            return visit;
        }

        private static Visit MapVisitToObject(MySqlDataReader reader)
        {
            Visit visit = new Visit();
            int i = -1;
            visit.visitIDOF = reader.GetInt32(++i);
            visit.visitor = new Visitor();
            visit.visitor.visitorId = reader.GetInt32(++i);
            visit.webPage = new WebPage();
            visit.webPage.webPageID = reader.GetInt32(++i);
            if (!reader.IsDBNull(++i))
                visit.visited = reader.GetDateTime(i);
            return visit;
        }
    }
}
