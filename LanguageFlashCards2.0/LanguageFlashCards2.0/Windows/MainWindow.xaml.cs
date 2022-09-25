using LanguageFlashCards2._0.Classes;
using LanguageFlashCards2._0.Windows;
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

namespace LanguageFlashCards2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.panelModeSelection.StartFlashCardsClicked += ModeSelectPanel_StartFlashCardsClicked;

            Variables.connectionString = Properties.Settings.Default.ConnectionString;
            Variables.dBController = new DBController();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowLogIn login = new WindowLogIn();
            this.Hide();
            login.ShowDialog();

            if (Variables.validUser)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.Close();
            }
        }

        

        // Hides the two small panels and shows the flashcard panel
        private void ModeSelectPanel_StartFlashCardsClicked(object sender, EventArgs e)
        {
            panelCurrentStats.Visibility = Visibility.Collapsed;
            panelModeSelection.Visibility = Visibility.Collapsed;
            panelFlashCard.Visibility = Visibility.Visible;
            panelFlashCard.BeginFlashCards();
        }
    }
}
