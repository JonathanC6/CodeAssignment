using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class Program
    {
        static void PrintPrimeFactors(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    Console.WriteLine(i);
                    n /= i;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("请输入一个正整数：");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                Console.WriteLine($"数字{number}的素数因子为：");
                PrintPrimeFactors(number);
            }
            else
            {
                Console.WriteLine("输入无效，请输入一个正整数");
            }
            Console.ReadKey();
        }
    }
}
