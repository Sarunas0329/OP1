// Sarunas Butnevicius IFF-2/2
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kontrolinis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Tekstas.txt";
            const string CFr = "RedTekstas.txt";
            TaskUtils.PerformTask(CFd, CFr);
        }
    }
}
