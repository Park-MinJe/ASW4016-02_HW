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
        static Decoder decoder;

        static void Main()
        {
            dic = new Dictionary();
            sent = new Sentence();
            decoder = new Decoder();
            string fileLoc = "";

            try
            {
                fileLoc = Convert.ToString(Console.ReadLine());

                dic.readWordsFromCsvlFile(fileLoc);

                sent.writePlainSetAsTxt(Convert.ToString(Console.ReadLine()));

                sent.sentenceToCaesar(Convert.ToString(Console.ReadLine()));

                // demo
                //StreamWriter sw = new StreamWriter("log\\String0-DecodingLog.txt");

                //Console.WriteLine("Crypt String: " + sent.cryptSet[0]);
                //sw.WriteLine("Crypt String: " + sent.cryptSet[0]);

                //decoder.decodeSentence(sw, sent.cryptSet[0]);

                //sw.Close();

                Parallel.For(0, sent.cryptSet.Count, (i) =>
                {
                    StreamWriter sw = new StreamWriter("log\\String" + i + "-DecodingLog.txt");

                    Console.WriteLine("Crypt String: " + sent.cryptSet[i]);
                    sw.WriteLine("Crypt String: " + sent.cryptSet[i]);

                    decoder.decodeSentence(sw, sent.cryptSet[i]);

                    sw.Close();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main(): " + ex.Message);
            }
        }
    }
}
