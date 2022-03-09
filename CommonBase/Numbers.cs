using System.Text;

namespace CommonBase
{
    public static class Numbers
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        public static bool CheckProjectNumber(string number)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number));

            var result = number.Where((c, i) => i == 9 ? (c == 'X' || c == 'x' || char.IsDigit(c)) : char.IsDigit(c)).Count() == 10;
            var sum = 0;
            var rest = 0;

            for (int i = 0; i < number?.Length - 1 && result; i++)
            {
                sum += (number[i] - '0') * (i + 1);
            }
            rest = sum % 11;

            return result && ((rest == 10 && char.ToUpper(number[^1]) == 'X') || (rest == number[^1] - '0'));
        }

        public static string CreateProjectNumber()
        {
            var result = new StringBuilder();
            var sum = 0;
            var rest = 0;

            for (int i = 0; i < 9; i++)
            {
                var rn = Random.Next(0, 10);

                sum += (rn * (i + 1));
                result.Append(rn);
            }
            rest = sum % 11;

            if (rest == 10)
                result.Append('X');
            else
                result.Append(rest);

            return result.ToString();
        }
    }
}
