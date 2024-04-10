using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2
{
    abstract class Shape
    {
        public abstract double Area();
        public abstract void Init();
    }
    
    //长方形
    class Rectangle : Shape
    {
        double length;
        double width;
        public Rectangle()
        {
            Init();
        }
        public override double Area()
        {
            return length * width;
        }
        public override void Init()
        {
            Console.WriteLine("请输入长方形的长：");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入长方形的宽：");
            width = Convert.ToDouble(Console.ReadLine());
            if (length < width)
            {
                Console.WriteLine("数据错误");
            }
            else
            {
                Console.WriteLine("长方形的面积为：" + Area());
            }
        }
    }

    //正方形
    class Square : Shape
    {
        double length;
        public Square()
        {
            Init();
        }
        public override double Area()
        {
            return length * length;
        }
        public override void Init()
        {
            Console.WriteLine("请输入正方形的边长：");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("正方形的面积为：" + Area());
        }
    }

    //三角形
    class Triangle : Shape
    {
        double a, b, c;
        public Triangle()
        {
            Init();
        }
        public override double Area()
        {
            double p = (a + b + c) / 2;
            double m = p * (p - a) * (p - b) * (p - c);
            return Math.Sqrt(m);
        }
        public override void Init()
        {
            Console.WriteLine("请分别输入三角形的三条边长：");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            if (a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine("三角形的面积为：" + Area());
            }
            else
            {
                Console.WriteLine("数据错误");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请选择您要计算的形状：");
            Console.WriteLine("1.长方形 2.正方形 3.三角形");
            int name = Convert.ToInt32(Console.ReadLine());
            switch (name)
            {
                case 1:
                    new Rectangle();
                    break;
                case 2:
                    new Square();
                    break;
                case 3:
                    new Triangle();
                    break;
                default:
                    Console.WriteLine("找不到对应形状");
                    break;
            }
            Console.ReadKey();
        }
    }
}
