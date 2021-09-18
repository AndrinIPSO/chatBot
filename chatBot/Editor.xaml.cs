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

namespace chatBot
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public bool opened { get; set; }
        public string path { get; set; }
        private bool firstfocus = true;
        public Editor()
        {
            InitializeComponent();
            opened = true;
            loadFile();
            lb_log.Content = "Log: Window Initialised";
        }

        public Editor(string path)
        {
            InitializeComponent();
            this.path = path;
            opened = true;
            loadFile();
            lb_log.Content = "Log: Window Initialised";
        }

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

        private void tb_file_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstfocus)
            {
                loadFile();
                firstfocus = false;
            }
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] vs;
                //tb_file.text muss durch 2 'teilbar sein
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
            catch( ChatBoxException ex)
            {
                lb_log.Content = $"Log: {ex.Message} Problem: {ex.chatBotErrorNum}";
            }
            catch (Exception ex)
            {
                lb_log.Content = $"Log: {ex.Message}";
            }
        }

        private void tb_file_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bt_save_Click(bt_save, e);
            }
        }

        private void tb_file_TextChanged(object sender, TextChangedEventArgs e)
        {
            lb_log.Content = $"Log: Text Changed >> Press enter to save";
        }

        private void bt_generate_Click(object sender, RoutedEventArgs e)
        {
               
            tb_file.Text = "Hallo,Guten Tag";
            bt_save_Click(sender, e);
        }
    }
}
