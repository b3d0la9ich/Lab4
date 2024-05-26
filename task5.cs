using System;
using System.Collections.Generic;

class Program
{
    static void XorShift(ref uint value, List<uint> PsevdRand)
    {
        value ^= (value << 3);
        value ^= (value >> 5);
        value ^= (value << 2);
        PsevdRand.Add(value);
    }

    static void Main(string[] args)
    {
        List<uint> PsevdRand = new List<uint>();
        uint value = 123456789;
        for (int i = 0; i < 10; i++)
        {
            XorShift(ref value, PsevdRand);
        }
        foreach (uint n in PsevdRand)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}
