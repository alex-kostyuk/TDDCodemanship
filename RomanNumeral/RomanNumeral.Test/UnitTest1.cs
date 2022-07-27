using NUnit.Framework;
using System;

namespace RomanNumeral.Test
{
    public class Tests
    {

        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(34, "XXXIV")]
        [TestCase(36, "XXXVI")]
        [TestCase(39, "XXXIX")]
        [TestCase(40, "XL")]
        [TestCase(41, "XLI")]
        [TestCase(46, "XLVI")]
        [TestCase(49, "XLIX")]
        [TestCase(50, "L")]
        [TestCase(65, "LXV")]
        [TestCase(94, "XCIV")]
        [TestCase(100, "C")]
        [TestCase(200, "CC")]
        [TestCase(2967, "MMCMLXVII")]
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