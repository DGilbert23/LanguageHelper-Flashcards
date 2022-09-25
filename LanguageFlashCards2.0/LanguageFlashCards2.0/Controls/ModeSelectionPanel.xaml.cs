using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LanguageFlashCards2._0.Classes;

namespace LanguageFlashCards2._0.Controls
{
    /// <summary>
    /// Interaction logic for ModeSelectionPanel.xaml
    /// </summary>
    public partial class ModeSelectionPanel : UserControl
    {
        public ModeSelectionPanel()
        {
            InitializeComponent();
        }

        // Used for verifcation of positive integer only
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        // Four methods for logic of flash card mode selection.

        private void rbMode1_Checked(object sender, RoutedEventArgs e)
        {
            Variables.flashCardMode = 1;
            if(tbCardCount.Text != "")
            {
                btnStartFlashcards.IsEnabled = true;
            }
            else
            {
                btnStartFlashcards.IsEnabled = false;
            }
        }

        private void rbMode2_Checked(object sender, RoutedEventArgs e)
        {
            Variables.flashCardMode = 2;
            if (tbCardCount.Text != "")
            {
                btnStartFlashcards.IsEnabled = true;
            }
            else
            {
                btnStartFlashcards.IsEnabled = false;
            }
        }

        private void rbMode3_Checked(object sender, RoutedEventArgs e)
        {
            Variables.flashCardMode = 3;
            if (tbCardCount.Text != "")
            {
                btnStartFlashcards.IsEnabled = true;
            }
            else
            {
                btnStartFlashcards.IsEnabled = false;
            }
        }

        private void rbMode4_Checked(object sender, RoutedEventArgs e)
        {
            Variables.flashCardMode = 4;
            if (tbCardCount.Text != "")
            {
                btnStartFlashcards.IsEnabled = true;
            }
            else
            {
                btnStartFlashcards.IsEnabled = false;
            }
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void tbCardCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((rbMode1.IsChecked ?? false) || (rbMode2.IsChecked ?? false) || (rbMode3.IsChecked ?? false) || (rbMode4.IsChecked ?? false))
            {
                btnStartFlashcards.IsEnabled = true;
            }
            else
            {
                btnStartFlashcards.IsEnabled = false;
            }

            if (tbCardCount.Text == "")
                btnStartFlashcards.IsEnabled = false;
        }

        private void btnStartFlashcards_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Collapsed;
            Variables.flashCardCount = Convert.ToInt32(tbCardCount.Text);
            OnStartFlashCardsClicked(e);
        }

        // Methods for raising event to parent control so it knows we need to start the flash cards.
        public event EventHandler StartFlashCardsClicked;
        protected virtual void OnStartFlashCardsClicked(EventArgs e)
        {
            var handler = StartFlashCardsClicked;
            if (handler != null)
                handler(this, e);
        }
    }
}
