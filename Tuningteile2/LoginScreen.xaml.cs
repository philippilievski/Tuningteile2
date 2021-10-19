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
using System.Windows.Shapes;
using Tuningteile2.Login;

namespace Tuningteile2
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtBoxUsername.Text != null && pwdBoxPassword.Password != null)
            {
                var pwd = LoginLogic.Compute256Hash(pwdBoxPassword.Password);

                var isCorrect = LoginLogic.Validation(txtBoxUsername.Text, pwd);
                if(isCorrect)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie Ihren Benutzernamen und Passwort ein!");
            }
        }
    }
}
