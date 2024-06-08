using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : UserControl
    {
        public UsersPage()
        {
            InitializeComponent();
            FillingList();
        }
        private void FillingList(List<ДанныеРаботников>? rabotnics = null)
        {
            ListUser.Items.Clear();
            try
            {
                using (var db = new БдмисContext())
                {
                    if (rabotnics == null)
                        rabotnics = db.ДанныеРаботниковs.Include(d => d.IdперсональныеДанныеNavigation).OrderBy(a => a.IdперсональныеДанныеNavigation.Фамилия).ToList();

                    if (rabotnics.Count == 0)
                        return;
                    
                    foreach (var item in rabotnics)
                    {
                        string? post = null;
                        if (db.Сотрудникиs.Where(d => d.IdданныеРаботника == item.Id).IsNullOrEmpty() &&
                            !db.Врачиs.Where(d => d.IdданныеРаботника == item.Id).IsNullOrEmpty())
                            post = "Врач";
                        else if(!db.Сотрудникиs.Where(d => d.IdданныеРаботника == item.Id).IsNullOrEmpty())
                            post = db.Сотрудникиs.Include(d => d.IdдолжностьNavigation)
                                                 .First(d => d.IdданныеРаботника == item.Id).IdдолжностьNavigation.Название;

                        if(post.IsNullOrEmpty())
                            continue;
                        Users user = new Users(item.IdперсональныеДанныеNavigation, post);
                        user.ubdate += Update;
                        ListUser.Items.Add(user);
                    }
                }
            }
            catch{}
        }

        private void Update(object obj) => FillingList();

    }
}
