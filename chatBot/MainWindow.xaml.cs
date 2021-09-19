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
using ChatBotLib;

namespace chatBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Bot Engine Feld
        /// </summary>
        public BotEngine BE = new BotEngine(BotEngine.StorageType.TextStorage);
        /// <summary>
        /// Editor Feld
        /// </summary>
        public Editor editor = new Editor();
        /// <summary>
        /// Log Feld
        /// </summary>
        public Log log = new Log();
        /// <summary>
        /// Initialisierung
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                BE.initMessages();
            }
            catch (ChatBoxException ex)
            {
                if (ex.chatBotErrorNum == 101)
                {
                    MessageBox.Show($"Fehler: {ex.chatBotErrorNum} \nProblem: {ex.Message}");

                }
                if (ex.chatBotErrorNum == 102)
                {
                    MessageBox.Show($"Fehler: {ex.chatBotErrorNum} \nProblem: {ex.Message}");

                }
                if (ex.chatBotErrorNum == 103)
                {
                    MessageBox.Show($"Fehler: {ex.chatBotErrorNum} \nProblem: {ex.Message}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\nProblem: {ex.Message}");
            }
        }
        /// <summary>
        /// Nachricht an Bot übergeben durch Knopf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_send_Click(object sender, RoutedEventArgs e)
        {
            sendMSG();
        }
        /// <summary>
        /// Nachricht an Bot übergeben durch ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendMSG();
            }
        }
        /// <summary>
        /// Senden der Nachricht an den Bot
        /// </summary>
        private void sendMSG()
        {
            try
            {
                BE.initMessages();

                //try catch
                tb_talk.Text += $"USER:\t{tb_input.Text}\n";
                tb_talk.Text += $"BOT:\t{BE.getAnswer(tb_input.Text)}\n";
                tb_input.Text = "";
            }
            catch (ChatBoxException ex)
            {
                if (ex.chatBotErrorNum == 100)
                {
                    tb_talk.Text += $"BOT:\tKeine Antwort gefunden\n";
                    tb_input.Text = "";

                }
            }
        }
        /// <summary>
        /// Löschen des Textinhalts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_talk.Text = "";
        }
        /// <summary>
        /// Öffnen des Editors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_editor_Click(object sender, RoutedEventArgs e)
        {

            if (!editor.opened)
            {
                initEditor();
            }
            else
            {
                editor.path = BE.Storage.pfad;
                editor.Show();
            }
        }
        /// <summary>
        /// Editor Initiialisieren und öffnen
        /// </summary>
        public void initEditor()
        {
            editor = new Editor(BE.Storage.pfad);
            editor.Show();
        }
        /// <summary>
        /// Text zu Logdatei
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_log_Click(object sender, RoutedEventArgs e)
        {
            log.toFile(tb_talk.Text);
        }
    }
}
