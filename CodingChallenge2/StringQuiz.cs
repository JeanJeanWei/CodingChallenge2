using System;
using System.Collections.Generic;

namespace CodingChallenge2
{
    public class StringQuiz
    {
        public StringQuiz()
        {
        }
        public int NumberOfCharactersEscaped(string s)
        {
            int count = 0;
            bool escape = false; // flag to turn on/off escape

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '#')
                {
                    escape = !escape;
                }

                if (escape && i > 0 && s[i - 1] == '!')
                {
                    count = char.IsLower(c) ? count + 1 : count;
                }

            }
            return count;
        }

        public int EntryTime(string s, string keypad)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            var map = Mapping(keypad);
            int steps = 0;
            char pre = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                char num = s[i];
                if (pre == num)
                {
                    continue;
                }
                if (map[pre].Contains(num))
                {
                    steps += 1;
                }
                else
                {
                    steps += 2;
                }
                pre = num;
            }
            return steps;
        }

        //[0,1,2,3,4,5,6,7,8,9] position
        //[0,1,2]
        //[3,4,5]
        //[6,7,8]
        private Dictionary<char, HashSet<char>> Mapping(string keypad)
        {
            char[] chars = keypad.ToCharArray();
            var map = new Dictionary<char, HashSet<char>>();
            var list = new List<char[]>();
            list.Add(new char[] { chars[1], chars[3], chars[4] });
            list.Add(new char[] { chars[0], chars[2], chars[3], chars[4], chars[5] });
            list.Add(new char[] { chars[1], chars[4], chars[5] });
            list.Add(new char[] { chars[0], chars[1], chars[4], chars[6], chars[7] });
            list.Add(new char[] { chars[0], chars[1], chars[2], chars[3], chars[5], chars[6], chars[7], chars[8] });
            list.Add(new char[] { chars[1], chars[2], chars[4], chars[7], chars[8] });
            list.Add(new char[] { chars[3], chars[4], chars[7] });
            list.Add(new char[] { chars[3], chars[4], chars[5], chars[6], chars[8] });
            list.Add(new char[] { chars[4], chars[5], chars[7] });
            for (int i = 0; i < keypad.Length; i++)
            {
                char c = keypad[i];
                map.Add(c, new HashSet<char>(list[i]));
            }
            return map;
        }

        public int[] TeamSize(int[] talents, int talentCount)
        {
            int n = talents.Length;
            var tSize = new int[n];
            if (talentCount > n)
            {
                for (int i = 0; i < n; i++)
                {
                    tSize[i] = -1;
                }
                return tSize;
            }


            for (int i = 0; i <= n - talentCount; i++)
            {
                int j = i;
                int s = 0;
                var set = new HashSet<int>();
                while (j < n)
                {
                    if (set.Count == talentCount)
                        break;
                    var t = talents[j];
                    set.Add(t);
                    s++;
                    j++;
                }
                tSize[i] = set.Count < talentCount ? -1 : s;
            }
            for (int i = n - talentCount + 1; i < n; i++)
            {
                tSize[i] = -1;
            }


            return tSize;

        }
    }
}
