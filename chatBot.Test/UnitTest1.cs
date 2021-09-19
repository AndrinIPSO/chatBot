using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using chatBot;
using ChatBotLib;
using System.IO;

namespace chatBot.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Exception Test für Fehlende Datei
        /// </summary>
        [TestMethod]
        public void TextStorageClass_NoFile()
        {
            TextStorage t1 = new TextStorage();
            if (File.Exists(t1.pfad))
            {
                File.Delete(t1.pfad);
            }

            try
            {
                t1.Load();
                Assert.Fail();
            }
            catch (ChatBoxException)
            {
                // Exeption should be thrown
            }
        }
        /// <summary>
        /// Testet das Auslesen der Datei bzw. die Aufteilung der Wörter
        /// </summary>
        [TestMethod]
        public void TextStorageClass_MessageField()
        {
            TextStorage t1 = new TextStorage();
            if (File.Exists(t1.pfad))
            {
                File.Delete(t1.pfad);
            }

            StreamWriter sr = new StreamWriter(t1.pfad);
            sr.WriteLine("wort,antwort");
            sr.Close();
            t1.Load();
            string[] shouldbe = new string[] { "wort", "antwort" };
            Assert.AreEqual(shouldbe[1], t1.messages[1]);
        }
        /// <summary>
        /// Testet das Aufteilen in Frage und Antwort
        /// </summary>
        [TestMethod]
        public void MessageClass_initMessages()
        {
            BotEngine BE = new BotEngine(BotEngine.StorageType.TextStorage);
            if (File.Exists(BE.Storage.pfad))
            {
                File.Delete(BE.Storage.pfad);
            }

            StreamWriter sr = new StreamWriter(BE.Storage.pfad);
            sr.WriteLine("wort,antwort");
            sr.Close();
            BE.initMessages();
            Assert.AreEqual(BE.messages[0].answer, "antwort");
        }
        /// <summary>
        /// Testet die getAnswer() Funktion
        /// </summary>
        [TestMethod]
        public void MessageClass_getAnswer()
        {
            BotEngine BE = new BotEngine(BotEngine.StorageType.TextStorage);
            if (File.Exists(BE.Storage.pfad))
            {
                File.Delete(BE.Storage.pfad);
            }

            StreamWriter sr = new StreamWriter(BE.Storage.pfad);
            sr.WriteLine("wort,antwort");
            sr.Close();
            BE.initMessages();
            Assert.AreEqual(BE.getAnswer("wort"), "antwort");
        }
        /// <summary>
        /// Testet ob eine Log Datei erstellt wurde.
        /// </summary>
        [TestMethod]
        public void LogClass_toFile()
        {
            Log testlog = new Log();
            testlog.toFile("Hallo");
            Assert.IsTrue(File.Exists(testlog.path));
        }
    }
}


