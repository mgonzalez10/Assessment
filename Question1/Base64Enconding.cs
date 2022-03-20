using System;
using System.Text;

namespace Question1
{
    public static class Base64Enconding
    {
        public static string Encode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static string Decode(string input)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(input));
        }
    }
}
