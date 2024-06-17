﻿using System.Globalization;
using System.Text;

namespace Util
{
    public static class StringUtil
    {
        public static string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }

        public static string PadBoth(this string str, int length, char character = ' ')
        {
            return str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
        }
    }
}
