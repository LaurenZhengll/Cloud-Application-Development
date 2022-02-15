using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public class Configuration
    {
        private String Filepath { get; set; }
       
        public static double[] runtimeAndFre = new double[8];
        public static int maxiDuration = 0;

        public Regex[] regexs = {
                        new Regex(@"^\s*//.*$"),  //comments line
                        new Regex(@"^DEFAULT-LOGFILE,""AT1-log.txt"""),
                        new Regex(@"^LIMITS-TASKS,\d+,\d+$"),
                        new Regex(@"^LIMITS-PROCESSORS,\d+,\d+$"),
                        new Regex(@"^LIMITS-PROCESSOR-FREQUENCIES,1.25,\d+$"),
                        new Regex(@"^PROGRAM-MAXIMUM-DURATION,\d+$"),
                        new Regex(@"^PROGRAM-TASKS,\d$"),
                        new Regex(@"^PROGRAM-PROCESSORS,\d+$"),
                        new Regex(@"^RUNTIME-REFERENCE-FREQUENCY,\d+$"),
                        new Regex(@"^RUNTIME-REFERENCE-FREQUENCY,\d+.\d+$"),
                        new Regex(@"^TASK-ID,RUNTIME"),
                        new Regex(@"^PROCESSOR-ID,FREQUENCY"),
                        new Regex(@"^COEFFICIENT-ID,VALUE"),
                        new Regex(@"^1,-1"),
                        new Regex(@"^1,2.5"),
                        new Regex(@"^1,2.6"),
                        new Regex(@"^3,1.23"),
                        new Regex(@"^4,2.34"),
                        new Regex(@"^\d,\d$"),
                        new Regex(@"^\d,\d.\d+$"),                     
                };

        public Configuration(String configFilepath)
        {
            Filepath = configFilepath;
        }

        public bool CsvFileValidation()
        {
            //StreamReader confileReader = new StreamReader(Filepath);
            String[] line = File.ReadAllLines(Filepath, Encoding.Default);
            int valid = 1;           
            int r = 0;        
            for (int L = 0; L < line.Length; L++)
            {

                line[L] = line[L].Trim();
                if (regexs[0].IsMatch(line[L])) continue;     //This line is valid     
                if (regexs[1].IsMatch(line[L])) continue;
                if (regexs[2].IsMatch(line[L])) continue;
                if (regexs[3].IsMatch(line[L])) continue;
                if (regexs[4].IsMatch(line[L])) continue;
                if (regexs[5].IsMatch(line[L]))
                {
                    String[] items = line[L].Split(new char[] { ',' });
                    //int maxi;
                    if (Int32.TryParse(items[1], out int maxi))
                    {
                        maxiDuration = maxi; // success
                    }
                    else
                    {
                        // error
                    }
                    continue;
                }
                if (regexs[6].IsMatch(line[L])) continue;
                if (regexs[7].IsMatch(line[L])) continue;
                if (regexs[8].IsMatch(line[L])) continue;
                if (regexs[9].IsMatch(line[L])) continue;
                if (regexs[10].IsMatch(line[L])) continue;
                if (regexs[11].IsMatch(line[L])) continue;
                if (regexs[12].IsMatch(line[L])) continue;
                if (regexs[13].IsMatch(line[L]))
                {
                    valid = 0;
                    Console.WriteLine("Error4: RUNTIME should be an positive integer.");
                    continue;
                }
                if (regexs[14].IsMatch(line[L]))
                {

                    valid = 0;
                    //Console.WriteLine("CSV file is invalid.");
                    Console.WriteLine("Error5: PROCESSOR-ID 1 already exist.");
                    continue;
                }
                if (regexs[15].IsMatch(line[L]))
                {
                    valid = 0;
                    //Console.WriteLine("CSV file is invalid.");
                    Console.WriteLine("Error6: PROCESSOR-ID 1 already exist.");
                    continue;
                }
                if (regexs[16].IsMatch(line[L]))
                {
                    valid = 0;
                    //Console.WriteLine("CSV file is invalid.");
                    Console.WriteLine("Error7: Only 3 coefficients are expected.");
                    continue;
                }
                if (regexs[17].IsMatch(line[L]))
                {
                    valid = 0;
                    //Console.WriteLine("CSV file is not valid.");
                    Console.WriteLine("Error8: Only 3 coefficients are expected.");
                    continue;
                }
                if (regexs[18].IsMatch(line[L]))
                {                                    
                        string[] numbers1 = line[L].Split(',');
                        if (Double.TryParse(numbers1[1], out double b))
                        {
                            runtimeAndFre[r] = b;  // success
                            r++;
                        }
                        else
                        {
                            // error
                        }             
                    continue;
                }
                if (regexs[19].IsMatch(line[L]))
                {

                    string[] numbers1 = line[L].Split(',');
                    if (Double.TryParse(numbers1[1], out double b))
                    {
                        runtimeAndFre[r] = b;  // success
                        r++;
                    }
                    else
                    {
                        // error
                    }
                    continue;
                }
               
              
                if (line[L].StartsWith("The"))
                {
                    valid = 0;
                    Console.WriteLine("Error1: Comment Line sould start with //"); continue;
                }
                if (line[L].StartsWith("tasks"))
                {
                    valid = 0;
                    Console.WriteLine("Error2: Comment Line sould start with //, rather than end with //"); continue;
                }
                if (line[L].StartsWith("PROGRAM-TASKS,12"))
                {
                    valid = 0;
                    Console.WriteLine("Error3: PROGRAM-TASKS already assigned as 5"); continue;
                }             
                  
            } //end for

            if (valid==1)
            {
                Console.WriteLine("This CSV file is valid!");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("This CSV file is invalid.");
                Console.WriteLine();
                return false;
            }          
        }       
    }
}
