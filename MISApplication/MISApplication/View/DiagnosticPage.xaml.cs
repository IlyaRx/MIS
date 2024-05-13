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
    /// Логика взаимодействия для DiagnosticPage.xaml
    /// </summary>
    public partial class DiagnosticPage : UserControl
    {
        private int _idPasient;
        public DiagnosticPage(int idPasient)
        {
            InitializeComponent();
            _idPasient = idPasient;
            FillingList();
        }

        private void FillingList(List<Диагностика>? diagnosList = null)
        {
            listPasient.Items.Clear();
            try
            {
                using (var db = new БдмисContext())
                {
                    if (diagnosList == null)
                        diagnosList = db.Диагностикаs.Where(o => o.Idпациента == _idPasient).ToList();
                    foreach (var item in diagnosList)
                    {
                        listPasient.Items.Add(new Diagnostic(item));
                    }

                    if (diagnosList.Count == 0)
                        return;
                }
            }
            catch{
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
