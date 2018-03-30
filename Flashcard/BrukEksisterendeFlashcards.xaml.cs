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
using System.IO;
using Microsoft.Win32;

namespace Flashcard
{
    /// <summary>
    /// Interaction logic for BrukEksisterendeFlashcards.xaml
    /// </summary>
    public partial class BrukEksisterendeFlashcards : Window
    {
        Boolean TrykketPåKnappen = false;
        String[,] FlashcardArray;
        public BrukEksisterendeFlashcards()
        {
            InitializeComponent();
        }
        private void ÅpneFlashcardFilBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filDialog = new OpenFileDialog();
            filDialog.Title = "Åpne CSV fil";
            filDialog.Filter = "CSV | *.csv";
            filDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (filDialog.ShowDialog() == true)
            {
                ÅpneFlashcardFilBtn.Visibility = Visibility.Collapsed;
            }
            //StreamReader leser = new StreamReader(filDialog.FileName);
            int antallLinjer = 0;
            using (var leser = File.OpenText(filDialog.FileName))
            {
                while (leser.ReadLine() != null)
                {
                    antallLinjer++;
                }
                //Fjerner overskriften
                antallLinjer--;
            }
            testtsetst.Text = antallLinjer.ToString();
        }
    }
}
