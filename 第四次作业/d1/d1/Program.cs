using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1
{
    public class Program
    {
        /*编写一个订单管理的控制台程序，实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能。
        主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），
        订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
        要求：
        （1）使用LINQ实现各种查询功能，查询结果按照订单总金额排序返回。
        （2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
        （3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
        （4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
        （5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。*/
        public static void Main()
        {
            //商品
            Good pen = new Good(1, "pen", 3.99f);
            Good pencil = new Good(2, "pencil", 1.99f);
            Good eraser = new Good(3, "eraser", 5.99f);
            Good ruler = new Good(4, "ruler", 2.99f);

            //顾客
            Customer jack = new Customer(1, "Jack");
            Customer john = new Customer(2, "John");
            Customer joe = new Customer(3, "Joe");

            //订单
            Order order1 = new Order(1, jack);
            order1.AddDetails(new OrderDetails(pen, 10));
            order1.AddDetails(new OrderDetails(eraser, 2));
            order1.AddDetails(new OrderDetails(ruler, 1));

            Order order2 = new Order(2, john);
            order2.AddDetails(new OrderDetails(pencil, 3));
            order2.AddDetails(new OrderDetails(pen, 1));
            order2.AddDetails(new OrderDetails(ruler, 4));

            Order order3 = new Order(3, joe);
            order3.AddDetails(new OrderDetails(ruler, 8));
            order3.AddDetails(new OrderDetails(pencil, 5));
            order3.AddDetails(new OrderDetails(eraser, 2));


            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

            //查询
            Console.WriteLine("--------------------QueryById:1--------------------");
            Console.WriteLine(orderService.QueryById(1));

            Console.WriteLine("\n");
            Console.WriteLine("--------------------GetAllOrders--------------------");
            List<Order> orders = orderService.QueryAll();
            orders.ForEach(o => Console.WriteLine(o));


            Console.WriteLine("\n");
            Console.WriteLine("--------------------GetOrdersByCustomerName:'Joe'--------------------");
            orders = orderService.QueryByCustomerName("Joe");
            orders.ForEach(o => Console.WriteLine(o));


            Console.WriteLine("\n");
            Console.WriteLine("--------------------GetOrdersByGoodsName:'pen'--------------------");
            orders = orderService.QueryByGoodsName("pen");
            orders.ForEach(o => Console.WriteLine(o));


            Console.WriteLine("\n");
            Console.WriteLine("--------------------GetOrdersTotalAmount:54.87--------------------");
            orders = orderService.QueryByTotalPrice(54.87f);
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n");
            Console.WriteLine("--------------------order by Amount--------------------");
            orderService.Sort((o1, o2) => o2.TotalPrice.CompareTo(o1.TotalPrice));
            orderService.QueryAll().ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n");
            Console.WriteLine("--------------------Remove order(id=2) and qurey all--------------------");
            orderService.RemoveOrder(2);
            orderService.QueryAll().ForEach(o => Console.WriteLine(o));

            Console.ReadKey();
        }
    }
}