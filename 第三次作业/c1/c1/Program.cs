using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get=> head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(head == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();

            //整形List
            GenericList<int> intList = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(rd.Next() % 100);
            }
            for (Node<int> node = intList.Head; node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }

            ////字符串List
            //GenericList<string> strList = new GenericList<string>();
            //for(int x=0; x < 10; x++)
            //{
            //    strList.Add("str" + x);
            //}
            //for(Node<string> node=strList.Head;node != null; node = node.Next)
            //{
            //    Console.WriteLine(node.Data);
            //}

            //最大值
            int max = int.MinValue;
            intList.ForEach(item => { if (item > max) max = item; });
            Console.WriteLine($"Max value: {max}");

            //最小值
            int min = int.MaxValue;
            intList.ForEach(item => { if (item < min) min = item; });
            Console.WriteLine($"Min value: {min}");

            //求和
            int sum = 0;
            intList.ForEach(item => sum += item);
            Console.WriteLine($"Sum: {sum}");

            Console.ReadKey();
        }
    }
}