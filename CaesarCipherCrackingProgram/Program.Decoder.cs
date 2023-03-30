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
        public class Decoder
        {
            public void decodeSentence(StreamWriter sw, string line)
            {
                Random rnd = new Random();
                try
                {
                    List<int> numShiftArr = new List<int>();
                    for (int i = 0; i < 25; i++)
                    {
                        numShiftArr.Add(i + 1);
                    }

                    string[] data = line.Split(' ');
                    bool found = false;

                    for (int i = 0; i < 25; i++)
                    {
                        int rndShiftIdx = rnd.Next(numShiftArr.Count);
                        Console.WriteLine("Number of Shift = " + numShiftArr[rndShiftIdx]);
                        sw.WriteLine("Number of Shift = " + numShiftArr[rndShiftIdx]);

                        string tmpCryptSent = "";
                        foreach (string d in data)
                        {
                            string tmpCrypWord = "";
                            for (int j = 0; j < d.Length; j++)
                            {
                                /*
                                시저 암호 생성부. n_shift를 이용해 아스키 코드 상의 알파벳 범위 안에서 순환
                                대문자는 대문자끼리, 소문자는 소문자끼리 순환
                                */
                                char tmp = d[j];
                                if (tmp >= 65 && tmp <= 90)
                                {
                                    tmp = Convert.ToChar(tmp - numShiftArr[rndShiftIdx]);
                                    if (tmp < 65)
                                    {
                                        tmp = Convert.ToChar(91 - (65 - tmp));
                                    }
                                }
                                else if (tmp >= 97 && tmp <= 122)
                                {
                                    tmp = Convert.ToChar(tmp - numShiftArr[rndShiftIdx]);
                                    if (tmp < 97)
                                    {
                                        tmp = Convert.ToChar(123 - (97 - tmp));
                                    }
                                }
                                tmpCrypWord += tmp;
                            }

                            if (!dic.findWordAtDict(tmpCrypWord))
                            {
                                Console.WriteLine(tmpCrypWord + " is not at Dictionary. So try the other number of shitf.");
                                sw.WriteLine(tmpCrypWord + " is not at Dictionary. So try the other number of shitf.");

                                numShiftArr.Remove(numShiftArr[rndShiftIdx]);

                                found = false;

                                break;
                            }
                            else
                            {
                                Console.WriteLine(tmpCrypWord + " is at Dictionary. So continue next word.");
                                sw.WriteLine(tmpCrypWord + " is at Dictionary. So continue next word.");

                                tmpCryptSent += tmpCrypWord + " ";

                                found = true;
                            }
                        }

                        if (found)
                        {
                            Console.WriteLine("Plain String: " + tmpCryptSent);
                            sw.WriteLine("Plain String: " + tmpCryptSent);

                            break;
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("decodeSentence(): " + e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
