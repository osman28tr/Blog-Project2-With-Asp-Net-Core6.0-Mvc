using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services
{
    internal static class Configuration
    {
        internal static string ConnectionString
        {
            get 
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProgrammersBlog.Mvc"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MsSQL");
            }
        }
    }
}
