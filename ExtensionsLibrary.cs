
namespace ExtensionsLibrary
{
    public static class Extensions
    {     
        public static bool IsFibonacci(this int number)
        {
            if (Math.Sqrt(5 * (Math.Pow(number, 2)) - 4) % 1 == 0 || Math.Sqrt(5 * (Math.Pow(number, 2)) + 4) % 1 == 0)
                return true;
            else return false;
        }
        public static int WordsQuantity(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            str = System.Text.RegularExpressions.Regex.Replace(str.Trim(), @"\s+", " ");
            return str.Split(' ').Length;
        }
        public static int LastWordLength(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            return str.Split(' ').Last().Length;
        }
        public static int MultipleOfSeven(this int[] arr)
        {
            return arr.Count(n => n % 7 == 0);
        }
        public static int PositiveInArr(this int[] arr)
        {
            return arr.Count(n => n > 0);
        }
        public static int NegativeInArr(this int[] arr)
        {
            return arr.Count(n => n < 0);
        }
        public static bool FindWord(this string[] text, string word)
        {
            if (text.Where(x => x.StartsWith(word)).FirstOrDefault() == word) return true;
            else return false;
        }
        public static string FirstPositiveLastNegative(this int[] sequency)
        {
            var posNums = from item in sequency where item > 0 select item;
            var negNums = from item in sequency where item < 0 select item;
            return $"{posNums.First()}, {negNums.Last()}";
        }
        public static int FirstPositiveInSequency(this int[] sequency, UInt32 number)
        {
            return sequency.FirstOrDefault(item => (item > 0) && (item % 10 == number));
        }
        public static string LastRowOfSequency(this string[] sequency, UInt32 number)
        {
            IEnumerable<string> fitNumberWords = from i in sequency
                                                 let words = i.Split(' ', ';', ',')
                                                 from w in words
                                                 where w.Count() == number
                                                 select w;
            string digitWords = null;
            if (fitNumberWords != null)
            {
                foreach (string word in fitNumberWords)
                {
                    if (char.IsDigit(word[0]) == true)
                    {
                        int len = word.Length;
                        digitWords = $"{word[len - 5]}{word[len - 4]}{word[len - 3]}{word[len - 2]}{word[len - 1]}";
                    }
                }
                return digitWords;
            }
            else throw new Exception("Not found.");
        }
        public static IEnumerable<int> PositiveSequency(this int[] sequency)
        {
            var lastDigits = from number in sequency where number > 0 select number % 10;
            return lastDigits.Distinct();
        }
        public static bool IsPalindrom(this int number)
        {
            var str = number.ToString();
            var str2 = new string(number.ToString().Reverse().ToArray());
            return str == str2;
        }
    }
}
