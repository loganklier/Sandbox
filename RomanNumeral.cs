using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox
{
    public class RomanNumeral
    {
        static void Test(string[] args)
        {
            var input = 212;

            RomanNumeralIterativeConverter(input);

            var recursive = RomanNumeralRecursiveConverter(input);

            Console.WriteLine("Recursive solution: " + recursive);

            void RomanNumeralIterativeConverter(int x)
            {
                var conversion = string.Empty;

                var n = x / 100;
                conversion += HundredsAtIndex(n);
                x %= 100;

                n = x / 10;
                conversion += TensAtIndex(n);
                x %= 10;

                conversion += OnesAtIndex(x);

                Console.WriteLine("Iterative solution: " + conversion);
            }

            string HundredsAtIndex(int y)
            {
                return RomanNumeralHelpers.HundredToRomanNumeralDictionary[y];
            }

            string TensAtIndex(int y)
            {
                return RomanNumeralHelpers.TenToRomanNumeralDictionary[y];
            }

            string OnesAtIndex(int y)
            {
                return RomanNumeralHelpers.OneToRomanNumeralDictionary[y];
            }


            string RomanNumeralRecursiveConverter(int x)
            {
                //base case
                if (x == 0)
                {
                    return "";
                }

                if (x >= 100)
                {
                    return "C" + RomanNumeralRecursiveConverter(x - 100);
                }

                if (x >= 90)
                {
                    return "XC" + RomanNumeralRecursiveConverter(x - 90);
                }

                if (x >= 50)
                {
                    return "L" + RomanNumeralRecursiveConverter(x - 50);
                }

                if (x >= 40)
                {
                    return "XL" + RomanNumeralRecursiveConverter(x - 40);
                }

                if (x >= 10)
                {
                    return "X" + RomanNumeralRecursiveConverter(x - 10);
                }

                if (x >= 9)
                {
                    return "IX" + RomanNumeralRecursiveConverter(x - 9);
                }

                if (x >= 5)
                {
                    return "V" + RomanNumeralRecursiveConverter(x - 5);
                }

                if (x >= 4)
                {
                    return "IV" + RomanNumeralRecursiveConverter(x - 4);
                }

                if (x >= 1)
                {
                    return "I" + RomanNumeralRecursiveConverter(x - 1);
                }

                return "Something fucked Up";
            }
        }
    }

    public static class RomanNumeralHelpers
    {
        public static readonly Dictionary<int, string> HundredToRomanNumeralDictionary = new Dictionary<int, string>
        {
            {0, ""},
            {1, "C"},
            {2, "CC"},
            {3, "CCC"},
        };

        public static readonly Dictionary<int, string> TenToRomanNumeralDictionary = new Dictionary<int, string>
        {
            {0, ""},
            {1, "X"},
            {2, "XX"},
            {3, "XXX"},
            {4, "XL"},
            {5, "L"},
            {6, "LX"},
            {7, "LXX"},
            {8, "LXXX"},
            {9, "XC"},
        };

        public static readonly Dictionary<int, string> OneToRomanNumeralDictionary = new Dictionary<int, string>
        {
            {0, ""},
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
        };
    }
}