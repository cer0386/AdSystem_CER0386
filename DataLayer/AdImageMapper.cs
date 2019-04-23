using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class AdImageMapper
    {
        public AdImage FindAdImage(int adiID)
        {
            string sql = ("Select * from AdImage where imageID = @adiID");
            AdImage adImage = new AdImage();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@adiID", adiID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adImage = MapAdItoObject(reader);
                        }
                    }
                }
            }
            return adImage;
        }

        private static AdImage MapAdItoObject(MySqlDataReader reader)
        {
            AdImage adImage = new AdImage();
            int i = -1;
            adImage.imageId = reader.GetInt32(++i);
            adImage.imagePath = reader.GetString(++i);
            if(!reader.IsDBNull(++i))
                adImage.description = reader.GetString(i);
            return adImage;
        }
    }
}
