using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Loan_Manage.Utility
{
    internal class DbConnUtil
    {
        private static IConfiguration _iConfiguration;

        //constructor 
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            _iConfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnString");
        }
    }
}
