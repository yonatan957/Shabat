using Microsoft.Extensions.Configuration;
using Shabat.DAL;
using Shabat.DAL.Repositories;
using Shabat.forms;

namespace Shabat
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DBconnections>()
                .Build();
            string Conn = config["connectionstring"];
            DBconnections dBconnections = new DBconnections(Conn);
            CategoryRepository ca = new CategoryRepository(dBconnections);
            Application.Run(new HomePage(ca));
        }
    }
}