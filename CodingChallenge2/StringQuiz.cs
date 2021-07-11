using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge2
{
    public class StringQuiz
    {
        public StringQuiz()
        {
        }

        // #a#b#c#
        // ["","a","b","c",""]
        //  0 (1)  2  (3)  4
        public int NumberOfCharactersEscaped(string s)
        {
            string[] strList = s.Split('#');
            var poundCount = s.Count(x => x == '#');
            int count = 0;
            if (poundCount < 2)
            {
                return count;
            }

            for (int i = 1; i < strList.Length - 1; i++)
            {
                var str = strList[i];
                if (str.Length < 2 || i%2 ==0) // string length must > than 2 and the char is in odd position 
                {
                    continue;
                }
                for(int j=1; j<str.Length; j++)
                {
                    if(str[j-1] == '!')
                    {
                        count = char.IsLower(str[j]) ? count + 1 : count;
                    }
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

            // loop through position 0 to n-talentCount
            // talent nums must meet the talentCount
            // [0,1,2,3,4,5,6] talent posistion n = 7,  talentCount 4 -> n-talentCount = 3;
            // [0,1,2,4] start i = 0  i=0
            // [1,2,4,5] start i = 1
            // [2,3,4,5] start i = 2
            // [3,4,5,6] start i = 3 (n-talentCount) = 3
            // [4,5,6,7] start i = 4 <- position 7 is out of array
            for (int i = 0; i <= n - talentCount; i++)
            {
                int j = i;
                int s = 0;
                var set = new HashSet<int>(); // c# HashSet doesn't have duplictes
                while (j < n)
                {
                    if (set.Count == talentCount) // once the hashset count reached talentCount break the loop
                        break;
                    var t = talents[j];
                    set.Add(t);
                    s++;
                    j++;
                }
                // loop finished -> check if hashset count is gerater or equal than talentCount
                tSize[i] = set.Count < talentCount ? -1 : s; 
            }
            // loop the rest of element and set value to -1 since the respt positions count is less than talentCount
            // no way to meet the condition
            for (int i = n - talentCount + 1; i < n; i++)
            {
                tSize[i] = -1;
            }


            return tSize;

        }

        public int FirstUniqChar(string s)
        {
            var map = new Dictionary<char, int>();
            char[] cArr = s.ToCharArray();
            for (int i = 0; i < cArr.Length; i++)
            {
                if (map.ContainsKey(cArr[i]))
                {
                    map[cArr[i]] += 1;
                }
                else
                {
                    map[cArr[i]] = 1;
                }
            }
            var u = map.Where(x => x.Value == 1).Select(x => x.Key).ToList();
            if (u.Count == 0)
            {
                return -1;
            }
            int pos = 0;
            bool found = false;
            for (int i = 0; i < cArr.Length; i++)
            {
                var c = cArr[i];
                for (int j = 0; j < u.Count; j++)
                {
                    if (c == u[j])
                    {
                        pos = i;
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            return pos;
        }
    }
}
