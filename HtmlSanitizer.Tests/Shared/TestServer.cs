using System;
using System.Configuration;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Ganss.XSS.Tests.Shared
{
    /// <summary>
    /// A test server which serves static files from the "Server" folder of the running assembly
    /// </summary>
    public class TestServer : IDisposable
    {
        private static string _url;
        private readonly IDisposable server;

        private static readonly FileServerOptions FileServerOptions = new FileServerOptions
        {
            FileSystem = new PhysicalFileSystem("Server"),
            EnableDirectoryBrowsing = true
        };

        private const string SettingNotFound =
            "Unable to find test server url. Are you missing the " + SettingKey + " app.config setting?";

        private const string SettingKey = "TestServer.Url";

        private TestServer()
        {
            EnsureConfiguration();
            Console.WriteLine("Starting server: {0}", _url);
            server = WebApp.Start(_url, builder => builder.UseFileServer(FileServerOptions));
        }

        private static void EnsureConfiguration()
        {
            if (!string.IsNullOrEmpty(_url)) return;
            _url = ConfigurationManager.AppSettings[SettingKey];
            if (string.IsNullOrEmpty(_url)) throw new Exception(SettingNotFound);
        }

        public static TestServer Start()
        {
            return new TestServer();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing server");
            server.Dispose();
        }
    }
}