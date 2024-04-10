using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    internal class Program
    {
        static public int getMax(int[] a)
        {
            int temp = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (temp < a[i])
                {
                    temp = a[i];
                }
            }
            return temp;
        }

        static public int getMin(int[] a)
        {
            int temp = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (temp > a[i])
                {
                    temp = a[i];
                }
            }
            return temp;
        }

        static public int getSum(int[] a)
        {
            int sum = 0;
            Array.ForEach(a, i => sum += i);
            return sum;
        }

        static public int getAvg(int[] a)
        {
            int avg = getSum(a) / a.Length;
            return avg;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度：");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入数组数据：");
            int[] arry = new int[length];
            for (int i = 0; i < length; i++)
            {
                arry[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine("max is: "+getMax(arry));
            Console.WriteLine("min is: "+getMin(arry));
            Console.WriteLine("avg is: "+getAvg(arry));
            Console.WriteLine("sum is: "+getSum(arry));

            Console.ReadKey();
        }
    }
}
