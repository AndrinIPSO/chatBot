using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBot
{
    /// <summary>
    /// Bot Engine
    /// </summary>
    public class BotEngine 
    {
        /// <summary>
        /// Storage (Speicher)
        /// </summary>
        public IStorage Storage { get; set; }



        /// <summary>
        /// Nachrichten liste
        /// </summary>
        public List<Message> messages = new List<Message>();

        /// <summary>
        /// Ctor instanziiert storage mit standartpfad
        /// </summary>
        public BotEngine(StorageType storageType)
        {
            if (storageType == StorageType.TextStorage)
            {
            Storage = new TextStorage();
            }
        }

        /// <summary>
        /// füget fragen und antworten der Liste hinzu
        /// </summary>
        public void initMessages()
        {

            try
            {

                //Exeption wenn index nicht gefunden wird
                Storage.Load();

                for (int i = 0; i < Storage.messages.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        messages.Add(new Message(Storage.messages[i], Storage.messages[i + 1]));
                    }
                }
            }
            catch (NullReferenceException)
            {

                throw new ChatBoxException("In der Datei steht nichts", 102);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ChatBoxException("Die Datei hat eine Frage zu viel oder eine Antwort zu wenig", 101);

            }
            catch (Exception)
            {

                throw new ChatBoxException("In der Datei steht nichts", 102);
            }
        }

        /// <summary>
        /// Gibt die antwort zurück
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <returns></returns>
        public string getAnswer(string keyword)
        {
            try
            {
                string answer = "";
                foreach (Message msg in messages)
                {
                    if (msg.keyword == keyword)
                    {
                        answer = msg.answer;
                        break;
                    }
                  
                }
                if (answer == "")
                {
                    throw new ChatBoxException("Keine Antwort gefunden", 100);
                }
                return answer;
               
                
            }
            catch(ChatBoxException ex)
            {
                throw new ChatBoxException("Keine Antwort gefunden", 100);
            }
        }
        public enum StorageType
        {
            TextStorage
        }

    }
}
