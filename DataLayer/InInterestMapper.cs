using DomainLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InInterestMapper
    {

        public InInterest FindInInterest(int iiID)
        {
            string sql = ("Select * from InInterest where inInterestID = @cID");
            InInterest inInterest = new InInterest();
            using (MySqlConnection connection = DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@iiID", iiID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inInterest = MapInIntToObject(reader);
                        }
                    }
                }
            }
            return inInterest;
        }

        
    


        private static InInterest MapInIntToObject(MySqlDataReader reader)
        {
            InInterest inInterest = new InInterest();
            int i = -1;
            inInterest.inInterestID = reader.GetInt32(++i);
            inInterest.interest = new Interest();
            inInterest.interest.interestID = reader.GetInt32(++i);
            inInterest.category = new Category();
            return inInterest;
        }
    }    
}
