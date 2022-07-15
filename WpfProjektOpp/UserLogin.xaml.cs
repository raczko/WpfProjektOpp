using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfProjektOpp
{
    /// <summary>
    /// Logika interakcji dla klasy UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender , RoutedEventArgs e)
        {
            WynajmowanieAutEntities db = new WynajmowanieAutEntities();
            var docs = from d in db.Pracownicies
                       select d;
            string a = txtUsername.Text;
            string b = txtPassword.Password;
            List<string> login = new List<string>();
            List<string> password = new List<string>();
            foreach (var doc in docs)
            {
                login.Add(doc.Name);
                password.Add(doc.Password);
            }
            if (login.Contains(a) && password.Contains(b))
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Zle haslo lub login");
            }
        }
    }
}
