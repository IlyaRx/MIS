using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MISApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    #region MyRegion

    #endregion
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(pass.Password.Length > 0)
                labpass.Visibility = Visibility.Collapsed;
            else
                labpass.Visibility = Visibility.Visible;
            
            ControlTemplate template = pass.Template;
            Border border = (Border)template.FindName("border", pass);
            border.BorderBrush = Brushes.Red;
        }

        private void butX_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void butFullSkrin_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void but__Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
            
            
        }
    }
}