using System;
using System.Collections.Generic;

namespace Assignment2_1
{
    class PrimeFactorCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个正整数：");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                List<int> primeFactors = GetPrimeFactors(number);
                Console.WriteLine($"数字{number}的所有素数因子为：{string.Join(",", primeFactors)}");
            }
            else
            {
                Console.WriteLine("输入无效，请输入一个正整数！");
            }

        }
        static List<int> GetPrimeFactors(int number)
        {
            List<int> factors = new List<int>();
            int divisor = 2;//初始除数为2
            while (number > 1)
            {
                while (number % divisor == 0)
                {
                    factors.Add(divisor);
                    number /= divisor;
                }
                divisor++;
            }
            return factors;
        }
    }
}
