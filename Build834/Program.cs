using Build834.Models;
using Build834.Services;
using CapAdjustConsole.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build834
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            string PlanCode = args[0]; // Possible values 82, H4, KC, KD, 05
            string FileType = args[1]; // Possible values M, D
                //Test Comment

  

           
            Logger logger = LogManager.GetCurrentClassLogger();

            var text834 = new List<string>();
            string fileName;


            if (string.Equals(PlanCode, "05")) // CHIP NUECES
            {
                if (string.Equals(FileType, "M")) // MONTHLY
                {
                    text834 = LoadCHIPMonthly(PlanCode);
                    fileName = DatabaseService.GetFileName(PlanCode);
                }
                    else // DAILY
                    {
                    text834 = LoadCHIPDaily(PlanCode);
                    fileName = DatabaseService.GetFileName_Daily(PlanCode);
                }
            }
            else // STAR OR STAR KIDS
            {
                if (string.Equals(FileType, "M")) // MONTHLY
                {
                    text834 = LoadSTARMonthly(PlanCode, logger);
                    fileName = DatabaseService.GetFileName(PlanCode);
                }
                else // DAILY
                {
                    text834 = LoadSTARDaily(PlanCode);
                    fileName = DatabaseService.GetFileName_Daily(PlanCode);
                }
            }

                string newFileName = AddDateToFileName(fileName, PlanCode);


                // Write to text file
                WriteToFile.WriteToTxtFile(text834, newFileName, PlanCode, FileType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            } 
        }

        private static string AddDateToFileName(string fileName, string PlanCode)
        {
            int jdate;
            if (string.Equals(PlanCode, "05"))
            {
                Int32.TryParse(fileName.Substring(6, 3), out jdate); // Extract julian date from file name
            }
            else
            {
                Int32.TryParse(fileName.Substring(5, 3), out jdate); // Extract julian date from file name
            }
            DateTime prevYear = new DateTime(DateTime.Now.Year - 1, 12, 31); // Get last day of previous year
            DateTime newjdate = prevYear.AddDays(jdate); // Add julian date to last day of previous year
            string newfulldate = newjdate.ToString("MMddyyyy"); // get date in string format
            string newFileName;
            if (string.Equals(PlanCode, "05"))
            {
                newFileName = fileName.Substring(0, 9) + "_" + newfulldate + ".TXT"; // return full file name
            }
            else
            {
                newFileName = fileName.Substring(0, 8) + "_" + newfulldate + ".TXT"; // return full file name
            }
            return newFileName;
        }

        private static List<string> LoadSTARMonthly(string PlanCode, Logger logger)
        {
            List<string> text834 = new List<string>();

            var members = DatabaseService.GetMembers_STAR_SK(PlanCode);

            // Add 834 Header to text834
            text834.AddRange(DatabaseService.Header834(PlanCode));

            // Loop through members, add entire member segment to text834
            foreach (var member in members)
            {
                text834.AddRange(STAR_SK_MemberSegments.BuildMemberSegments(member, PlanCode));
            }

            // Add 834 Footer to text834
            text834.AddRange(DatabaseService.Footer834(PlanCode));

            return text834;
        }

        private static List<string> LoadSTARDaily(string PlanCode)
        {
            List<string> text834 = new List<string>();

            var members = DatabaseService.GetMembers_STAR_SK_Daily(PlanCode);

            // Add 834 Header to text834
            text834.AddRange(DatabaseService.Header834_Daily(PlanCode));

            // Loop through members, add entire member segment to text834
            foreach (var member in members)
            {
                text834.AddRange(STAR_SK_MemberSegments_Daily.BuildMemberSegments(member, PlanCode));
            }

            // Add 834 Footer to text834
            text834.AddRange(DatabaseService.Footer834_Daily(PlanCode));

            return text834;
        }

        private static List<string> LoadCHIPMonthly(string PlanCode)
        {
            List<string> text834 = new List<string>();

            var members = DatabaseService.GetMembers_CHIP(PlanCode);

            // Add 834 Header to text834
            text834.AddRange(DatabaseService.Header834(PlanCode));

            // Loop through members, add entire member segment to text834
            foreach (var member in members)
            {
                text834.AddRange(CHIP_MemberSegments.BuildMemberSegments(member, PlanCode));
            }

            // Add 834 Footer to text834
            text834.AddRange(DatabaseService.Footer834(PlanCode));

            return text834;
        }

        private static List<string> LoadCHIPDaily(string PlanCode)
        {
            List<string> text834 = new List<string>();

            var members = DatabaseService.GetMembers_CHIP_Daily(PlanCode);

            // Add 834 Header to text834
            text834.AddRange(DatabaseService.Header834_Daily(PlanCode));

            // Loop through members, add entire member segment to text834
            foreach (var member in members)
            {
                text834.AddRange(CHIP_MemberSegments.BuildMemberSegments(member, PlanCode));
            }

            // Add 834 Footer to text834
            text834.AddRange(DatabaseService.Footer834_Daily(PlanCode));

            return text834;
        }
    }
}
