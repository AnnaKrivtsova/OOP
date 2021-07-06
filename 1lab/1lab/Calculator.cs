using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1lab
{
    interface ICalculator
    {
        string And(int a, int b);
        string Or(int a, int b);
        string Xor(int a, int b);
        string Not(int a);
        string Binary(int a);
        string Octal(int a);
        string Decimal(int a);
        string Hexadecimal(int a);
    }
    public class Calculator : ICalculator
    {
        public delegate void MyHandler(string message);
        public event MyHandler _del;
        public void RegisterHandler(MyHandler del)
        {
            _del = del;
        }
        public void MyMessage()
        {
            if (_del != null)
                _del($"Operation And");
        }
        public string And(int a,int b)
        {
            return Convert.ToString(a & b);
        }
        public string Or(int a, int b)
        {        
            return Convert.ToString(a | b);
        }
        public string Xor(int a, int b)
        {
            return Convert.ToString(a ^ b);
        }
        public string Not(int a)
        {
            return Convert.ToString(~a);
        }
        public string Binary(int a)
        {
            return Convert.ToString(a, 2);
        }
        public string Octal(int a)
        {
            return Convert.ToString(a, 8);
        }
        public string Decimal(int a)
        {
            return Convert.ToString(a, 10);
        }
        public string Hexadecimal(int a)
        {
            return Convert.ToString(a, 16);
        }
    }
}
