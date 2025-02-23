using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单计算器");
            Console.WriteLine("请输入第一个数字：");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入运算符 (+, -, *, /)：");
            string op = Console.ReadLine();

            Console.WriteLine("请输入第二个数字：");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;
            bool isValidOperation = true;

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("错误：除数不能为零！");
                        isValidOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("错误：无效的运算符！");
                    isValidOperation = false;
                    break;
            }

            if (isValidOperation)
            {
                Console.WriteLine($"结果：{num1} {op} {num2} = {result}");
            }

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
