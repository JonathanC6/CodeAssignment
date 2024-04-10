using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3
{
    //形状接口
    abstract class Shape
    {
        public abstract double CalculateArea();
    }

    //圆形类
    class Circle : Shape
    {
        private double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    //正方形类
    class Square : Shape
    {
        private double length { get; }

        public Square(double length)
        {
            length = length;
        }

        public override double CalculateArea()
        {
            return Math.Pow(length, 2);
        }
    }

    //简单工厂类
    class ShapeFactory
    {
        private readonly Random _random = new Random();

        public Shape CreateRandomShape()
        {
            //随机选择形状
            if (_random.NextDouble() < 0.5)
            {
                //创建圆形
                double radius = _random.NextDouble() * 10; //随机半径
                return new Circle(radius);
            }
            else
            {
                //创建正方形
                double length = _random.NextDouble() * 10; // 随机边长
                return new Square(length);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory factory = new ShapeFactory();
            List<Shape> shapes = new List<Shape>();

            //随机创建10个形状对象
            for (int i = 0; i < 10; i++)
            {
                Shape shape = factory.CreateRandomShape();
                shapes.Add(shape);
            }

            //计算面积之和
            double totalArea = 0;
            foreach (var shape in shapes)
            {
                totalArea += shape.CalculateArea();
            }

            Console.WriteLine($"10 个随机形状的总面积为：{totalArea:F2}");

            Console.ReadKey();
        }
    }
}
