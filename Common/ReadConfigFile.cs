using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace DAL
{
  public   class ReadProjectConfigFile
    {
        private static string fileName;
        public ReadProjectConfigFile()
        {

        }
        public static string MConfigString()
        {
            string MfileName = "MStartup.config";
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + MfileName) == true)
            {
                string st;
                st = File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\" + MfileName);
               
                return st;
            }
            else
                return "";
        }

        public static  string ConfigString()
        {
            fileName = "Startup.config";
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + fileName) == true)
            {
                string st;
                st= File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\" + fileName);
                 return st;

                 //return @"Server=DESKTOP-4F01EMP\SQL2016;Database=ZERP22;User id=sa;Password=123;";
                 
            }
            else
                return "";
        }



        public static string GetReportPath()
        {
            fileName = "ReportPath.config";
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + fileName) == true)
            {
                string Path;
                Path = File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\" + fileName);
               


                return Path;
            }
            else
                return "";
        }
    }
}
