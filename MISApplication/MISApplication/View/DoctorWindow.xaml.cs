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
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        private UserControl _mainPage = new PoiskPasientPage();
        private bool _isPasient = false;
        public DoctorWindow()
        {
            InitializeComponent();
            content.Content = _mainPage;

        }

        private void PriemRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Приём";
            if(_isPasient)
                _mainPage = new PriemPage();
            content.Content = _mainPage;
        }

        private void HistoryRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "История болезни";
            if (_isPasient)
                _mainPage = new HisrtoryPasientPage();
            content.Content = _mainPage;
        }

        private void DiagnosticRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Диагноостика";
            if (_isPasient)
                _mainPage = new Diagnostic();
            content.Content = _mainPage;
        }

        private void HospitalRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Госпитализация";
            if (_isPasient)
                _mainPage = new HospitalisationPage();
            content.Content = _mainPage;
        }

        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            _isPasient = true;
            butSave.Visibility = Visibility.Visible;
            butStart.Visibility = Visibility.Collapsed;
            PriemRB.IsChecked = true;
            content.Content = new PriemPage();
            //добавление пацинета

        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
