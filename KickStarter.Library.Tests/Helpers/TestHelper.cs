using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace KickStarter.Library.Tests.Helpers
{
    public static class TestHelper
    {
        public static string xmlOutputFolder = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["OutputFolder"].Value;

    }
}
