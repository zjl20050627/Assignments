using System;
using System.Collections.Generic;

namespace Assignment2_2
{
    class IntArrayStatistics
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一组整数（用空格分开）：");
            string input = Console.ReadLine();
            if (TryParseArray(input, out int[] numbers))
            {
                (int max, int min, double average, int sum) = CalculateStatistics(numbers);
                DisplayResults(max, min, average, sum);
            }
            else
            {
                Console.WriteLine("输入无效，请确保输入的是整数");
            }

        }
        static bool TryParseArray(string input, out int[] numbers)
        {
            numbers = Array.Empty<int>();
            if (string.IsNullOrWhiteSpace(input))//用来检查字符串是否为空，空白，或只包含空白字符
            {
                return false;
            }
            string[] parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            numbers = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out numbers[i]))
                {
                    numbers = Array.Empty<int>();
                    return false;
                }
            }
            return true;
        }
        static (int max, int min, double average, int sum) CalculateStatistics(int[] numbers)
        {
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            foreach (var number in numbers)
            {
                if (number > max) max = number;
                if (number < min) min = number;
                sum += number;
            }
            double average = sum / (double)numbers.Length;
            return (max, min, average, sum);
        }
        static void DisplayResults(int max, int min, double average, int sum)
        {
            Console.WriteLine($"最大值：{max}");
            Console.WriteLine($"最小值：{min}");
            Console.WriteLine($"平均值：{average}");
            Console.WriteLine($"元素和：{sum}");
        }
    }
}
