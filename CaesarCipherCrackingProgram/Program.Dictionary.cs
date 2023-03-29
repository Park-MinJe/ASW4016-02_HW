using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ASW4016_02_Week3
{
    public partial class Program
    {
        public class Dictionary
        {
            public List<string> words { get; private set; }

            public Dictionary()
            {
                words = new List<string>();
            }

            public void readWordsFromCsvlFile(string filename)
            {
                try
                {
                    Random rnd = new Random();

                    StreamReader sr = new StreamReader(filename);

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        if (data[0][0] == '#')
                        {
                            continue;
                        }

                        if(rnd.Next(2) == 1)
                        {
                            data[1] = data[1].ToUpper();
                        }

                        words.Add(data[1]);
                    }

                    // Debug
                    Console.WriteLine("단어 개수: {0}", words.Count);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
