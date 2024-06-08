using MISApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        private PriemPage _priemPage;
        private HisrtoryPasientPage _herstoryPatientsPage;
        private DiagnosticPage _diagnostic;
        private HospitalisationPage _hospitalizationPage;
        private bool _isPatient = false;
        private int _idPatient = 0;
        private int _IdDoctor = 0;
        public DoctorWindow(int idDoctor)
        {
            InitializeComponent();
            content.Content = _mainPage;
            _IdDoctor = idDoctor;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500); 
            BoredTrigger.Visibility = Visibility.Visible;
        }

        private void PriemRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Приём";
            if(_isPatient)
                _mainPage = _priemPage;
            content.Content = _mainPage;
        }

        private void HistoryRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "История болезни";
            if (_isPatient)
                content.Content = _herstoryPatientsPage;
        }

        private void DiagnosticRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Диагностика";
            if (_isPatient)
                _mainPage = _diagnostic;
            content.Content = _mainPage;
        }

        private void HospitalRB_Checked(object sender, RoutedEventArgs e)
        {
            if (titleDoc != null)
                titleDoc.Text = "Госпитализация";
            if (_isPatient)
                _mainPage = _hospitalizationPage;
            content.Content = _mainPage;
        }

        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            _mainPage = new PoiskPasientPage();
            content.Content = _mainPage;
            _isPatient = false;
            butSave.Visibility = Visibility.Hidden;
            try
            {
                using(var db = new БдмисContext())
                {
                    db.Приёмыs.Add(_priemPage.GetPriem());
                    db.SaveChanges();
                }
                MessageBox.Show("Приём закончен");
            }
            catch (Exception)
            {

            }
        }

        private void BoredTrigger_MouseEnter(object sender, MouseEventArgs e)
        {
            if (content.Content is PoiskPasientPage poisk)
                _idPatient = poisk.GerPasient().Id;
            else
                return;


            _priemPage = new PriemPage(_idPatient, _IdDoctor);
            _herstoryPatientsPage = new HisrtoryPasientPage(_idPatient);
            _diagnostic = new DiagnosticPage(_idPatient);
            _hospitalizationPage = new HospitalisationPage(_idPatient);


            _isPatient = true;
            butBack.Visibility = Visibility.Visible;
            butSave.Visibility = Visibility.Visible;
            PriemRB.IsChecked = true;
            content.Content = _priemPage;
        }

        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            _mainPage = new PoiskPasientPage();
            content.Content = _mainPage;
            _isPatient = false;
            butSave.Visibility = Visibility.Hidden;
            butBack.Visibility = Visibility.Hidden;
        }
    }
}
