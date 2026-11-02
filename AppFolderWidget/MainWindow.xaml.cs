using AppFolderWidget.Services;
using System.Windows;
using AppFolderWidget.ViewModels;
using System.Windows.Input;
using System.Windows.Controls;
using AppFolderWidget.Models;

namespace AppFolderWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime _menuClosedAt = DateTime.MinValue;
        private readonly LaunchService _launchService = new();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            DragMove();
        }

        private void OptionsMenu_Closed(object? sender, RoutedEventArgs e)
        {
            _menuClosedAt = DateTime.Now;
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn || btn.ContextMenu is not ContextMenu menu)
                return;

            if ((DateTime.Now - _menuClosedAt).TotalMilliseconds < 200)
                return;

            menu.PlacementTarget = btn;
            menu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            menu.IsOpen = true;
        }

        private void ListItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListBoxItem item || item.DataContext is not AppItem app)
                return;

            try
            {
                _launchService.Launch(app);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"No se pudo lanzar '{app.Name}'. \n\n {ex.Message}",
                    "Error al lanzar.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // ----- TEMPORAL -----
            Close();
        }
    }
}