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

namespace MISApplication.View
{
    /// <summary>
    /// Логика взаимодействия для AdministationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        public AdministrationWindow()
        {
            InitializeComponent();
            content.Content = new UsersPage();
        }

        private void ListUsers_Checked(object sender, RoutedEventArgs e)
        {
           if (titleReg == null || content == null)
                return;
            titleReg.Text = "Список пользователей";
            content.Content = new UsersPage();
        }

        private void AddNewUsers_Checked(object sender, RoutedEventArgs e)
        {
            if (titleReg == null || content == null)
                return;
            titleReg.Text = "Регистрация нового \nпользователя";
            content.Content = new RegisterUserPage();
        }
    }
}
