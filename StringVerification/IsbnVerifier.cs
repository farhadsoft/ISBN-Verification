using System;
using System.Collections.Generic;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Source string cannot be null or empty or whitespace.");
            }

            bool result = default;
            if (number.Length >= 10 && number.Length <= 13)
            {
                List<int> list = StringToList(number);
                if (list != null && list.Count == 10)
                {
                    int sum = 0;
                    int x = 10;
                    for (int i = 0; i < list.Count; i++)
                    {
                        sum += list[i] * x--;
                    }

                    if (sum % 11 == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static List<int> StringToList(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            List<int> list = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i].ToString(), out var number))
                {
                    list.Add(number);
                }
                else if ((i == 1 || i == 5 || i == 11) && str[i] == '-')
                {
                    continue;
                }
                else if (i == str.Length - 1 && str[i] == 'X')
                {
                    list.Add(10);
                }
                else
                {
                    return null;
                }
            }

            return list;
        }
    }
}
