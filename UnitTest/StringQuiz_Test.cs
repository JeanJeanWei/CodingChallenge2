using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class StringQuiz_Test
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void NumberOfCharactersEscaped_Test(string s, int expected)
        {

            var sq = new StringQuiz();
            var num = sq.NumberOfCharactersEscaped(s);
            Assert.AreEqual(num, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(Data1), DynamicDataSourceType.Property)]
        public void Entry_Test(string s, string keypad, int expected)
        {

            var sq = new StringQuiz();
            var num = sq.EntryTime(s, keypad);
            Assert.AreEqual(num, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(Data2), DynamicDataSourceType.Property)]
        public void Team_Test(string list, int c, string expected)
        {
            int[] arr1 = Array.ConvertAll(list.Split(','), temp => Convert.ToInt32(temp));
            int[] exp = Array.ConvertAll(expected.Split(','), temp => Convert.ToInt32(temp));
            var sq = new StringQuiz();
            var result = sq.TeamSize(arr1, c);
            Assert.AreEqual(result.Length, exp.Length);
            for(int i=0; i<result.Length; i++)
            {
                Assert.AreEqual(result[i], exp[i]);
            }
       
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                    new object[] { "##!r#po#", 0},
                    new object[] { "#ab!c#de!f", 1}
                };
            }
        }

        public static IEnumerable<object[]> Data1
        {
            get
            {
                return new[]
                {
                    new object[] { "423692", "923857614", 8}
                };
            }
        }

        public static IEnumerable<object[]> Data2
        {
            get
            {
                return new[]
                {
                    new object[] {  "7,5,3,4,6,1,7,2,4", 7, "8,7,-1,-1,-1,-1,-1,-1,-1"}
                };
            }
        }
    }
}
