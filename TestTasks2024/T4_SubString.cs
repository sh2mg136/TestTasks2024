using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestsProject")]

namespace TestTasks2024
{
    internal class T4_SubString
    {
        private string _str;

        public T4_SubString(string str)
        {
            if (str == null)
                throw new ArgumentNullException();
            _str = str;
        }

        public int Find()
        {
            if (string.IsNullOrWhiteSpace(_str))
                return 0;

            int i = 0;
            int res = 0;
            while (i < _str.Length)
            {
                int k = find_first_occurence(_str.Substring(i));
                if (k < 0) break;
                res++;
                i += k + 1;
            }
            return res;
        }

        private int find_first_occurence(string s)
        {
            if (s.Length < 3) return -1;

            for (int i = 3; i < s.Length - 1; i++)
            {
                if (s[i] != 'A' || s[i + 1] != 'C')
                    continue;
                if (s[i - 3] == 'B')
                    return i;
            }

            return -1;
        }
    }
}