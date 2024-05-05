using MISApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ZapisPage.xaml
    /// </summary>
    public partial class ZapisPage : UserControl
    {
        public ZapisPage()
        {
            InitializeComponent();
            FillingList();
            FillingCombobox();
        }

        private void FillingCombobox()
        {
            try
            {
                using (var db = new БдмисContext())
                {
                    TypeUslug.ItemsSource = db.КатегорияУслугs.Select(s => s.Название).ToList();
                    TypeUslug.SelectedIndex = 0;
                    string NameType = TypeUslug.SelectedValue.ToString();
                    Usluga.ItemsSource = db.Услугиs.Where(s => s.IdкатегорияУслугNavigation.Название == NameType).Select(s => s.Название).ToList();
                    Doctor.ItemsSource = db.Врачиs.Select(s => s.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation.Фамилия).ToList();
                }
            }
            catch (Exception ex) { }
        }

        private void FillingList(List<Пациент>? pasients = null)
        {
            listPasient.Items.Clear();
            using (var db = new БдмисContext())
            {
                if (pasients == null)
                {
                    pasients = db.Пациентs.OrderBy(o => o.IdперсональныеДанныеNavigation.Фамилия).ToList();
                    if ((bool)OrderByR.IsChecked)
                        pasients.Reverse();
                }
                foreach (var item in pasients)
                {
                    ПерсональныеДанные персональные = db.ПерсональныеДанныеs.First(a => a.Id == item.IdперсональныеДанные);
                    listPasient.Items.Add(new ItemListPasient(item.Id, персональные));
                }

                if (pasients.Count == 0)
                    return;

                ПерсональныеДанные пациент = db.ПерсональныеДанныеs.First(a => a.Id == pasients[0].IdперсональныеДанные);
                LastnameTextBlock.Text = пациент.Фамилия;
                NameTextBlock.Text = пациент.Имя;
                SecondNameTextBlock.Text = пациент.Отчество;
                SnilsTextBlock.Text = пациент.Снилс;
                PsportTextBlock.Text = пациент.Паспорт;
                AgeTextBlock.Text = CalculateAge(пациент.ДатаРождения.ToDateTime(TimeOnly.MinValue)).ToString();

                listPasient.SelectedIndex = 0;
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


        private List<Пациент>? FilterPoist()
        {
            try
            {
                if (Poisk.Text == "")
                    return null;
                

                List<Пациент>? pasients = null;
                using (var db = new БдмисContext())
                {
                    if ((bool)RadButFIO.IsChecked)
                        pasients = db.Пациентs.Where(f => f.IdперсональныеДанныеNavigation.Фамилия == Poisk.Text).OrderBy(o => o.IdперсональныеДанныеNavigation.Фамилия).ToList();
                    if ((bool)RadButCNILS.IsChecked)
                        pasients = db.Пациентs.Where(f => f.IdперсональныеДанныеNavigation.Снилс == Poisk.Text).OrderBy(o => o.IdперсональныеДанныеNavigation.Фамилия).ToList();
                    if ((bool)RadButPasport.IsChecked)
                        pasients = db.Пациентs.Where(f => f.IdперсональныеДанныеNavigation.Паспорт == Poisk.Text).OrderBy(o => o.IdперсональныеДанныеNavigation.Фамилия).ToList();
                    if ((bool)RadButSave.IsChecked)
                        pasients = db.Пациентs.Where(f => f.IdперсональныеДанныеNavigation.НомерСтраховогоПолиса == Poisk.Text).OrderBy(o => o.IdперсональныеДанныеNavigation.Фамилия).ToList();


                }
                if ((bool)OrderByR.IsChecked)
                    pasients.Reverse();
                return pasients;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void ButPoisk_Click(object sender, RoutedEventArgs e) => 
            FillingList(FilterPoist());


        private void NewZapis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string LastnameDoctor = Doctor.SelectedItem.ToString();
                string NameUslug = Usluga.SelectedItem.ToString();

                using (var db = new БдмисContext())
                {
                    int idPasient = 0;
                    if (listPasient.SelectedItem is ItemListPasient ids)
                        idPasient = db.Пациентs.First(d => d.IdперсональныеДанные == ids.Id1).Id;
                    Запись запись = new Запись()
                    {
                        Idпациента = idPasient,
                        Idуслуги = db.Услугиs.First(s => s.Название == NameUslug).Id,
                        Idврача = db.Врачиs.First(s => s.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation.Фамилия == LastnameDoctor).Id,
                        ДатаПроведения = DateOnly.FromDateTime((DateTime)DateStart.SelectedDate),
                        ВремяПроведения = new TimeOnly(int.Parse(Hours.Text), int.Parse(Minute.Text) )
                    };
                    db.Записьs.Add(запись);
                    db.SaveChanges();
                    MessageBox.Show($"Вы создали запись {DateOnly.FromDateTime((DateTime)DateStart.SelectedDate).ToString()} на {new TimeOnly(int.Parse(Hours.Text), int.Parse(Minute.Text))}");
                    PassedValid();
                }

            }
            catch (Exception ex)
            {
                FaildValid();
            }
        }

        private void FaildValid()
        {
            MessageBox.Show("Проверьте правильность введённых данных!!!");
            ControlTemplate templateTypeUslug = TypeUslug.Template;
            Border borderTypeUslug = (Border)templateTypeUslug.FindName("border", TypeUslug);
            borderTypeUslug.BorderBrush = Brushes.Red;

            ControlTemplate templateHours = Hours.Template;
            Border borderHours = (Border)templateHours.FindName("border", Hours);
            borderHours.BorderBrush = Brushes.Red;

            ControlTemplate templateMinute = Minute.Template;
            Border borderMinute = (Border)templateMinute.FindName("border", Minute);
            borderMinute.BorderBrush = Brushes.Red;

            ControlTemplate templateUsluga = Usluga.Template;
            Border borderUsluga = (Border)templateUsluga.FindName("border", Usluga);
            borderUsluga.BorderBrush = Brushes.Red;

            ControlTemplate templateDoctor = Doctor.Template;
            Border borderDoctor = (Border)templateDoctor.FindName("border", Doctor);
            borderDoctor.BorderBrush = Brushes.Red;

            ControlTemplate templateDateStart = DateStart.Template;
            Border borderDateStart = (Border)templateDateStart.FindName("border", DateStart);
            borderDateStart.BorderBrush = Brushes.Red;
        }

        private void PassedValid()
        {
            MessageBox.Show("Проверьте правильность введённых данных!!!");
            ControlTemplate templateTypeUslug = TypeUslug.Template;
            Border borderTypeUslug = (Border)templateTypeUslug.FindName("border", TypeUslug);
            borderTypeUslug.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));

            ControlTemplate templateHours = Hours.Template;
            Border borderHours = (Border)templateHours.FindName("border", Hours);
            borderHours.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));

            ControlTemplate templateMinute = Minute.Template;
            Border borderMinute = (Border)templateMinute.FindName("border", Minute);
            borderMinute.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));

            ControlTemplate templateUsluga = Usluga.Template;
            Border borderUsluga = (Border)templateUsluga.FindName("border", Usluga);
            borderUsluga.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));

            ControlTemplate templateDoctor = Doctor.Template;
            Border borderDoctor = (Border)templateDoctor.FindName("border", Doctor);
            borderDoctor.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));

            ControlTemplate templateDateStart = DateStart.Template;
            Border borderDateStart = (Border)templateDateStart.FindName("border", DateStart);
            borderDateStart.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));
        }

        private void listPasient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            if (listPasient.SelectedItem is ItemListPasient ids)
                id = ids.Id1;
            else
                return;
            using(var db = new БдмисContext())
            {
                ПерсональныеДанные пациент = db.ПерсональныеДанныеs.First(a => a.Id == id);
                LastnameTextBlock.Text = пациент.Фамилия;
                NameTextBlock.Text = пациент.Имя;
                SecondNameTextBlock.Text = пациент.Отчество;
                SnilsTextBlock.Text = пациент.Снилс;
                PsportTextBlock.Text = пациент.Паспорт;
                AgeTextBlock.Text = CalculateAge(пациент.ДатаРождения.ToDateTime(TimeOnly.MinValue)).ToString();
            }
        }
    }
}
