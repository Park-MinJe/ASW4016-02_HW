using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAttack
{
    partial class Program
    {
        static void Main()
        {
            // Class for demo
            // 프로그램 실행을 GUI로 진행하기 전 콘솔 단에서 실험을 진행하기 위한 Main 함수
            demo d = new demo();

            // Make Password
            d.demo_PwdGeneration();
            Console.WriteLine(d.pwd.pwds.Length * d.pwd.pwds[0, 0].Length);

            // Brute Force Attack
            d.demo_initAttack();

            for (int j = 2; j < d.pwd.N_pwdLen; j++)
            {
                for (int i = 0; i < d.pwd.N_pwdType; i++)
                {
                    StreamWriter sw = new StreamWriter("log\\" + i + "-" + j + ".log");

                    // 병렬처리하여 연산
                    Parallel.For(0, d.pwd.N_pwdPerType, (k) =>
                    {
                        Console.WriteLine("Current Thread ID : {0}, Target : {1}-{2}-{3}-{4}",
                            Thread.CurrentThread.ManagedThreadId, i, j, k, d.pwd.pwds[i, j][k]);
                        sw.WriteLine("Current Thread ID : " + Thread.CurrentThread.ManagedThreadId
                            + ", Target : " + i + "-" + j + "-" + k + "-" + d.pwd.pwds[i, j][k] + "\n"
                            + d.demo_GenerateAttack(d.pwd.pwds[i, j][k]));
                    });
                    sw.Close();
                }
            }
        }
    }
}