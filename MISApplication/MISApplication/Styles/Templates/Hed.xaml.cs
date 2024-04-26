using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для Hed.xaml
    /// </summary>
    public partial class Hed : UserControl
    {
        private Window _ownerWindow;
        private bool _isDragging;
        private Point _mouseDownPoint;
        public Hed()
        {

            InitializeComponent();
            Loaded += Hed_Loaded;
        }

        private void Hed_Loaded(object sender, RoutedEventArgs e) => _ownerWindow = Window.GetWindow(this);
            
        private void but__Click(object sender, RoutedEventArgs e) => _ownerWindow.WindowState = WindowState.Minimized;
        
        private void butX_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => _ownerWindow.DragMove();

        private void butFullSkrin_Click(object sender, RoutedEventArgs e)
        {
            if (_ownerWindow.WindowState == WindowState.Normal)
                _ownerWindow.WindowState = WindowState.Maximized;
            else
                _ownerWindow.WindowState = WindowState.Normal;
        }




   
    }
}
