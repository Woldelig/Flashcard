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
        Boolean knappErTrykket = false;
        public LagNyeFlashcards()
        {
            InitializeComponent();
            SpmSvarFeilmld.Content = "";
            TemaFeilmld.Content = "";
            LeggTilFlerLbl.Content = "";
        }

        private void LagSpmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!knappErTrykket)
            {
                if (String.IsNullOrEmpty(TemaTextbox.Text))
                {
                    TemaFeilmld.Content = "Du må skrive inn en overskrift for tema";
                }
                filnavn = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), TemaTextbox.Text + ".csv");
                if (File.Exists(filnavn))
                {
                    TemaFeilmld.Content = "Filnavn/temanavn eksisterer allerede.";
                    return;
                }
                //Denne linjen lagrer alle filer på desktop. Kunne brukt filedialog men liker den ikke. Linjen under er lang fordi da kan den brukes uten å vite brukernavn på pc
                Console.WriteLine(filnavn);
                StreamWriter sw = new StreamWriter(filnavn);
                sw.Write(TemaTextbox.Text);
                sw.Write(sw.NewLine);
                sw.Close();
            }

            if (!String.IsNullOrEmpty(SpmTextbox.Text)){ LeggTilICsvFil(SpmTextbox, SvarTextbox); }
            if (!String.IsNullOrEmpty(SpmTextbox2.Text)){ LeggTilICsvFil(SpmTextbox2, SvarTextbox2); }
            if (!String.IsNullOrEmpty(SpmTextbox3.Text)){ LeggTilICsvFil(SpmTextbox3, SvarTextbox3); }
            if (!String.IsNullOrEmpty(SpmTextbox4.Text)){ LeggTilICsvFil(SpmTextbox4, SvarTextbox4); }
            if (!String.IsNullOrEmpty(SpmTextbox5.Text)){ LeggTilICsvFil(SpmTextbox5, SvarTextbox5); }
            knappErTrykket = true;
        }

        private void LeggTilICsvFil(TextBox spmTextbox, TextBox svarTextbox)
        {
            StreamWriter sw = new StreamWriter(filnavn, append: true);
            sw.Write(spmTextbox.Text + ";" + svarTextbox.Text);
            sw.Write(sw.NewLine);
            sw.Close();
            spmTextbox.Clear();
            svarTextbox.Clear();
            if (String.IsNullOrEmpty(LeggTilFlerLbl.Content.ToString()))
            {
                LeggTilFlerLbl.Content = "Trykk på lag spørsmål for å fortsette å legge til flere spørsmål til temaet: " + TemaTextbox.Text;
            }
        }

    }
}
