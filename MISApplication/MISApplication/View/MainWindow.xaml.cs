using MISApplication.Model;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass.Password.Length > 0)
                labpass.Visibility = Visibility.Collapsed;
            else
                labpass.Visibility = Visibility.Visible;
        }

        private void Вход_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window OpenWindow = new RegistrWindow();
                OpenWindow.Show();
                this.Close();
                return;
                using (var db = new БдмисContext())
                {

                    ДанныеРаботников user = db.ДанныеРаботниковs.Where(s => s.Логин == loginTextBox.Text && s.Пароль == pass.Password).FirstOrDefault();
                    if (user.IdрольNavigation.Название == "Администратор")
                        OpenWindow = new RegistrWindow();
                    if (user.IdрольNavigation.Название == "Врач")
                        OpenWindow = new DoctorWindow();
                    if (user.IdрольNavigation.Название == "Сотрудник")
                        OpenWindow = new RegistrWindow();

                }
                if (OpenWindow != null)
                {
                    OpenWindow.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                FulsValid();
            }
        }

        private void FulsValid()
        {
            MessageBox.Show("Неверный логин или пароль!!!");
            ControlTemplate templatePass = pass.Template;
            Border borderPass = (Border)templatePass.FindName("border", pass);
            borderPass.BorderBrush = Brushes.Red;

            ControlTemplate templateLog = loginTextBox.Template;
            Border borderLog = (Border)templateLog.FindName("border", loginTextBox);
            borderLog.BorderBrush = Brushes.Red;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Обратитесь в тех поьдержку по номеру\n +7 (937) 537 98 81");
        }
    }
}