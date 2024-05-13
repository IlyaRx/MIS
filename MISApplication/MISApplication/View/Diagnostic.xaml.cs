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
    /// Логика взаимодействия для Diagnostic.xaml
    /// </summary>
    public partial class Diagnostic : UserControl
    {
        private Диагностика _diagnostic;
        public Diagnostic(Диагностика diagnostic)
        {
            InitializeComponent();
            _diagnostic = diagnostic;
            NameDiagnostic.Text = diagnostic.Название;
            DateDiagnostic.Text = diagnostic.ДатаСдачи.ToString("D");
            ResultDiagnostic.Text = diagnostic.Результаты;
        }
    }
}
