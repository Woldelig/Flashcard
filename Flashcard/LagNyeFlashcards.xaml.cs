using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Flashcard
{
    /// <summary>
    /// Interaction logic for LagNyeFlashcards.xaml
    /// </summary>
    public partial class LagNyeFlashcards : Window
    {
        String filnavn;
        public LagNyeFlashcards()
        {
            InitializeComponent();
            SpmSvarFeilmld.Content = "";
            TemaFeilmld.Content = "";
        }
        private void LageTemaBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog lagreFilDialog = new SaveFileDialog();
            lagreFilDialog.Filter = "CSV | *.csv";

            if (String.IsNullOrEmpty(TemaTextbox.Text))
            {
                TemaFeilmld.Content = "Du må skrive inn en overskrift for tema";
            }

            if (lagreFilDialog.ShowDialog() == true)
            {
                //Lar deg skrive navnet på filen
                filnavn = lagreFilDialog.FileName;
                StreamWriter sw = new StreamWriter(lagreFilDialog.FileName);
                sw.Write(TemaTextbox.Text);
                sw.Write(sw.NewLine);
                sw.Close();
            }
        }

        private void LagSpmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SpmTextbox.Text))
            {
                LeggTilICsvFil(SpmTextbox, SvarTextbox);
            }
        }

        private void LeggTilICsvFil(TextBox spmTextbox, TextBox svarTextbox)
        {

        }

    }
}
