using System;

class Program
{
    const double p = 0.5; /* Вероятност A да спечели отделен мач */
    const int n = 5;
    
    static double?[,] PS = new double?[n+1, n+1];
    
    static void Main()
    {
        PDynamic(n, n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write("{0:F6} ", PS[i, j] ?? 0.0);
            Console.WriteLine();
        }
    }
        
    static double PDynamic(int i, int j)
    {
        for (int k = 1; k <= i; k++)
        {
            PS[0, k] = 1;
        }
        for (int k = 1; k <= j; k++)
        {
            PS[k, 0] = 0;
        }
        return PDyn(i, j);
    }
    
    static double PDyn(int i, int j)    /* Динамично оптимиране */
    {
        if (!PS[i, j].HasValue)
        {
            PS[i, j] = p * PDyn(i - 1, j) + (1 - p) * PDyn(i, j - 1);
        }
        return PS[i, j].Value;
    }
}
