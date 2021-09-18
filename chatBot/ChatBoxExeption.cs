using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBot
{
    class ChatBoxException : Exception
    {

        public int chatBotErrorNum { get; set; }


        public ChatBoxException(string message)
               : base(message)
        {

        }

        public ChatBoxException(string message, int errorNum)
        : this(message)
        {
            chatBotErrorNum = errorNum;
        }
    }
}

