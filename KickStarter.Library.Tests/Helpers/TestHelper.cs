using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace KickStarter.Library.Tests.Helpers
{
    public static class TestHelper
    {
        public static string xmlOutputFolder = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["OutputFolder"].Value;

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
