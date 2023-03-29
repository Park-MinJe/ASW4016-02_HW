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
        public class Sentence
        {
            public const int N_sentences = 100;

            // 생성되거나 읽어온 문장 저장
            public List<string> plainSet { get; private set; }
            public List<string> cryptSet { get; private set; }

            public Sentence()
            {
                plainSet = new List<string>();
                cryptSet = new List<string>();
            }

            // 시저암호 생성 함수
            public void sentenceToCaesar()
            {
                try
                {
                    Random rnd = new Random();

                    foreach(string line in plainSet)
                    {
                        int n_shift = rnd.Next(1, 26);

                        string[] data = line.Split(' ');
                        foreach(string d in data)
                        {
                            for (int i = 0; i < d.Length; i++)
                            {
                                /*
                                시저 암호 생성부. n_shift를 이용해 아스키 코드 상의 알파벳 범위 안에서 순환
                                대문자는 대문자끼리, 소문자는 소문자끼리 순환
                                */
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            // 문장 데이터셋을 텍스트 파일로 출력
            public void writePlainSetAsTxt(string filename)
            {
                try
                {
                    Random rnd = new Random();

                    StreamWriter sw = new StreamWriter(filename);
                    for (int i = 0; i < 100; i++)
                    {
                        if (dic.words.Count > 0)
                        {
                            string s = "";
                            int N_wordsPerSentence = rnd.Next(7, 11);
                            for (int j = 0; j < N_wordsPerSentence; j++)
                            {
                                s += dic.words[rnd.Next(dic.words.Count)];
                                if (j < N_wordsPerSentence - 1)
                                {
                                    s += " ";
                                }
                            }
                            sw.WriteLine(s);
                            plainSet.Add(s);

                            // debug
                            //Console.WriteLine(sentences[i]);
                        }
                    }
                    sw.Close();

                    // debug
                    //Console.WriteLine(sentences.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }

            // 텍스트 파일로부터 문장 데이터셋 입력
            public void readPlainSetFromTxt(string filename)
            {
                // 출처: https://learn.microsoft.com/ko-kr/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(filename);

                    string line = sr.ReadLine();
                    while(line != null)
                    {
                        plainSet.Add(line);
                        line = sr.ReadLine();
                    }

                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
    }
}
