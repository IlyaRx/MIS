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
    /// Логика взаимодействия для PriemPage.xaml
    /// </summary>
    public partial class PriemPage : UserControl
    {
        private int _isPasient;
        private int _isDoctor;

        public PriemPage(Приёмы priem)
        {
            InitializeComponent();
            try
            {
                Resultat.IsReadOnly = true;
                CoursHeal.IsReadOnly = true;
                Jalob.IsReadOnly = true;
                Naznach.IsReadOnly = true;
                Resultat.Text = priem.Результаты;
                CoursHeal.Text = priem.КурсЛечения;
                Jalob.Text = priem.Жалобы;
                Naznach.Text = priem.Назначение;
            }
            catch
            {

            }
        }

        public PriemPage(int idPasient, int isDoctor)
        {
            InitializeComponent();
            _isPasient = idPasient;
            _isDoctor = isDoctor;
        }

        public Приёмы GetPriem()
        {
            try
            {
                Приёмы priem = new Приёмы()
                {
                    Idврача = _isDoctor,
                    Idпациента = _isPasient,
                    Результаты = Resultat.Text,
                    КурсЛечения = CoursHeal.Text,
                    Жалобы = Jalob.Text,
                    Назначение = Naznach.Text,
                    ДатаПроведения = DateOnly.FromDateTime(DateTime.Now),
                };
                return priem;
            }
            catch 
            {
                MessageBox.Show("Не враыельно введелны данные во вкладке приёмы!");
                return null;
            }
        }
    }
}
