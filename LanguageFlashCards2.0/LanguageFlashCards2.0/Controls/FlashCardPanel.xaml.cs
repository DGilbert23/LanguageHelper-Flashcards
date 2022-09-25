using LanguageFlashCards2._0.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LanguageFlashCards2._0.Controls
{
    /// <summary>
    /// Interaction logic for FlashCardPanel.xaml
    /// </summary>
    public partial class FlashCardPanel : UserControl
    {
        List<string> wordList = new List<string>();
        List<string> translationList = new List<string>();
        int cardCountRemaining = 0;
        int attempts = 0;
        int maxAttempts = 3;

        public FlashCardPanel()
        {
            InitializeComponent();            
        } 
        
        public void BeginFlashCards()
        {
            switch(Variables.flashCardMode)
            {
                case 1:
                    PopulateWordListHiragana();
                    cardCountRemaining = Variables.flashCardCount;
                    SetUpNextWord();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private void PopulateWordListHiragana()
        {
            wordList = Variables.dBController.GetListHiragana();
        }

        private void SetUpNextWord()
        {
            lblMatchWord.Content = ChooseNextWord();
            attempts = 0;
            UpdateAttemptsLabel();
            tbInput.Text = "";
            PopulateTranslations();
        }

        private string ChooseNextWord()
        {
            string word;
            Random r = new Random();
            word = wordList[r.Next(0, wordList.Count)];
            cardCountRemaining--;
            return word;
        }

        private void PopulateTranslations()
        {
            translationList = Variables.dBController.GetTranslations(1, lblMatchWord.Content.ToString());
        }

        private bool CheckTranslation()
        {  
            return translationList.Contains(tbInput.Text);
        }

        private void HandleSuccess()
        {
            lblSuccess.Visibility = Visibility.Visible;
            lblFail.Visibility = Visibility.Hidden;
            translationList.Remove(tbInput.Text);
            lvTranslations.ItemsSource = translationList;
            SetUpNextWord();
        }

        private void HandleFailure()
        {
            attempts++;
            if (attempts != maxAttempts)
            {
                UpdateAttemptsLabel();
            }
            else
            {
                lblSuccess.Visibility = Visibility.Hidden;
                lblFail.Visibility = Visibility.Visible;
                lvTranslations.ItemsSource = translationList;
                SetUpNextWord();
            }
        }

        private void UpdateAttemptsLabel()
        {
            lblAttempts.Content = attempts + " of " + maxAttempts;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbInput.Text != "")
            {
                if (CheckTranslation())
                {
                    HandleSuccess();
                }
                else
                {
                    HandleFailure();
                }
            }
        }
    }
}
