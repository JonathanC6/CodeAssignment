using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2
{
    internal class Program
    {
        //随机生成100个0~1000间的整数，使用LINQ语句对这些整数从大到小排序，并求和与平均数。
        static void Main(string[] args)
        {
            int i;
            double sum = 0;
            int[] arr = new int[1000];
            Random random = new Random();

            for (i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1000) + 1;
            }
            int[] Arr = arr.OrderByDescending(x => x).ToArray();
            for (i = 0; i < Arr.Length; i++)
            {
                Console.WriteLine("{0}", Arr[i]);
                sum += Arr[i];
            }
            Console.WriteLine("求和：{0}", sum);
            Console.WriteLine("平均值：{0}", sum / 1000);
            Console.ReadKey();
        }
    }
}
