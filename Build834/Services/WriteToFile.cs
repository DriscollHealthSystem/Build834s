using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapAdjustConsole.Services
{
    class WriteToFile
    {
        public static void WriteToTxtFile(List<string> lines, string fileName, string PlanCode, string FileType)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            // Get root path of server
            string filePath = System.Configuration.ConfigurationManager.AppSettings["TapestryFilePath"];
            if(string.Equals(FileType, "M"))
            {
                filePath += PlanCode + "\\Monthly";
            }
            else
            {
                filePath += PlanCode + "\\Daily";
            }

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, fileName)))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}
