using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2A_projekt_WPF
{
    internal class HiddenCode
    {
        //0 - red, 1 - green, 2 - blue, 3 - yellow, 4 - gray, 5 - Pink, 6 - aqua
        private static int[] _hiddenCode = {-1, -1, -1, -1 };
        public static Random rnd = new Random();

        public HiddenCode()
        {
            for (int i = 0; i < _hiddenCode.Length; i++)
            {
                int number = rnd.Next(0, 7);
                if (_hiddenCode.Contains(number))
                {
                    i--;
                }
                else
                {
                    _hiddenCode[i] = number;

                }
            }
        }

        
        public static int[] GetHiddenCode()
        {
            return _hiddenCode;
        }
    }
}
