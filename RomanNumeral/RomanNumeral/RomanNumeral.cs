namespace RomanNumeral
{
    public class RomanNumeral
    {
        public object FromInt(int v)
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

        private string NewMethod(int v, char start = 'I', char midle = 'V', char end = 'X')
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
