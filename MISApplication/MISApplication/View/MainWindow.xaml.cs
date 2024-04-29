using MISApplication.View;
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

namespace MISApplication.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
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

        private void Вход_Click(object sender, RoutedEventArgs e)
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            this.Close();
        }



    }
}

//// Создаем эллипс
//Ellipse ellipse = new Ellipse();
//ellipse.Width = 200;
//ellipse.Height = 200;

//// Создаем VisualBrush
//VisualBrush visualBrush = new VisualBrush();
//visualBrush.Stretch = Stretch.Uniform;

//// Создаем Canvas и добавляем Path
//Canvas canvas = new Canvas();
//canvas.Width = 200;
//canvas.Height = 200;

//Path path = new Path();
//path.Data = Geometry.Parse("M17.7545 14.0002C18.9966 14.0002 20.0034 15.007 20.0034 16.2491V16.8245C20.0034 17.7188 19.6838 18.5836 19.1023 19.263C17.5329 21.0965 15.1457 22.0013 12.0004 22.0013C8.8545 22.0013 6.46849 21.0962 4.90219 19.2619C4.32242 18.583 4.00391 17.7195 4.00391 16.8267V16.2491C4.00391 15.007 5.01076 14.0002 6.25278 14.0002H17.7545ZM17.7545 15.5002H6.25278C5.83919 15.5002 5.50391 15.8355 5.50391 16.2491V16.8267C5.50391 17.3624 5.69502 17.8805 6.04287 18.2878C7.29618 19.7555 9.26206 20.5013 12.0004 20.5013C14.7387 20.5013 16.7063 19.7555 17.9627 18.2876C18.3117 17.8799 18.5034 17.361 18.5034 16.8245V16.2491C18.5034 15.8355 18.1681 15.5002 17.7545 15.5002ZM12.0004 2.00488C14.7618 2.00488 17.0004 4.24346 17.0004 7.00488C17.0004 9.76631 14.7618 12.0049 12.0004 12.0049C9.23894 12.0049 7.00036 9.76631 7.00036 7.00488C7.00036 4.24346 9.23894 2.00488 12.0004 2.00488ZM12.0004 3.50488C10.0674 3.50488 8.50036 5.07189 8.50036 7.00488C8.50036 8.93788 10.0674 10.5049 12.0004 10.5049C13.9334 10.5049 15.5004 8.93788 15.5004 7.00488C15.5004 5.07189 13.9334 3.50488 12.0004 3.50488Z");
//path.Fill = Brushes.White;

//canvas.Children.Add(path);

//// Устанавливаем Visual как источник для VisualBrush
//visualBrush.Visual = canvas;

//// Устанавливаем VisualBrush как заполнение для эллипса
//ellipse.Fill = visualBrush;

//// Добавляем эллипс в какой-нибудь контейнер, например, на главном окне
//// mainWindow.Content = ellipse;