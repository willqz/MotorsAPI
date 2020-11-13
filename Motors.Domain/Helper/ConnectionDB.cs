using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace Motors.Domain.Helper
{
    public static class ConnectionDB
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static string RetornaUrlConnetion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            string strgConn = Configuration.GetSection("ConnetionStrings").GetSection("DefaultConnection").Value;
            return strgConn;
        }

      
    }
}
