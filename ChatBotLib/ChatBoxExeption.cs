using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotLib
{
    public class ChatBoxException : Exception
    {
        /// <summary>
        /// Fehler Nummer
        /// </summary>
        public int chatBotErrorNum { get; set; }
        /// <summary>
        /// Chatbot Exception ohne Nummer
        /// </summary>
        /// <param name="message">Fehlernachricht</param>
        public ChatBoxException(string message)
               : base(message)
        {
        }
        /// <summary>
        /// Chatbot Exception mit Fehlernr und nachricht
        /// </summary>
        /// <param name="message">Fehlernachricht</param>
        /// <param name="errorNum">Fehlernummer</param>
        public ChatBoxException(string message, int errorNum)
        : this(message)
        {
            chatBotErrorNum = errorNum;
        }
    }
}

