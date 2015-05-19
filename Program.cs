using System;
using System.Collections.Generic;
using System.Threading;
using CommandLine;
using EmmitProxyServer.Properties;
using Microsoft.Owin.Hosting;
using Nancy.Hosting.Self;

namespace EmmitProxyServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApp.Start(Settings.Default.EmmitPath, (app) =>
            {
                var startup = new EmmitStartup();
                startup.Configuration(app);

                Console.WriteLine("Emmit server started on :{0}",Settings.Default.EmmitPath);
            });

            Bootstrapepr bootstrapper = new Bootstrapepr();
            
            var host = new NancyHost(bootstrapper, new Uri(Settings.Default.NancyPath));
            host.Start();

            Console.WriteLine("Nancy server started on :{0}", Settings.Default.NancyPath);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
