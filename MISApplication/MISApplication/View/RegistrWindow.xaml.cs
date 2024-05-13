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
using System.Windows.Shapes;

namespace MISApplication.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistr.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            content.Content = new ZapisPage();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (titleReg == null || content == null)
                return;
            titleReg.Text = "Запись пациента";
            content.Content = new ZapisPage();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (titleReg == null || content == null)
                return;
            titleReg.Text = "Регистрация новой\nэлектронной медицинской карты";
            content.Content = new RegisterUserPage();
        }
    }
}

