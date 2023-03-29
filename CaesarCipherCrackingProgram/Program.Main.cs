using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASW4016_02_Week3
{
    public partial class Program
    {
        static Dictionary dic;
        static Sentence sent;

        static void Main()
        {
            dic = new Dictionary();
            sent = new Sentence();
            string fileLoc = "";

            try
            {
                fileLoc = Convert.ToString(Console.ReadLine());

                dic.readWordsFromCsvlFile(fileLoc);

                sent.writePlainSetAsTxt(Convert.ToString(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
