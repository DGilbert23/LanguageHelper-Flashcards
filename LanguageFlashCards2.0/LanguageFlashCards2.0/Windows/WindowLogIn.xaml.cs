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
using LanguageFlashCards2._0.Classes;

namespace LanguageFlashCards2._0.Windows
{
    /// <summary>
    /// Interaction logic for WindowLogIn.xaml
    /// </summary>
    public partial class WindowLogIn : Window
    {
        public WindowLogIn()
        {
            InitializeComponent();
            tbUserName.Focus();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Variables.dBController.authenticateUser(tbUserName.Text.Trim(), pbPassword.Password))
            {
                //code to pull user's info into User object

                Variables.validUser = true;
                this.Close();
            }
            else
            {
                labelError.Visibility = Visibility.Visible;
            }
        }

        private void pbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                btnSubmit_Click(sender, null);
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                btnSubmit_Click(sender, null);
        }
    }
}
