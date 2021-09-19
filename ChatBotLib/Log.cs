using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace ChatBotLib
{
    /// <summary>
    /// Log Klasse
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Pfad der Logdatei
        /// </summary>
        public string path = Environment.CurrentDirectory + @"\log.txt";
        /// <summary>
        /// String wird mit Zeitstempel in Logdatei geschrieben(appended)
        /// </summary>
        /// <param name="content">zu Hinzuzufügender String</param>
        public void toFile(string content)
        {
            try
            {
            StreamWriter sr = new StreamWriter(path,true);
            sr.WriteLine($"------{DateTime.Now}------");
            sr.Write(content);
            sr.Close();
            }catch
            {
                throw new Exception(); 
            }
        }
    }
}
