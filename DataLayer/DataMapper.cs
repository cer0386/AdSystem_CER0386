using DomainLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer.Properties
{
    public class DataMapper
    {
        public List<Company> FindCompanies()
        {
            string sql = ("Select * from Company");
            List<Company> companies = new List<Company>();
            using (MySqlConnection connection =  DBConnector.GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql,connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Company company = new Company();
                            int i = -1;
                            company.crn = reader.GetInt32(++i);
                            company.companyName = reader.GetString(++i);
                            company.vip = reader.GetBoolean(++i);
                            companies.Add(company);
                        }
                    }
                }
            }
            return companies;
        }
    }
}
