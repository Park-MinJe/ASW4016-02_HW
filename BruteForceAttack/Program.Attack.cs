using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAttack
{
    partial class Program
    {
        public class Attack
        {
            // 사용 문자 아스키 코드 set
            public LetterDict letters { get; private set; }

            public List<char> letterSamples { get; private set; }
            public int lsLen { get; private set; }
            public long[] N_candidate { get; private set; }

            public Passwd pwd { get; private set; }

            public Attack()
            {
                pwd = new Passwd();

                letters = new LetterDict();

                letterSamples = new List<char>(letters.N_number + letters.N_alphabet + letters.N_specialChar);

                for (int i = 0; i < letters.N_number; i++)
                {
                    letterSamples.Add(Convert.ToChar(letters.number[i]));
                }

                for (int i = 0; i < letters.N_alphabet; i++)
                {
                    letterSamples.Add(Convert.ToChar(letters.alphabet[i]));
                }

                for (int i = 0; i < letters.N_specialChar; i++)
                {
                    letterSamples.Add(Convert.ToChar(letters.specialChar[i]));
                }

                lsLen = letterSamples.Count;

                N_candidate = new long[pwd.N_pwdLen];
                for (int i = 0, j = pwd.minPwdLen; j <= pwd.maxPwdLen; i++, j++)
                {
                    N_candidate[i] = Convert.ToInt64(Math.Pow(lsLen, j));
                    //Console.WriteLine(N_candidate[i]);
                }

                //debug
                for (int i = 0; i < letterSamples.Count; i++)
                {
                    Console.Write(letterSamples[i]);

                    if (i == letters.N_number - 1) { Console.WriteLine(); }
                    else if (i == letters.N_number + letters.N_alphabet - 1) { Console.WriteLine(); }
                    else if (i == letters.N_number + letters.N_alphabet + letters.N_specialChar - 1) { Console.WriteLine(); }
                }
            }

            // 현재 과정의 인덱스 값을 받아 그 순서에 해당하는 비밀번호 반환
            public string generatePwdCandidate(int pwdLen, long lsIdx)
            {
                string rt = "";

                try
                {
                    for (int i = 0; i < pwdLen; i++)
                    {
                        rt += letterSamples[Convert.ToInt32(lsIdx % Convert.ToInt64(lsLen))];

                        lsIdx /= lsLen;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("lsIdx: {0}", lsIdx);
                    Console.WriteLine("lsLen: {0}", lsLen);
                    Console.WriteLine("Convert.ToInt64(lsLen): {0}", Convert.ToInt64(lsLen));
                    Console.WriteLine("letterSample Idx: {0}", Convert.ToInt32(lsIdx % Convert.ToInt64(lsLen)));
                    Console.WriteLine("Exception: " + e.Message);
                }

                return rt;
            }

            // 무차별 대입 공격 실행부
            public string BruteForceAttack(string target)
            {
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                string candidate = "";
                string log = "";

                //pwd.generatePswd(1, 4);

                try
                {
                    for (int pwdLen = pwd.minPwdLen; pwdLen <= pwd.maxPwdLen; pwdLen++)
                    {
                        for (long i = 0; i < N_candidate[pwdLen - pwd.minPwdLen]; i++)
                        {
                            double progressState = Math.Round(Convert.ToDouble(i + 1) / N_candidate[pwdLen - pwd.minPwdLen] * 100, 2);
                            if ((watch.ElapsedMilliseconds != 0) && (watch.ElapsedMilliseconds % 60000 == 0))
                            {
                                //Console.WriteLine(progressState);
                                Console.WriteLine("Thread ID {0} - Target {1} - Process Len-{2} state: {3}% ({4}/{5})",
                                    Thread.CurrentThread.ManagedThreadId, target, pwdLen, progressState, i, N_candidate[pwdLen - pwd.minPwdLen]);
                                log += "Thread ID " + Thread.CurrentThread.ManagedThreadId + " - Target " + target +
                                    " - Process Len-" + pwdLen + " state: " + progressState + 
                                    "% (" + i + "/" + N_candidate[pwdLen - pwd.minPwdLen] + ")\n";
                            }

                            candidate = generatePwdCandidate(pwdLen, i);

                            // debug
                            //Console.WriteLine(candidate);

                            if (candidate == target)
                            {
                                watch.Stop();

                                Console.WriteLine("\nTarget Password: {0}", target);
                                log += "Target:" + target;
                                Console.WriteLine("Cracked Password: {0}", candidate);
                                log += " - Cracked by:" + candidate;
                                Console.WriteLine("Time: " + watch.ElapsedMilliseconds.ToString());
                                log += " - Time:" + watch.ElapsedMilliseconds.ToString() + "\n";

                                return log;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    return log + "Err While Cracking " + target + "\n";
                }

                return log + "Err While Cracking " + target + "\n";
            }
        }
    }
}
