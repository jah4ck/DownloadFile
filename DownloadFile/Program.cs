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
            ReferenceWSCtrlPc.WSCtrlPc ws = new ReferenceWSCtrlPc.WSCtrlPc();
            string codeappli = "DownloadFile.exe";
            DateTime datetraitement = DateTime.Now;
            string linkDownload = ConfigurationManager.AppSettings["linkDownload"];
            Object Guid = Registry.GetValue(@"HKEY_USERS\.DEFAULT\Software\CtrlPc\Version", "GUID", null);
            try
            {
                
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 2, "Téléchargement de " + args[1]);
                string uri = linkDownload + args[1];
                string dest = @"C:\ProgramData\CtrlPc\"+args[0]+@"\"+args[1];
                WebClient webClient = new WebClient();
                webClient.DownloadFile(new Uri(uri), dest);
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 2, "Fin du téléchargement de " + args[1]);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                datetraitement = DateTime.Now;
                ws.TraceLog(Guid.ToString(), datetraitement, codeappli, 1,"Erreur lors du téléchargement de "+args[1]+" --> "+ err.Message);
            }
            
        }
        
    }
}
