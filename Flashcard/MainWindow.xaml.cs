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

namespace Flashcard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void LagNyeFlashcardsBtn_Click(object sender, RoutedEventArgs e)
        {
            LagNyeFlashcards nyeFlashecards = new LagNyeFlashcards();
            nyeFlashecards.Show();
            this.Close();
        }

        private void BrukEksisterendeFlashCardBtn_Click(object sender, RoutedEventArgs e)
        {
            BrukEksisterendeFlashcards brukEksisterendeFlashcards = new BrukEksisterendeFlashcards();
            brukEksisterendeFlashcards.Show();
            this.Close();
        }
    }
}
