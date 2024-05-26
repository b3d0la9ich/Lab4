using System;
using System.Collections.Generic;

class Program
{
    static Random random_ = new Random();

    static void RandomFill(List<int> fillList, int N, int gr1, int gr2)
    {
        for (int i = 0; i < N; i++)
        {
            fillList.Add(random_.Next(gr2, gr1 + gr2));
        }
    }

    static void NewMass(List<int> rand1, List<int> rand2, List<int> New)
    {
        for (int i = 0; i < rand1.Count; i++)
        {
            if (i % 2 == 0)
            {
                New.Add(rand1[i] + rand2[i]);
            }
            else
            {
                New.Add(rand1[i] - rand2[i]);
            }
        }
    }

    static void Main(string[] args)
    {
        // 1-2
        int N = 10;
        List<int> randNum = new List<int>();
        RandomFill(randNum, N, 101, 100);
        randNum.Sort();
        Console.Write("Массив с случайными значениями: ");
        foreach (int n in randNum)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Второй по величине элемент: " + randNum[N - 2]);

        randNum.RemoveAt(N - 1);
        randNum.RemoveAt(N - 2);
        randNum.RemoveAt(0);

        int sum = 0;
        foreach (int i in randNum)
        {
            sum += i;
        }
        Console.WriteLine("Сумма: " + sum);

        randNum.Clear();
        // 3
        List<int> randNum1 = new List<int>();
        List<int> New = new List<int>();

        RandomFill(randNum, N, 101, -50);
        RandomFill(randNum1, N, 101, -50);

        NewMass(randNum, randNum1, New);

        Console.Write("Первый массив с случайными значениями: ");
        foreach (int n in randNum)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.Write("Второй массив с случайными значениями: ");
        foreach (int n in randNum1)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.Write("Новый массив: ");
        foreach (int n in New)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        Dictionary<int, int> povtor = new Dictionary<int, int>();
        foreach (int n in New)
        {
            if (povtor.ContainsKey(n))
            {
                povtor[n]++;
            }
            else
            {
                povtor.Add(n, 1);
            }
        }
        foreach (KeyValuePair<int, int> n in povtor)
        {
            Console.WriteLine("Элемент: " + n.Key + " Количество повторов: " + n.Value);
        }

        Console.Write("Введите начальный и конечный год: ");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        List<int> visokYears = new List<int>();
        for (int i = a; i <= b; i++)
        {
            if (i % 4 == 0)
            {
                visokYears.Add(i);
            }
        }
        Console.Write("Високосные годы: ");
        foreach (int n in visokYears)
        {
            Console.Write(n + " ");
        }
    }
}
