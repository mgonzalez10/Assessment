using System;

namespace Question1
{
    public class StringEncoding
    {
        private readonly char[] transcode;

        public StringEncoding()
        {
            // Increased by 1
            transcode = new char[65];
        }

        /// <summary>
        /// Prepare array with chars [A-Z][a-z][0-9][+/=]
        /// </summary>
        public void Prepare()
        {
            for (int i = 0; i < 62; i++)
            {
                transcode[i] = (char)((int)'A' + i);
                if (i > 25) transcode[i] = (char)((int)transcode[i] + 6);
                if (i > 51) transcode[i] = (char)((int)transcode[i] - 0x4b);
            }
            transcode[62] = '+';
            transcode[63] = '/';
            transcode[64] = '=';
        }

        public string ProcessString(string input)
        {
            var encoded = this.Encode(input);
            return this.Decode(encoded);
        }

        private string Encode(string input)
        {
            int inputLenght = input.Length;
            int cb = (inputLenght / 3 + (Convert.ToBoolean(inputLenght % 3) ? 1 : 0)) * 4;

            // Output array initilized with '='
            char[] output =  new char[cb];
            Array.Fill(output, '=');

            int c = 0;
            int reflex = 0;

            // 64 instead of 63 => 0x3f;
            const int s = 0x40; 

            for (int j = 0; j < inputLenght; j++)
            {
                // Shift left 8 bits
                reflex <<= 8;

                // Logic AND with mask
                reflex &= 0x00ffff00;

                // Add current char form input array
                reflex += input[j];

                // Get remainder from current index divided by 3. Apply +1 and multiplication by 3
                int x = ((j % 3) + 1) * 2;

                // Shift left x on the const
                int mask = s << x;

                while (mask >= s)
                {
                    int pivot = (reflex & mask) >> x;
                    output[c++] = transcode[pivot];
                    int invert = ~mask;
                    reflex &= invert;
                    mask >>= 6;
                    x -= 6;
                }
            }

            switch (inputLenght % 3)
            {
                case 1:
                    reflex <<= 4;
                    output[c++] = transcode[reflex];
                    break;

                case 2:
                    reflex <<= 2;
                    output[c++] = transcode[reflex];
                    break;

            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }


        private string Decode(string input)
        {
            int l = input.Length;
            int cb = (l / 4 + ((Convert.ToBoolean(l % 4)) ? 1 : 0)) * 3 + 1;
            char[] output = new char[cb];
            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                    reflex += Array.IndexOf(transcode, input[j]);

                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));
                    int invert = ~mask;
                    reflex &= invert;
                    bits -= 8;
                }

                if (fTerminate)
                    break;
            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }

        //private int indexOf(char ch)
        //{
        //    int index;
        //    for (index = 0; index < transcode.Length; index++)
        //        if (ch == transcode[index])
        //            break;
        //    return index;
        //}
    }
}
