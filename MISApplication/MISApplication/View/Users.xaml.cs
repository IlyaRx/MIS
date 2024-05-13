using Microsoft.EntityFrameworkCore;
using MISApplication.Model;
using System.Windows;
using System.Windows.Forms;

namespace MISApplication.View
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : System.Windows.Controls.UserControl
    {
        private ПерсональныеДанные _staff;
        private string _post;
        public Users(ПерсональныеДанные staff, string post)
        {
            InitializeComponent();
            Name.Text = staff.Имя;
            Lastname.Text = staff.Фамилия;
            SecondName.Text = staff.Отчество;
            Post.Text = post;
            _staff = staff;
            _post = post;

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show( "Вы точно хотите удалить сотрудника", "Сообщение", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
                try {
                    using (var db = new БдмисContext())
                    {
                        if(_post != "Врач")
                        {
                            var employee = db.Сотрудникиs.Include(s => s.IdданныеРаботникаNavigation)
                                          .Include(s => s.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation)
                                          .First(s => s.IdданныеРаботникаNavigation.IdперсональныеДанные == _staff.Id);
                            if(employee != null)
                                db.Сотрудникиs.Remove(employee);
                        }
                        else
                        {
                            var doctor = db.Врачиs.Include(s => s.IdданныеРаботникаNavigation)
                                          .Include(s => s.IdданныеРаботникаNavigation.IdперсональныеДанныеNavigation)
                                          .First(s => s.IdданныеРаботникаNavigation.IdперсональныеДанные == _staff.Id);
                            if(doctor != null)
                                db.Врачиs.Remove(doctor);
                        }
                        db.SaveChanges();
                        System.Windows.Forms.MessageBox.Show($"Удаление завершено. Вы удалили {_staff.Имя} {_staff.Фамилия} {_staff.Отчество}");
                    }
                }catch { }
                return;
        }
    }
}
