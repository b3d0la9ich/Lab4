using System;

class Program
{
    // Новая функция для 2x + cos(x) = 0
    static double f(double x)
    {
        return 2 * x + Math.Cos(x);
    }

    // Производная новой функции
    static double df(double x)
    {
        return 2 - Math.Sin(x); // Производная функции 2x + cos(x)
    }

    // Функция g(x) для метода простых итераций
    static double g(double x)
    {
        return -Math.Cos(x) / 2; // Решаем уравнение относительно x
    }

    static double NewtonMethod(double x0, double epsilon)
    {
        double x = x0;
        int iteration = 1;
        Console.WriteLine("Newton's Method Iterations:");
        Console.WriteLine("Iteration\t\tx\t\t\tdifference");
        Console.WriteLine("__________________________________________________");

        do
        {
            double f_x = f(x);
            double df_x = df(x);
            x = x - f_x / df_x; // след значение x
            Console.WriteLine($"{iteration}\t\t\t{x}\t\t\t{Math.Abs(-f_x / df_x)}");
            iteration++;
        } while (Math.Abs(f(x)) > epsilon);

        return x;
    }

    static double SimpleIterationMethod(double x0, double epsilon)
    {
        double xn = x0;
        double xn_plus_1;
        int iteration = 0;
        bool isRepeated = false;
        var roots = new System.Collections.Generic.List<double>();

        Console.WriteLine("\nSimple Iteration Method Iterations:");
        Console.WriteLine("Iteration\t\txn\t\txn+1\t\tdifference");
        Console.WriteLine("__________________________________________________");

        do
        {
            xn_plus_1 = g(xn);
            Console.WriteLine($"{iteration}\t\t\t{xn}\t\t\t{xn_plus_1}\t\t\t{Math.Abs(xn_plus_1 - xn)}");

            foreach (double root in roots)
            {
                if (Math.Abs(xn_plus_1 - root) < epsilon)
                {
                    isRepeated = true; // проверка на повтор корня
                    break;
                }
            }
            if (!isRepeated)
            {
                roots.Add(xn_plus_1);
            }
            xn = xn_plus_1;
            iteration++;
        } while (Math.Abs(g(xn) - xn) > epsilon && iteration < 100 && !isRepeated);

        return xn;
    }

    // Метод половинного деления для уточнения корня с заданной точностью
    static double HalfDivisionMethod(double a, double b, double epsilon)
    {
        int iteration = 1;
        double midPoint;

        Console.WriteLine("\nHalf Division Method:");
        Console.WriteLine("N\t\ta\t\tb\t\tb-a");
        Console.WriteLine("_______________________________________");

        if (f(a) * f(b) >= 0)
        {
            Console.WriteLine("Интервал выбран неправильно. В данном сегменте нет корня.");
            return double.NaN;
        }

        while (Math.Abs(b - a) > epsilon)
        {
            midPoint = (a + b) / 2.0;
            Console.WriteLine($"{iteration}\t\t\t{a}\t\t\t{b}\t\t\t{b - a}");

            if (f(midPoint) == 0.0)
            {
                return midPoint; // Найден точный корень
            }
            else if (f(a) * f(midPoint) < 0)
            {
                b = midPoint; // Корень находится в левой половине отрезка
            }
            else
            {
                a = midPoint; // Корень находится в правой половине отрезка
            }

            iteration++;
        }
        return (a + b) / 2.0; // Возвращаем середину последнего интервала как приближенный корень
    }

    static void Main(string[] args)
    {
        double a = -1.0; // Начало интервала (изменено для охвата корня)
        double b = 1.0;  // Конец интервала
        double epsilon = 0.0001; // Точность

        Console.WriteLine("Ищем корень уравнения 2x + cos(x) = 0 с использованием различных методов:");

        double newton = NewtonMethod((a + b) / 2, epsilon);
        Console.WriteLine($"Найденный корень методом Ньютона: x = {newton}");

        double simpleIteration = SimpleIterationMethod((a + b) / 2, epsilon);
        Console.WriteLine($"Найденный корень простым итерационным методом: x = {simpleIteration}");

        double halfDivision = HalfDivisionMethod(a, b, epsilon);
        Console.WriteLine($"Найденный корень методом половинного деления: x = {halfDivision}");
    }
}
