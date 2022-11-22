using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace K1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStore register = InOutUtils.InputBooks("Knyga.txt");
            List<Book> soldBooks = InOutUtils.InputSoldBooks("Parduota.txt");

            File.Delete("Duomenys.txt");
            
            InOutUtils.Print(register, "Duomenys.txt", "Pradine knygyno lentele");
            InOutUtils.Print(soldBooks, "Duomenys.txt", "Pradine knygu pardavimo lentele");

            register.AddSalePrice(soldBooks);
            InOutUtils.Print(soldBooks, "Duomenys.txt", "Papildyta knygu pardavimo lentele");
            InOutUtils.Print(register, "Duomenys.txt", "Pradine knygyno lentele");
        }
    }
}
