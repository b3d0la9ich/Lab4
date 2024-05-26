using System;
using System.Collections.Generic;

class Program
{
    static Random random_ = new Random();

    // Функция для генерации случайного числа в диапазоне от min до max
    static int RandomNumber(int min, int max)
    {
        return random_.Next(min, max + 1);
    }

    // Алгоритм "всегда сотрудничать"
    static bool AlwaysCooperate(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices)
    {
        return true;
    }

    // Стратегия уступки: сотрудничать, если противник сотрудничал в предыдущем раунде, иначе предавать
    static bool TitForTat(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices)
    {
        if (roundNumber == 0)
        {
            return true;
        }
        return enemyChoices[roundNumber - 1];
    }

    // Алгоритм со случайными выборами
    static bool RandomChoice(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices)
    {
        return random_.Next(2) == 1;
    }

    static void PrintResults(ref int algorithm1Score, ref int algorithm2Score, ref int algorithm3Score)
    {
        Console.WriteLine("randomChoice: " + algorithm1Score);
        Console.WriteLine("adaptiveRandomChoice: " + algorithm2Score);
        Console.WriteLine("alwaysCooperate: " + algorithm3Score);
    }

    // Функция для сравнения алгоритмов
    static void CompareAlgorithms()
    {
        int numRounds = RandomNumber(100, 200);
        List<bool> algorithm1Choices = new List<bool>();
        List<bool> algorithm2Choices = new List<bool>();
        List<bool> algorithm3Choices = new List<bool>();
        int algorithm1Score = 0, algorithm2Score = 0, algorithm3Score = 0;

        for (int round = 0; round < numRounds; round++)
        {
            bool algorithm1Choice = RandomChoice(round, algorithm1Choices, algorithm2Choices);
            bool algorithm2Choice = TitForTat(round, algorithm2Choices, algorithm1Choices);
            bool algorithm3Choice = AlwaysCooperate(round, algorithm3Choices, algorithm2Choices);

            algorithm1Choices.Add(algorithm1Choice);
            algorithm2Choices.Add(algorithm2Choice);
            algorithm3Choices.Add(algorithm3Choice);

            // Сравниваем все три алгоритма
            if (algorithm1Choice && algorithm2Choice)
            {
                algorithm1Score += 24;
                algorithm2Score += 24;
            }
            else if (algorithm1Choice && !algorithm2Choice)
            {
                algorithm1Score += 0;
                algorithm2Score += 20;
            }
            else if (!algorithm1Choice && algorithm2Choice)
            {
                algorithm1Score += 20;
                algorithm2Score += 0;
            }
            else
            {
                algorithm1Score += 4;
                algorithm2Score += 4;
            }

            if (algorithm1Choice && algorithm3Choice)
            {
                algorithm1Score += 24;
                algorithm3Score += 24;
            }
            else if (algorithm1Choice && !algorithm3Choice)
            {
                algorithm1Score += 0;
                algorithm3Score += 20;
            }
            else if (!algorithm1Choice && algorithm3Choice)
            {
                algorithm1Score += 20;
                algorithm3Score += 0;
            }
            else
            {
                algorithm1Score += 4;
                algorithm3Score += 4;
            }

            if (algorithm3Choice && algorithm2Choice)
            {
                algorithm3Score += 24;
                algorithm2Score += 24;
            }
            else if (algorithm3Choice && !algorithm2Choice)
            {
                algorithm3Score += 0;
                algorithm2Score += 20;
            }
            else if (!algorithm3Choice && algorithm2Choice)
            {
                algorithm3Score += 20;
                algorithm2Score += 0;
            }
            else
            {
                algorithm3Score += 4;
                algorithm2Score += 4;
            }
        }

        PrintResults(ref algorithm1Score, ref algorithm2Score, ref algorithm3Score);
    }

    static void Main(string[] args)
    {
        CompareAlgorithms();
    }
}
