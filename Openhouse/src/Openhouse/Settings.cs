using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Openhouse
{
    public class Settings
    {
        public string DbConnectionString { get; }
        public bool DebugMode { get; }
        public int DebugLogLevel { get; }
        public bool ServeDefaultFile { get; }
        public bool ReadWriteMode { get; }

        public Settings(IConfiguration config)
        {
            DbConnectionString = config.Get<string>("DbConnectionString", "");
            DebugLogLevel = config.Get<int>("DebugLogLevel", 5);
            DebugMode = config.Get<bool>("DebugMode", true);
            ServeDefaultFile = config.Get<bool>("ServeDefaultFile", false);
            ReadWriteMode = config.Get<bool>("ReadWriteMode", true);
        }
    }
}
