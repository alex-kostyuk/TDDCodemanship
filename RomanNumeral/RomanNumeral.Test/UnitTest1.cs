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
}