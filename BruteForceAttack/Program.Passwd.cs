using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAttack
{
    partial class Program
    {
        public class Passwd
        {
            // 사용 문자 아스키 코드 set
            public LetterDict letters { get; private set; }

            // 비밀번호 유형 7가지
            public int N_pwdType { get; private set; } = 7;

            // 비밀번호 길이 5가지(4~8)
            public int N_pwdLen { get; private set; } = 5;
            public int minPwdLen { get; private set; } = 4;
            public int maxPwdLen { get; private set; } = 8;

            // 각 유형별 10개씩
            public int N_pwdPerType { get; private set; } = 10;

            public string[,][] pwds { get; private set; }

            public Passwd()
            {
                letters = new LetterDict();

                pwds = new string[N_pwdType, N_pwdLen][];
                for(int i = 0; i < N_pwdType; i++)
                {
                    for(int j = 0; j < N_pwdLen; j++)
                    {
                        pwds[i, j] = new string[N_pwdPerType];
                    }
                }
            }

            // 비밀번호 350개 생성
            public void generatePswd()
            {
                Random rand = new Random();

                for(int pwdType = 0; pwdType < N_pwdType; pwdType++)
                {
                    List<int> letterDictionary = new List<int>();
                    switch (pwdType)
                    {
                        case 0:
                            letterDictionary.AddRange(letters.number);
                            break;
                        case 1:
                            letterDictionary.AddRange(letters.alphabet);
                            break;
                        case 2:
                            letterDictionary.AddRange(letters.specialChar);
                            break;
                        case 3:
                            letterDictionary.AddRange(letters.number);
                            letterDictionary.AddRange(letters.alphabet);
                            break;
                        case 4:
                            letterDictionary.AddRange(letters.alphabet);
                            letterDictionary.AddRange(letters.specialChar);
                            break;
                        case 5:
                            letterDictionary.AddRange(letters.number);
                            letterDictionary.AddRange(letters.specialChar);
                            break;
                        case 6:
                            letterDictionary.AddRange(letters.number);
                            letterDictionary.AddRange(letters.alphabet);
                            letterDictionary.AddRange(letters.specialChar);
                            break;
                    }

                    for (int pwdLen = minPwdLen; pwdLen <= maxPwdLen; pwdLen++)
                    {
                        for (int pwdPerType = 0; pwdPerType < N_pwdPerType; pwdPerType++)
                        {
                            string pwd = "";
                            for (int k = 0; k < pwdLen; k++)
                            {
                                switch (pwdType)
                                {
                                    case 0:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number)]);
                                        break;
                                    case 1:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_alphabet)]);
                                        break;
                                    case 2:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_specialChar)]);
                                        break;
                                    case 3:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_alphabet)]);
                                        break;
                                    case 4:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_alphabet + letters.N_specialChar)]);
                                        break;
                                    case 5:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_specialChar)]);
                                        break;
                                    case 6:
                                        pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_alphabet + letters.N_specialChar)]);
                                        break;
                                }
                            }

                            pwds[pwdType, pwdLen - minPwdLen][pwdPerType] = pwd;
                            //Console.WriteLine(pwds[pwdType, pwdLen - minPwdLen][pwdPerType]);
                        }
                    }

                    //Console.WriteLine();
                }
            }

            // 입력 받은 매개변수로 유형을 판단하여 그에 해당하는 비밀번호 1개 반환
            public string generatePswd(int pwdType, int pwdLen)
            {
                Random rand = new Random();

                List<int> letterDictionary = new List<int>();
                switch (pwdType)
                {
                    case 0:
                        letterDictionary.AddRange(letters.number);
                        break;
                    case 1:
                        letterDictionary.AddRange(letters.alphabet);
                        break;
                    case 2:
                        letterDictionary.AddRange(letters.specialChar);
                        break;
                    case 3:
                        letterDictionary.AddRange(letters.number);
                        letterDictionary.AddRange(letters.alphabet);
                        break;
                    case 4:
                        letterDictionary.AddRange(letters.alphabet);
                        letterDictionary.AddRange(letters.specialChar);
                        break;
                    case 5:
                        letterDictionary.AddRange(letters.number);
                        letterDictionary.AddRange(letters.specialChar);
                        break;
                    case 6:
                        letterDictionary.AddRange(letters.number);
                        letterDictionary.AddRange(letters.alphabet);
                        letterDictionary.AddRange(letters.specialChar);
                        break;
                }

                string pwd = "";
                for (int k = 0; k < pwdLen; k++)
                {
                    switch (pwdType)
                    {
                        case 0:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number)]);
                            break;
                        case 1:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_alphabet)]);
                            break;
                        case 2:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_specialChar)]);
                            break;
                        case 3:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_alphabet)]);
                            break;
                        case 4:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_alphabet + letters.N_specialChar)]);
                            break;
                        case 5:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_specialChar)]);
                            break;
                        case 6:
                            pwd += Convert.ToChar(letterDictionary[rand.Next(letters.N_number + letters.N_alphabet + letters.N_specialChar)]);
                            break;
                    }
                }

                Console.WriteLine(pwd);
                return pwd;
            }

            // 비밀번호 데이터셋을 텍스트 파일로 출력
            public void writePwdSetAsTxt(string filename)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filename);
                    for (int pwdType = 0; pwdType < N_pwdType; pwdType++)
                    {
                        for (int pwdLen = minPwdLen; pwdLen <= maxPwdLen; pwdLen++)
                        {
                            for (int pwdPerType = 0; pwdPerType < N_pwdPerType; pwdPerType++)
                            {
                                sw.WriteLine(pwds[pwdType, pwdLen - minPwdLen][pwdPerType]);
                            }
                        }
                    }
                    sw.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }

            // 텍스트 파일로부터 비밀번호 데이터셋 입력
            public void readPwdSetFromTxt(string filename)
            {
                // 출처: https://learn.microsoft.com/ko-kr/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(filename);

                    for (int pwdType = 0; pwdType < N_pwdType; pwdType++)
                    {
                        for (int pwdLen = minPwdLen; pwdLen <= maxPwdLen; pwdLen++)
                        {
                            for (int pwdPerType = 0; pwdPerType < N_pwdPerType; pwdPerType++)
                            {
                                pwds[pwdType, pwdLen - minPwdLen][pwdPerType] = sr.ReadLine();
                                //Console.WriteLine(pwds[pwdType, pwdLen - minPwdLen][pwdPerType]);
                            }
                        }
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
