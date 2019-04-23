using DataLayer.Properties;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyMapper mapper = new CompanyMapper();
            List<Company> companies = mapper.FindAllCompanies();

            foreach(Company c in companies)
            {
                Console.WriteLine(c.crn +" "+ c.companyName + " " + c.vip);
            }
            Console.ReadLine();
        }
    }
}
