using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotLib
{
    /// <summary>
    /// NAchrichten klasse
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Schlüsselwort
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// Antwort
        /// </summary>
        public string answer { get; set; }
        /// <summary>
        /// Leere Nachricht
        /// </summary>
        public Message()
        {

        }
        /// <summary>
        /// Nachricht mit keyword und antwort
        /// </summary>
        /// <param name="keywrd">Schlüsselwort</param>
        /// <param name="answer">Antwort</param>
        public Message(string keywrd, string answer)
        {
            keyword = keywrd;
            this.answer = answer;
        }
    }
}
