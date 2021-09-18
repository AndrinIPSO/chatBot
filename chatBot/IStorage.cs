using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBot
{
    public interface IStorage
    {
        void Load();
        string[] messages { get; set; }
        string pfad { get; set; }
    }
}
