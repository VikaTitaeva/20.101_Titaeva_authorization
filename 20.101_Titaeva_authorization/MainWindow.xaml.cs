using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace _20._101_Titaeva_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void done_btn_Click(object sender, RoutedEventArgs e)
        {
            string login = login_txtbx.Text;
            string password = password_txtbx.Text;

            KW_authorizationEntities m = new KW_authorizationEntities();
            var authorization = m.User;
            var role = m.Role;
            var user = authorization.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                if(user.RoleID == 1)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль клиент");
                }
                if (user.RoleID == 2)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль менеджер");
                }
                if (user.RoleID == 3)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль администратор");
                }
            }
            else
            {
                MessageBox.Show("Неверно введены логин или пароль!");
            }
        }
    }
}
