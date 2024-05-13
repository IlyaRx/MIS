using Microsoft.EntityFrameworkCore;
using MISApplication.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для HospitalisationPage.xaml
    /// </summary>
    public partial class HospitalisationPage : UserControl
    {
        private int _idPasient;
        public HospitalisationPage(int idPasient)
        {
            InitializeComponent();
            FillingCombobox();
            _idPasient = idPasient;
            using(var db = new БдмисContext())
            {
                ПерсональныеДанные pasientPD = db.Пациентs.Include(p => p.IdперсональныеДанныеNavigation)
                                                          .First(p => p.Id == idPasient).IdперсональныеДанныеNavigation;
                LastnameTextBlock.Text = pasientPD.Фамилия;
                NameTextBlock.Text = pasientPD.Имя;
                SecondNameTextBlock.Text = pasientPD.Отчество;
                SnilsTextBlock.Text = pasientPD.Снилс;
                PsportTextBlock.Text = pasientPD.Паспорт;
                AgeTextBlock.Text = CalculateAge(pasientPD.ДатаРождения.ToDateTime(TimeOnly.MinValue)).ToString();
            }
        }


        private int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (now < birthDate.AddYears(age))
            {
                age--;
            }
            return age;
        }

        private void FillingCombobox()
        {
            try
            {
                using (var db = new БдмисContext())
                {
                    CBOtdelenie.ItemsSource = db.КатегорияУслугs.Select(s => s.Название).ToList();
                }
            }
            catch (Exception ex) { }
        }


        private void FaildValid()
        {
            MessageBox.Show("Проверьте правильность введённых данных!!!");
            List<Control> list = new List<Control>()
            {
               CBOtdelenie, DateHospitalisation
            };

            foreach (var item in list)
            {
                ControlTemplate template = item.Template;
                Border border = (Border)template.FindName("border", item);
                border.BorderBrush = Brushes.Red;
            }
        }

        private void PassedValid()
        {
            List<Control> list = new List<Control>()
            {
                CBOtdelenie, DateHospitalisation
            };

            foreach (var item in list)
            {
                ControlTemplate template = item.Template;
                Border border = (Border)template.FindName("border", item);
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));
            }
        }


        private void ButHospital_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var db = new БдмисContext())
                {
                    string nameOtdel = CBOtdelenie.SelectedItem.ToString();
                    int idOtdel= 0;
                    if (nameOtdel == null)
                        idOtdel = db.Отделениеs.First(o => o.Название == nameOtdel).Id;
                    Госпитализация newHospital = new Госпитализация()
                    {
                        Idотделения = idOtdel,
                        Idпациента = _idPasient,
                        ДатаНачала = DateOnly.FromDateTime((DateTime)DateHospitalisation.SelectedDate),
                    };

                    db.Госпитализацияs.Add(newHospital);
                    db.SaveChanges();
                    PassedValid();
                    MessageBox.Show("Пациент госпитализирован");
                }
            }
            catch (Exception){
                FaildValid();
            }
        }


    }
}
