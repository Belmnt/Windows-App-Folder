using System.Windows.Media;

namespace AppFolderWidget.Models
{
    public class AppItem
    {
        public string Name { get; set; } = string.Empty;
        public string LaunchTarget { get; set; } = string.Empty;
        public ImageSource? Icon {  get; set; }
    }
}
