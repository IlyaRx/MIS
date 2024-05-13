using MISApplication.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для PoiskPasientPage.xaml
    /// </summary>
    public partial class PoiskPasientPage : UserControl
    {
        private Пациент _pasient = null;
        public PoiskPasientPage()
        {
            InitializeComponent();
            FillingList();
        }

        public Пациент GerPasient()
        {
            return _pasient;
        }
        private void FillingList(List<Пациент>? pasients = null)
        {
            listPasient.Items.Clear();
            try
            {
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
                    listPasient.SelectedIndex = 0;
                }
            }
            catch 
            { 

            }
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

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new БдмисContext())
                {
                    if (listPasient.SelectedItem is ItemListPasient ids)
                        _pasient = db.Пациентs.First(d => d.IdперсональныеДанные == ids.Id1);
                }
                this.Visibility = Visibility.Hidden;
            }
            catch
            {
                MessageBox.Show("Выберите пациента!");
            }
        }

        private void ButPoisk_Click(object sender, RoutedEventArgs e) => FillingList(FilterPoist());
    }
}
