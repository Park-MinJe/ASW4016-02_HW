using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAttack
{
    partial class Program
    {
        public class demo
        {
            public Attack attack;
            public Passwd pwd;

            public void demo_TPL()
            {
                const int NumberOfRetries = 3;
                const int DelayOnRetry = 1000;

                // 1. 순차 처리
                // 한개의 스레드가 0~999 출력
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Current Tread ID : {0}, Count : {1}",
                        Thread.CurrentThread.ManagedThreadId, i);
                }
                Console.Read();

                // 2. 병렬 처리
                // 다중스레드가 병렬로 출력
                Parallel.For(0, 1000, (i) =>
                {
                    Console.WriteLine("Current Thread ID : {0}, Count : {1}",
                        Thread.CurrentThread.ManagedThreadId, i);
                });

                Console.Read();
            }

            // 병렬처리 과정을 보기 위한 출력 함수
            public void demo_work(int n, int wait)
            {
                Console.WriteLine($"Task{n} : {DateTime.Now.ToString("HH:mm:ss")}");
                Task.Delay(1000 * wait).Wait();
                Console.WriteLine($"Task{n} [ElapsedTime] : {DateTime.Now.ToString("HH:mm:ss")}");
            }

            // Task.Run을 이용한 병렬처리 예시
            public void demo_Task1()
            {
                // 이유는 모르지만 안됨..
                var t1 = Task.Run(() => demo_work(1, 2));
                var t2 = Task.Run(() => demo_work(2, 3));
                var t3 = Task.Run(() => demo_work(3, 5));
                var t4 = Task.Run(() => demo_work(4, 1));

                // t1 Task가 종료
                if (t1.IsCompleted)
                {
                    Console.WriteLine("t1 is done.");
                }
            }

            // Invoke를 이용한 병렬처리 예시
            public void demo_Task2()
            {
                Parallel.Invoke(
                    () => { demo_work(1, 2); },
                    () => { demo_work(2, 3); },
                    () => { demo_work(3, 5); },
                    () => { demo_work(4, 1); }
                );
                Console.WriteLine("All done.");
            }

            // 비밀번호 생성 또는 텍스트 파일로부터 입력을 위한 함수
            public void demo_PwdGeneration()
            {
                int pwdGenerationMode = 1;
                string filename = "test.txt";

                pwd = new Passwd();

                Console.WriteLine("패스워드 생성 방식");
                Console.WriteLine("(1: 생성   2: 파일로부터 읽어오기)");
                pwdGenerationMode = Convert.ToInt32(Console.ReadLine());

                if (pwdGenerationMode == 1)
                {
                    pwd.generatePswd();
                    pwd.writePwdSetAsTxt(filename);
                }
                else if (pwdGenerationMode == 2)
                {
                    Console.Write("\t파일명: ");
                    filename = Console.ReadLine();
                    pwd.readPwdSetFromTxt(filename);
                }

                //Console.WriteLine(pwd.pwds.Length * pwd.pwds[0, 0].Length);
            }

            // Attack class의 생성자를 이용해 attack을 초기화해주는 함수
            public void demo_initAttack()
            {
                attack = new Attack();
            }

            // 무차별 대입 공격 실행을 위한 데모 함수
            public string demo_GenerateAttack(string target)
            {
                return attack.BruteForceAttack(target);
            }
        }
    }
}
