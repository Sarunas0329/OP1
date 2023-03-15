using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "Knyga1.txt";
            const string CFd2 = "Knyga2.txt";
            const string CFr = "Rodikliai.txt";
            const string CFm = "ManoKnyga.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', '.', ':', ';', '(', ')', '\t', '\r', '\n', '\'', '"' };

            TaskUtils.Process(CFd1, CFd2, CFr, CFm);
        }
    }
}
