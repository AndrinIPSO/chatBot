using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotLib
{
    /// <summary>
    /// Storage Interface
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Lädt die Wörter der Quelle in denn messages String
        /// </summary>
        void Load();
        /// <summary>
        /// Enthält die Wörter
        /// </summary>
        string[] messages { get; set; }
        /// <summary>
        /// quelle der wörter
        /// </summary>
        string pfad { get; set; }
    }
}
