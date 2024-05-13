using MISApplication.Model;
using System;
using System.Collections;
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
    /// Логика взаимодействия для RegistryEMK.xaml
    /// </summary>
    public partial class RegisrtEMKPage : UserControl
    {
        public RegisrtEMKPage()
        {
         InitializeComponent();
        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var db = new БдмисContext())
                {
                    Страховки страховки = new Страховки()
                    {
                        НомерСтраховогоПолиса = NumberStrahovki.Text,
                        КомпанияСтрахователь = CompanyStrahovki.Text,
                        СрокДействия = DateOnly.FromDateTime((DateTime)DateEndStrahovka.SelectedDate),
                    };

                    db.Страховкиs.Add(страховки);

                    ПерсональныеДанные персональные = new ПерсональныеДанные()
                    {
                        НомерСтраховогоПолисаNavigation = страховки,
                        Фамилия = Lastname.Text,
                        Имя = Name.Text,
                        Отчество = SecondName.Text,
                        ДатаРождения = DateOnly.FromDateTime((DateTime)DateBirth.SelectedDate),
                        АдресПроживания = Adress.Text,
                        Телефон = NumberPhone.Text,
                        Паспорт = Pasport.Text,
                        Почта = Mail.Text,
                        Снилс = Snils.Text,
                    };
                    db.ПерсональныеДанныеs.Add(персональные);

                    Пациент пациент = new Пациент()
                    {
                        IdперсональныеДанныеNavigation = персональные,
                        Пол = Gender.SelectedValue.ToString(),
                        ПоследнееВремяПосещения = DateOnly.FromDateTime(DateTime.Now),
                    };
                    db.Пациентs.Add(пациент);
                    db.SaveChanges();
                    MessageBox.Show("Вы создали медицинскую карту)");
                    PassedValid();
                }

            }catch(Exception ex)
            {
                FailedValid();
            }
        }

        private void FailedValid()
        {
            MessageBox.Show("Проверьте правильность введённых данных!!!");
            List<Control> list = new List<Control>()
            {
                Lastname, Name, SecondName, NumberStrahovki, CompanyStrahovki, DateEndStrahovka,
                Adress, NumberPhone, Pasport, Snils, Mail, Gender, DateBirth,
            };

            foreach (var item in list)
            {
                ControlTemplate template= item.Template;
                Border border= (Border)template.FindName("border", item);
                border.BorderBrush = Brushes.Red;
            }
        }

        private void PassedValid()
        {
            List<Control> list = new List<Control>()
            {
                Lastname, Name, SecondName, NumberStrahovki, CompanyStrahovki, DateEndStrahovka,
                Adress, NumberPhone, Pasport, Snils, Mail, Gender, DateBirth,
            };

            foreach (var item in list)
            {
                ControlTemplate template = item.Template;
                Border border = (Border)template.FindName("border", item);
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));
            }
        }

    }
}
