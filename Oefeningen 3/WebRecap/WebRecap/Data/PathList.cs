using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Collections.Generic;

namespace WebRecap.Data
{
    public class PathList
    {
        public readonly IWebHostEnvironment _environment;


        public static List<string> AllRoutes = new List<string>();

        public PathList(IWebHostEnvironment environment)
        {
            _environment = environment;
            
        }

        public void LoadAllRoutes()
        {
            string locFolder = Path.Combine(_environment.WebRootPath, "..", "Views", "Topic");

            var directories = Directory.GetDirectories(locFolder).OrderBy(a => a);

            foreach (string folderPath in directories)
            {
                string folderName = Path.GetFileName(folderPath);
                AllRoutes.Add(folderName);
            }
        }
    }
}
