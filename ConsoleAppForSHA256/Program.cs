using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForSamWork1;

namespace ConsoleAppForSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            librarySHA ex = new librarySHA();
            string password = Console.ReadLine();
            Console.WriteLine(ex.Sha(password));
        }
    }
}
