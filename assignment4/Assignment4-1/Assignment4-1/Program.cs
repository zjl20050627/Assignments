using System;
using System.Collections.Generic;

namespace Assignment4_1
{
    //定义结点类
    public class Node<T>
    { 
        public T Data { get; set;}
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            Data = data;
            Next = null;//引用类型默认初始化为null
        }
    }
    //定义泛型链表类
    public class GenericLinkedList<T>
    {
        private Node<T> head;
        public GenericLinkedList()
        {
            head = null;
        }
        //添加元素
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if(head==null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }//先找到最后一个结点
                current.Next = newNode;
            }
        }
        public void Foreach(Action<T> action)
        {
            Node<T> current = head;
            while(current!=null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
        //打印所有元素
        public void PrintAllElements()
        {
            this.Foreach(data => Console.WriteLine(data));
        }
        //计算元素之和
        public T Sum(Func<T,T,T> sumFunc)
        {
            T sum = default(T);//初始化为T类型的默认值
            this.Foreach(data => sum = sumFunc(sum, data));
            return sum;
        }
        //寻找最大的元素
        public T Max(Func<T,T,T> maxFunc)
        {
            T maxValue = default(T);
            bool isFirst = true;
            this.Foreach(data =>
            {
                if (isFirst || maxFunc(maxValue, data).Equals(data))
                {
                    maxValue = data;
                    isFirst = false;
                }
            });
            return maxValue;
        }
        //寻找最小的元素
        public T Min(Func<T,T,T> minFunc)
        {
            T minValue = default(T);
            bool isFirst = true;
            this.Foreach(data =>
            {
                if (isFirst || minFunc(minValue, data).Equals(data))
                {
                    minValue = data;
                    isFirst = false;
                }
            });
            return minValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //test1
            Console.WriteLine("test1:");
            GenericLinkedList<int> list1 = new GenericLinkedList<int>();
            list1.Add(3);
            list1.Add(5);
            list1.Add(2);
            list1.Add(7);
            list1.Add(6);
            Console.WriteLine("Print all elements:");
            list1.PrintAllElements();
            Func<int, int, int> sumFunc = (a, b) => a + b;
            Console.WriteLine($"Sum:{list1.Sum(sumFunc)}");
            Func<int, int, int> maxFunc = (a, b) => a > b ? a : b;
            Console.WriteLine($"Max:{list1.Max(maxFunc)}");
            Func<int, int, int> minFunc = (a, b) => a < b ? a : b;
            Console.WriteLine($"Min:{list1.Min(minFunc)}");
            //test2
            Console.WriteLine("test2:");
            GenericLinkedList<double> list2 = new GenericLinkedList<double>();
            list2.Add(3.6);
            list2.Add(5.7);
            list2.Add(2.3);
            list2.Add(7.6);
            list2.Add(6.9);
            Console.WriteLine("Print all elements:");
            list2.PrintAllElements();
            Func<double, double, double> sumFunc2 = (a, b) => a + b;
            Console.WriteLine($"Sum:{list2.Sum(sumFunc2)}");
            Func<double, double, double> maxFunc2 = (a, b) => a > b ? a : b;
            Console.WriteLine($"Max:{list2.Max(maxFunc2)}");
            Func<double, double, double> minFunc2 = (a, b) => a < b ? a : b;
            Console.WriteLine($"Min:{list2.Min(minFunc2)}");
        }
    }
}
