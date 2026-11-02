using System.Collections.ObjectModel;

namespace AppFolderWidget.Models
{
    public class AppGroup
    {
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<AppItem> Apps { get; } = new();
    }
}
