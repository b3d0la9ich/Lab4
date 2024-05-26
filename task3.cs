using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random random_ = new Random();

    static void RandomFill(List<int> fillList)
    {
        for (int i = 0; i < fillList.Count; i++)
        {
            fillList[i] = random_.Next(1, 101);
        }
    }

    static int CountEl(List<int> list, int element)
    {
        return list.Count(n => n == element);
    }

    static double RealExp(List<int> list)
    {
        return list.Average();
    }

    static double ExpectedExp(List<int> list)
    {
        return list.Sum() / 125.0;
    }

    static double Dispersion(List<int> list)
    {
        double mathReal = RealExp(list);
        double sum = list.Sum(value => Math.Pow(value - mathReal, 2));
        return sum / (list.Count - 1);
    }

    static double Laplas(double i)
    {
        return 0.5 * (1.0 + Math.Erf(i / Math.Sqrt(2.0)));
    }

    static double ChiKv(List<int> list)
    {
        double result = 0.0;
        double mathReal = RealExp(list);
        double dispersion = Math.Sqrt(Dispersion(list));

        for (int i = 1; i <= 125; i++)
        {
            double realIncidence = CountEl(list, i);
            double expIncidence = list.Count * (Laplas((i - mathReal) / dispersion) - Laplas((i - 1 - mathReal) / dispersion));
            result += Math.Pow(realIncidence - expIncidence, 2) / expIncidence;
        }
        return result;
    }

    static void Main(string[] args)
    {
        List<int> vector50 = Enumerable.Repeat(0, 50).ToList();
        List<int> vector100 = Enumerable.Repeat(0, 100).ToList();
        List<int> vector1000 = Enumerable.Repeat(0, 1000).ToList();

        RandomFill(vector50);
        RandomFill(vector100);
        RandomFill(vector1000);

        double crit = 156.69; // Для 125 ст. своб. и ур. знач 0,05

        // 50 значений
        double chiKvZnach = ChiKv(vector50);
        double mathReal = RealExp(vector50);
        double mathExp = ExpectedExp(vector50);

        Console.WriteLine("Значение Хи-квадрата: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки верна.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки неверна.");
        }
        Console.WriteLine("Ожидаемое математическое ожидание: " + mathExp);
        Console.WriteLine("Реальное математическое ожидание: " + mathReal);
        Console.WriteLine();

        // 100 значений
        chiKvZnach = ChiKv(vector100);
        mathReal = RealExp(vector100);
        mathExp = ExpectedExp(vector100);

        Console.WriteLine("Значение Хи-квадрата: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки верна.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки неверна.");
        }
        Console.WriteLine("Ожидаемое математическое ожидание: " + mathExp);
        Console.WriteLine("Реальное математическое ожидание: " + mathReal);
        Console.WriteLine();

        // 1000 значений
        chiKvZnach = ChiKv(vector1000);
        mathReal = RealExp(vector1000);
        mathExp = ExpectedExp(vector1000);

        Console.WriteLine("Значение Хи-квадрата: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки верна.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении выборки неверна.");
        }
        Console.WriteLine("Ожидаемое математическое ожидание: " + mathExp);
        Console.WriteLine("Реальное математическое ожидание: " + mathReal);
        Console.WriteLine();
    }
}
