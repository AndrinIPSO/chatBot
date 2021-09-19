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
using ChatBotLib;

namespace chatBot
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        /// <summary>
        /// Ist Objekt erstellt
        /// </summary>
        public bool opened { get; set; }
        /// <summary>
        /// Dateipfad
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Wurde bereits fokusiert
        /// </summary>
        private bool firstfocus = true;
        /// <summary>
        /// Neuer leerer Editor
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            opened = true;
            loadFile();
            lb_log.Content = "Log: Window Initialised";
        }
        /// <summary>
        /// Editor mit benutzerdefiniertem Pfad
        /// </summary>
        /// <param name="path">Pfad</param>
        public Editor(string path)
        {
            InitializeComponent();
            this.path = path;
            opened = true;
            loadFile();
            lb_log.Content = "Log: Window Initialised";
        }
        /// <summary>
        /// Schliessen des Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            opened = false;
        }
        /// <summary>
        /// Datei Laden
        /// </summary>
        public void loadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                tb_file.Text = sr.ReadToEnd();

                sr.Close();
                lb_log.Content = "Log: File loaded";

            }
            catch (Exception ex)
            {
                lb_log.Content = $"Log: {ex.Message}";
            }
        }
        /// <summary>
        /// Bereitstellen der Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_file_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstfocus)
            {
                loadFile();
                if (tb_file.Text == null || tb_file.Text == "")
                {
                    generate(generateType.New);
                }
                firstfocus = false;
            }
        }
        /// <summary>
        /// Speichern der Datei
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] vs;
                StreamWriter sr = new StreamWriter(path);

                Convert.ToString(tb_file.Text);
                vs = tb_file.Text.Split(',');
                if (vs.Length % 2 == 0)
                {
                    sr.Write(tb_file.Text);
                    sr.Close();
                    lb_log.Content = "Log: File saved";
                }
                else
                {
                    throw new ChatBoxException("Die Datei hat eine Frage zu viel oder eine Antwort zu wenig", 101);
                }
            }
            catch (ChatBoxException ex)
            {
                lb_log.Content = $"Log: {ex.Message} Problem: {ex.chatBotErrorNum}";
            }
            catch (Exception ex)
            {
                lb_log.Content = $"Log: {ex.Message}";
            }
        }
        /// <summary>
        /// Speichern der Datei durch drücken der Enter Taste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_file_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bt_save_Click(bt_save, e);
            }
        }
        /// <summary>
        /// User über änderung des Texts informieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_file_TextChanged(object sender, TextChangedEventArgs e)
        {
            lb_log.Content = $"Log: Text Changed >> Press enter to save";
        }
        /// <summary>
        /// Generiern von 50 Wörtern durch Knopfdruck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_generate_Click(object sender, RoutedEventArgs e)
        {
            if (tb_file.Text == "" || tb_file.Text == null)
            {
                generate(generateType.New);
            }
            else
            {
                generate(generateType.Append);
            }
        }
        /// <summary>
        /// Generieren der 50 Wörter
        /// </summary>
        /// <param name="mode"></param>
        public void generate(generateType mode)
        {
            if (mode == generateType.New)
            {
                tb_file.Text = "Hallo,Moin,Wie gehts,Nice,Was macht du,Dir behilflich sein,Andrin Schellenberg,Ist ein Applikationsentwickler,Abiyan Kahn,Abisan der Lol profi,Wie ist das Wetter,OK,Mach Licht aus,Nein,Wieheisst du,Achsel Schweiss,Wo bin ich,Olten,Wie ist Franken zu Euro,1.2 Franken,Wird Dogecoin hoch gehen,Ja wegen Elon Mask,Bin ich Wach,Ja weil du mit mir schreibst,Nevin Perumpamkuzi,schläft gerade,Guten Abend,Guten Morgen,Mach Musik an,Ja Musik ist an,Wann bist du erreichbar,Ich bin für dich 24 / 7 erreichbar,Wann regnet es,Am Donnerstag,Wie Alt bist du,So alt wie Das Internet,Bist du ein Mensch, Nein Ich bin eine Künstliche Intelligenz,Ist Cola schlecht,Ja wegen dem Zucker,Sag mir ein Witz,Why do Java programmers wear glasses? Because they dont C#,Wie gross bist du,So gross wie die Speicherplatte,Wie ist mein Name,Steht auf deinem Ausweis,Wo habe ich Schule,In Arrau,Wer ist James Bond,Ein Actor der ein Spion spielt,Wann bin ich erwachsen,Wenn du 18 Jahre alt bist,Was ist das beste Wasser,Fiji Wasser,Wie viele Wörter brauche ich,50 Wörter,Hey Achsel,Ja wie kann ich dir behilflich sein,WOW,wow,Bro,Bruder,Gute Nacht,Nacht,Hast du Geld,Ja aber Virtuell,Wie Viel verdienst du,Deine Dankbarkeit,Mach Haus zu,Ja ist gemacht,Brauchst du Essen,Nein,Wo habe ich meine Brille,Schau auf deinem Kopf,Hast du ein EFZ,In meinem Treumen,Mach mir ein Tea,Ja es ist zurbereitet,Hast du mir eine zigi,Nein du rauchst nicht,Kauf mir ein Sofa,Kredit von 500 Fr für dein Sofa,Es ist stickig,Fenster wurden geöfnet,Was machen sachen,Nix,Bist du wach,Ja wenn du mich brauchst,Hast du freie Tage,Nein ich bin nur für dich da,Was hältst du von Siri,Wer ist das?,Was wirt im Google am meistens gesucht,Iphone 12,Wie ist die Formel von der Äquivalenz von Masse und Energie,E = mc²,Gibt es ein Buch,Ja er gibt,Wem gehört Microsoft,Bill Gates";
            }
            else if (mode == generateType.Append)
            {
                tb_file.Text = ",Hallo,Moin,Wie gehts,Nice,Was macht du,Dir behilflich sein,Andrin Schellenberg,Ist ein Applikationsentwickler,Abiyan Kahn,Abisan der Lol profi,Wie ist das Wetter,OK,Mach Licht aus,Nein,Wieheisst du,Achsel Schweiss,Wo bin ich,Olten,Wie ist Franken zu Euro,1.2 Franken,Wird Dogecoin hoch gehen,Ja wegen Elon Mask,Bin ich Wach,Ja weil du mit mir schreibst,Nevin Perumpamkuzi,schläft gerade,Guten Abend,Guten Morgen,Mach Musik an,Ja Musik ist an,Wann bist du erreichbar,Ich bin für dich 24 / 7 erreichbar,Wann regnet es,Am Donnerstag,Wie Alt bist du,So alt wie Das Internet,Bist du ein Mensch, Nein Ich bin eine Künstliche Intelligenz,Ist Cola schlecht,Ja wegen dem Zucker,Sag mir ein Witz,Why do Java programmers wear glasses? Because they dont C#,Wie gross bist du,So gross wie die Speicherplatte,Wie ist mein Name,Steht auf deinem Ausweis,Wo habe ich Schule,In Arrau,Wer ist James Bond,Ein Actor der ein Spion spielt,Wann bin ich erwachsen,Wenn du 18 Jahre alt bist,Was ist das beste Wasser,Fiji Wasser,Wie viele Wörter brauche ich,50 Wörter,Hey Achsel,Ja wie kann ich dir behilflich sein,WOW,wow,Bro,Bruder,Gute Nacht,Nacht,Hast du Geld,Ja aber Virtuell,Wie Viel verdienst du,Deine Dankbarkeit,Mach Haus zu,Ja ist gemacht,Brauchst du Essen,Nein,Wo habe ich meine Brille,Schau auf deinem Kopf,Hast du ein EFZ,In meinem Treumen,Mach mir ein Tea,Ja es ist zurbereitet,Hast du mir eine zigi,Nein du rauchst nicht,Kauf mir ein Sofa,Kredit von 500 Fr für dein Sofa,Es ist stickig,Fenster wurden geöfnet,Was machen sachen,Nix,Bist du wach,Ja wenn du mich brauchst,Hast du freie Tage,Nein ich bin nur für dich da,Was hältst du von Siri,Wer ist das?,Was wirt im Google am meistens gesucht,Iphone 12,Wie ist die Formel von der Äquivalenz von Masse und Energie,E = mc²,Gibt es ein Buch,Ja er gibt,Wem gehört Microsoft,Bill Gates";
            }
            lb_log.Content = "Log: Text Generatet >> Press Enter to save";
        }
        /// <summary>
        /// Bestimmen ob Hinzugefügt oder überschrieben wird
        /// </summary>
        public enum generateType
        {
            Append,
            New
        }
    }
}
