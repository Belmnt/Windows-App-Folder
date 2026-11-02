using AppFolderWidget.Models;
using AppFolderWidget.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFolderWidget.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<AppItem> AllApps { get; } = new();

        public MainViewModel() 
        {
            var service = new AppDiscoveryService();
            var apps = service.DiscoverFromStartMenu();

            foreach (var app in apps)
            {
                AllApps.Add(app);
            }
        }
    }
}
