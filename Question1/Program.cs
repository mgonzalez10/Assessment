using System;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stringEncoding = new StringEncoding();
            //stringEncoding.Prepare();

            string testString = "This is a test string";
            //string encodedString = stringEncoding.ProcessString(testString);

            var encodedString = Base64Enconding.Decode(Base64Enconding.Encode(testString));

            if (String.Compare(testString, encodedString) == 0)
            {
                Console.WriteLine("Test succeeded");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
    }
}