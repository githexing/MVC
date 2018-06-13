
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     
    class Program1
    {
        public delegate int Expression(int a, int b);
        
        static void Main1(string[] args)
        {
            //(2)委托扩展
            //Expression ex = GetEX;
            //Calculate(ex, 25, 10);
            Calculate(GetAdd, 25, 10);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static int subtract(int a, int b)
        {
            return a - b;
        }
        static int multiply(int a, int b)
        {
            return a * b;
        }
        static int GetAdd(int a, int b)
        {
            return a + b;
        }
        static void Calculate(Expression ex, int a, int b)
        {
            Console.WriteLine(ex(a, b) + "\n");
        }
    }
}
