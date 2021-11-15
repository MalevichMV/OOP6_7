using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_7
{
    class Program
    {
        public static double genMtr(uint i, uint j)
        {
            return i + j;
        }
        public static double genVec(uint t)
        {
            return t + t;
        }
        static void Main(string[] args)
        {
            Matrix A = new Matrix();
            Matrix B = new Matrix();
            Console.WriteLine(A.ToString());
            Console.WriteLine(B.ToString());
            B += A;
            Console.WriteLine(B.ToString());
            Console.ReadLine();
        }
    }
}
