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
    /// Логика взаимодействия для ItemListPasient.xaml
    /// </summary>
    public partial class ItemListPasient : UserControl
    {
        private int _id;
        public int Id1 { get => _id; set => _id = value; }

        public ItemListPasient(int пациент, ПерсональныеДанные персональныеДанные)
        {
            InitializeComponent();
            _id = персональныеДанные.Id;
            Id.Text = пациент.ToString();
            Lastname.Text = персональныеДанные.Фамилия;
            Name.Text = персональныеДанные.Имя;
            SecondName.Text = персональныеДанные.Отчество;
            string pasport = персональныеДанные.Паспорт.ToString();
            Pasport.Text = "** ** ****" + pasport[pasport.Length - 2].ToString() + pasport[pasport.Length - 1].ToString();
        }

    }
}
