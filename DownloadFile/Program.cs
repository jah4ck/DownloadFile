using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

namespace DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace MyTrace = new Trace();
            string codeappli = "DownloadFile.exe";
            DateTime datetraitement = DateTime.Now;
            string linkDownload = ConfigurationManager.AppSettings["linkDownload"];
            Object Guid = Registry.GetValue(@"HKEY_USERS\.DEFAULT\Software\CtrlPc\Version", "GUID", null);
            try
            {
                if (args[0].Length >2 && args[1].Length>2)
                {
                    MyTrace.WriteLog("Téléchargement de " + args[1], 2, codeappli);
                    string uri = linkDownload + args[1];
                    string dest = @"C:\ProgramData\CtrlPc\" + args[0] + @"\" + args[1];
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri(uri), dest);
                    datetraitement = DateTime.Now;
                    MyTrace.WriteLog("Fin du téléchargement de " + args[1], 2, codeappli);
                }
                
            }
            catch (Exception err)
            {
                MyTrace.WriteLog("Erreur lors du téléchargement de " + args[1] + " --> " + err.Message, 1, codeappli);
            }
            
        }
        
    }
}
