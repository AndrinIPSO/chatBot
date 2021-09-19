using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace BotLib
{
    public class Log
    {
        public string path = Environment.CurrentDirectory + @"\log.txt";
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
