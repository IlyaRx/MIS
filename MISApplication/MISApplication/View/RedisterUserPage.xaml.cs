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
    /// Логика взаимодействия для RegisterUserPage.xaml
    /// </summary>
    public partial class RegisterUserPage : UserControl
    {
        public RegisterUserPage()
        {
            InitializeComponent();
        }



        private void FailedValid()
        {
            MessageBox.Show("Проверьте правильность введённых данных!!!");
            List<Control> list = new List<Control>()
            {
                Lastname, Name, SecondName, NumberInsurance, CompanyInsurance, DateEndInsurance,Adress,Phone
                ,Pasport, Snils,DateBirth, Login, Password,INN,Edication,Story,Post
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
                Lastname, Name, SecondName, NumberInsurance, CompanyInsurance, DateEndInsurance,Adress,Phone
                ,Pasport, Snils,DateBirth, Login, Password,INN,Edication,Story,Post
            };

            foreach (var item in list)
            {
                ControlTemplate template = item.Template;
                Border border = (Border)template.FindName("border", item);
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36A684"));
            }
        }

        private void SaveNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using(var db = new БдмисContext())
                {
                    Страховки страховки = new Страховки()
                    {
                        НомерСтраховогоПолиса = NumberInsurance.Text,
                        КомпанияСтрахователь = CompanyInsurance.Text,
                        СрокДействия = DateOnly.FromDateTime((DateTime)DateEndInsurance.SelectedDate),
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
                        Телефон = Phone.Text,
                        Паспорт = Pasport.Text,
                        Почта = Email.Text,
                        Снилс = Snils.Text,
                    };
                    db.ПерсональныеДанныеs.Add(персональные);

                    ДанныеРаботников данныеРаботников = new ДанныеРаботников()
                    {
                        IdперсональныеДанныеNavigation = персональные,
                        Логин = Login.Text,
                        Пароль = Password.Text,
                        Инн = INN.Text,
                        ОбразованиеИквалификация = Edication.Text,
                        ТрудоваяИстория = Story.Text,
                    };

                    db.ДанныеРаботниковs.Add(данныеРаботников);

                    Должности должности = new Должности()
                    {
                        Название = Post.SelectedValue.ToString()
                    };
                    db.Должностиs.Add(должности);

                    Сотрудники сотрудники = new Сотрудники()
                    {
                        IdданныеРаботникаNavigation = данныеРаботников,
                        IdдолжностьNavigation = должности
                    };
                    db.Сотрудникиs.Add(сотрудники);

                    db.SaveChanges();
                    MessageBox.Show("Вы создали добавили нового работника)");
                    PassedValid();
                }
            }catch{ FailedValid(); }
        }
    }
}
