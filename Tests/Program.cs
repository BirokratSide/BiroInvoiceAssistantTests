using System;
using System.IO;
using System.Net.Http;
using System.Threading;

using Common.utils;
using Microsoft.Extensions.Configuration;
using Tests;
using Tests.tests;

namespace SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            IConfiguration Configuration = builder.Build();

            string dbaddr = Configuration.GetValue<string>("DatabaseConnection:Address");
            if (dbaddr == "192.168.0.124") {
                Console.WriteLine("Attempt to connect to production database!!! This program contains logic that deletes whole tables. Very dangerous, cannot allow operation! Press any key to exit.");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (dbaddr == "") {
                Console.WriteLine("Database address is empty. Press any key to exit tests.");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            HappyPathTest tst = new HappyPathTest();
            tst.Start();

            //SadPathTest tst = new SadPathTest();
            //tst.Start();
        }
    }
}