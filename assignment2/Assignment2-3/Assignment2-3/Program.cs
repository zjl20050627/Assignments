using System;
using System.Collections.Generic;
namespace Assignment2_3
{
    class PrimeFinder
    {
        static void Main(string[] args)
        {
            int max = 100;
            List<int> primes = FindPrimes(max);
            Console.WriteLine("素数列表（2到" + max + "之间的素数）：");
            foreach (int prime in primes)
            {
                Console.Write(prime + " ");
            }
        }
        static  List<int> FindPrimes (int max)
        {
            bool[] isPrime = new bool[max + 1];
            for (int i = 2;i <= max; i++)
            {
                isPrime[i] = true;
            }
            for (int p = 2;p*p<max;p++)
            {
                if (isPrime[p])
                {
                    for(int i = p*p;i<=max;i+=p)
                    {
                        isPrime[i] = false;
                    }
                }
            }
            List<int> primes = new List<int>();
            for(int i = 2;i<=max;i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
