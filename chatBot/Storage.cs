using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBot
{
    /// <summary>
    /// Speicherklasse
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Pfad
        /// </summary>
        public string pfad { get; set; }
        /// <summary>
        /// Nachrichtenstring
        /// </summary>
        public string[] messages { get; set; }
        /// <summary>
        /// Storage mit standartpfad
        /// </summary>
        public Storage()
        {
            pfad = Environment.CurrentDirectory + @"\storage.txt";
        }
        /// <summary>
        /// Storage mit eigenem pfad
        /// </summary>
        /// <param name="newPath">eigener Pfad</param>
        public Storage(string newPath)
        {
            pfad = newPath;
        }

        /// <summary>
        /// teilt die datei in wörter auf in den messages array
        /// </summary>
        public void Load()
        {
            try
            {
                string[] line = File.ReadAllLines(pfad);
                //Exeption einbauen wenn pfad nich existiert
                foreach (string word in line)
                {
                    messages = word.Split(',');
                }
            }
            catch (FileNotFoundException)
            {
                throw new ChatBoxException("Keine Datei vorhanden", 103);
            }
        }
    }
}
