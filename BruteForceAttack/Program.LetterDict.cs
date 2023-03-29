using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAttack
{
    partial class Program
    {
        // 비밀번호 생성 및 크래킹을 위한 비밀번호 후보 생성에 사용하는 문자 데이터셋
        public class LetterDict
        {
            // 숫자: 48~57                             (10개)
            public int N_number { get; private set; }
            public List<int> number { get; private set; }
            // 알파벳: 65~90, 97~122                   (52개)
            public int N_alphabet { get; private set; }
            public List<int> alphabet { get; private set; }
            // 특수문자: 33~47, 58~64, 91~96, 123~126  (32개)
            public int N_specialChar { get; private set; }
            public List<int> specialChar { get; private set; }

            public LetterDict() {
                N_number = 10;
                N_alphabet = 52;
                N_specialChar = 32;

                number = new List<int>(N_number);
                for (int i = 0, j = 48; i < N_number; i++, j++)
                {
                    number.Add(j);
                }

                alphabet = new List<int>(N_alphabet);
                for (int i = 0, j = 65; i < N_alphabet; i++)
                {
                    alphabet.Add(j);

                    if (j == 90) { j = 97; }
                    else { j++; }
                }

                specialChar = new List<int>(N_specialChar);
                for (int i = 0, j = 33; i < N_specialChar; i++)
                {
                    specialChar.Add(j);

                    if (j == 47) { j = 58; }
                    else if (j == 64) { j = 91; }
                    else if (j == 96) { j = 123; }
                    else { j++; }
                }
            }
        }
    }
}
