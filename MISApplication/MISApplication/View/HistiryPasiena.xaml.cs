using MISApplication.Model;
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
    /// Логика взаимодействия для HistiryPasiena.xaml
    /// </summary>
    public partial class HistiryPasiena : UserControl
    {
        private Приёмы _priem;
        public HistiryPasiena(Приёмы priem, ПерсональныеДанные personalDateDoctor, Отделение отделение)
        {
            InitializeComponent();
            Lastname.Text = personalDateDoctor.Фамилия;
            Name.Text = personalDateDoctor.Имя;
            SecondName.Text = personalDateDoctor.Отчество;
            Time.Text = priem.ДатаПроведения.ToString("D");
            Otdelenie.Text = отделение.Название;
            _priem = priem;
        }

        private void ButPriem_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ResizeMode = ResizeMode.NoResize;
            window.Content = new PriemPage(_priem);
            window.ShowDialog();
        } 
    }
}
