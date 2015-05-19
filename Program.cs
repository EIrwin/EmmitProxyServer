using System;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;
using Nancy.Hosting.Self;

namespace EmmitProxyServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //-path: overrides the path that Emmit is listenign on

            string emmitPath = "http://localhost:8888/emmit";
            WebApp.Start(emmitPath, (app) =>
            {
                var startup = new EmmitStartup();
                startup.Configuration(app);

                Console.WriteLine("Emmit server started on :{0}", emmitPath);
            });


            string nancyPath = "http://localhost:8787";
            using (NancyHost host = new NancyHost(new HostConfiguration { UrlReservations = new UrlReservations { CreateAutomatically = true }},new Uri(nancyPath)))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + nancyPath);
            }


            Console.ReadLine();

        }
    }
}
