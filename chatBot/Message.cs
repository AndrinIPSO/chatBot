using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBot
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

            #region Old
        //private string[] col;
        //public void getAnswer()
        //{

        //    foreach (string word in Messanges)
        //    {
        //        col = word.Split(',');
        //    }
        //    int i = 0;
        //    foreach (string word in col)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            if (col[i] == "keyword")
        //            {
        //                answer = col[i + 1];
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            i++;
        //        }
        //    }
        //    if (i == col.Length)
        //    {
        //        throw new Exception("Answer not found");
        //    }
        //}
            #endregion
    }
}
