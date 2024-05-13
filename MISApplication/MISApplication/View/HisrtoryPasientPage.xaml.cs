using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для HisrtoryPasientPage.xaml
    /// </summary>
    public partial class HisrtoryPasientPage : Page
    {
        private int _idPasient;
        public HisrtoryPasientPage(int idPasient)
        {
            InitializeComponent();
            _idPasient = idPasient;
            FillingList();
        }

        private void FillingList(List<Приёмы>? priem = null)
        {
            listPasient.Items.Clear();
            try
            {
                using (var db = new БдмисContext())
                {
                    if (priem == null)
                    {
                        priem = db.Приёмыs.Where(o => o.Idпациента == _idPasient).ToList();
                    }
                    foreach (var item in priem)
                    {
                        var doctor = db.Врачиs
                                         .Include(d => d.IdданныеРаботникаNavigation)
                                         .Include(d => d.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation)
                                         .Include(d => d.IdотделенияNavigation)
                                         .FirstOrDefault(s => s.Id == item.Idврача);

                        ПерсональныеДанные persDateDoctor = doctor.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation;
                        Отделение otdelenie = doctor.IdотделенияNavigation;
                        listPasient.Items.Add(new HistiryPasiena(item, persDateDoctor, otdelenie));
                    }

                    if (priem.Count == 0)
                        return;
                }
            }
            catch
            {

            }
        }

    }
}
