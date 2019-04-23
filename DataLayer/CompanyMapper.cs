using DomainLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class CompanyMapper
    {
        public Company FindCompany(string cName)
        {
            string sql = ("Select * from Company where companyName = @cName");
            Company company = new Company();
            using (MySqlConnection connection =  DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql,connection))
                {
                    cmd.Parameters.AddWithValue("@cName", cName);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            company = MapCtoObject(reader);
                        }
                    }
                }
            }
            return company;
        }

        private static Company MapCtoObject(MySqlDataReader reader)
        {
            Company company = new Company();
            int i = -1;
            company.crn = reader.GetInt32(++i);
            company.companyName = reader.GetString(++i);
            company.vip = reader.GetBoolean(++i);
            return company;
        }
    }
}
