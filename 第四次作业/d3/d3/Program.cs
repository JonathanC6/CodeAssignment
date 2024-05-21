using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private int age;

    //有一个带参数的构造函数的Person类
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    //Person类的属性
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}

namespace d3
{
    internal class Program
    {
        //使用反射技术，调用Person类的构造方法创建实例对象。
        static void Main(string[] args)
        {
            //获取Person类型的Type对象
            Type personType = typeof(Person);

            //创建构造函数的参数
            object[] parameters = new object[] { "Alice", 20 };

            //使用Activator.CreateInstance调用构造函数
            object personInstance = Activator.CreateInstance(personType, parameters);

            //personInstance是Person类的一个实例，使用它来访问Person类的成员
            Person person = (Person)personInstance;
            Console.WriteLine("Person Name: " + person.Name + ", Age: " + person.Age);
            Console.ReadKey();
        }
    }
}
