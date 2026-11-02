using AppFolderWidget.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFolderWidget.Services
{
    public class AppDiscoveryService
    {
        private readonly IconService _iconService = new();
        private readonly AppFilterService _filterService = new();
        public List<AppItem> DiscoverFromStartMenu()
        {
            var apps = new List<AppItem>();

            var folders = new[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
            };

            foreach (var folder in folders)
            {
                if (!Directory.Exists(folder)) continue;

                var programs = Path.Combine(folder, "Programs");

                if (!Directory.Exists(programs)) continue;

                foreach (var file in Directory.EnumerateFiles(programs, "*.lnk", SearchOption.AllDirectories))
                {
                    var name = Path.GetFileNameWithoutExtension(file);

                    if (!_filterService.ShouldInclude(name))
                        continue;

                    apps.Add(new AppItem
                    {
                        Name = name,
                        LaunchTarget = file,
                        Icon = _iconService.GetIcon(file)
                    });
                }
            }

            return apps;
        }
    }
}
