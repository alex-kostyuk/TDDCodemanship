using NUnit.Framework;
using System;

namespace RomanNumeral.Test
{
    public class Tests
    {

        [Test]
        [TestCase(4, "IV")]
        [TestCase(6, "VI")]
        [TestCase(9, "IX")]
        [TestCase(11, "XI")]
        [TestCase(40, "XL")]
        [TestCase(60, "LX")]
        [TestCase(90, "XC")]
        [TestCase(110, "CX")]
        [TestCase(400, "CD")]
        [TestCase(600, "DC")]
        [TestCase(900, "CM")]
        [TestCase(1100, "MC")]
        public void Convert(int input, string expected)
        {
            var romanNumeral = new RomanNumeral();
            var result = romanNumeral.FromInt(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class RomanNumeral
    {
        internal object FromInt(int v)
        {
            var result = string.Empty;

            var m = v / 1000;
            result += NewMethod(m, 'M', '-', '+');

            v = v % 1000;
            var c = v / 100;
            result += NewMethod(c, 'C', 'D', 'M');

            v = v % 100;
            var x = v / 10;
            result += NewMethod(x, 'X', 'L', 'C');

            v = v % 10;
            result += NewMethod(v);
            return result;
        }


        private static string NewMethod(int v, char start = 'I', char midle = 'V', char end = 'X')
        {
            var result = string.Empty;
            if (v > 8)
            {
                if (v == 9)
                {
                    result += start;
                }

                result += end;

                v -= 10;
            }
            if (v > 0)
            {
                if (v == 4)
                {
                    result += start;
                }

                if (v > 3)
                {
                    result += midle;
                }
                if (v >= 5)
                {
                    v -= 5;
                }
                if (v < 4)
                {
                    result = result + string.Empty.PadRight(v, start);
                }
            }
            return result;
        }
    }
}