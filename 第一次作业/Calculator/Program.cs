using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字：");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入第二个数字：");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入一个运算符（+，-，*，/）：");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();
            int sum;

            switch (op)
            {
                case '+':
                    sum = num1 + num2;
                    break;
                case '-':
                    sum = num1 - num2;
                    break;
                case '*':
                    sum = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        sum = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("除数不能为0");
                        return;
                    }
                    break;
                default:
                    return;
            }
            Console.WriteLine("运算结果为：" + sum);

            Console.ReadKey();
        }
    }
}
