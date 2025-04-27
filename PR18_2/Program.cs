class Program
{
    public void Create(ref int[,] list)
    {
        int lines, rows;
        Console.WriteLine("Введите количетво строк:");
        lines = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количесто столбцов:");
        rows = Convert.ToInt32(Console.ReadLine());
        int[,] result = new int[lines,rows];

        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.WriteLine($"Строока {i + 1}");
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        list = result;
    }


    public void OutputBinnary(int[,] list)
    {
        for (int i = 0; i < list.GetLength(0); i++)
        {
            for (int j = 0; j < list.GetLength(1); j++)
            {
                Console.Write($"{list[i, j]} ");
            }
            Console.WriteLine();
        }
    }


    public void OutputDefault(int[] list)
    {
        foreach (int i in list)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }


    public bool HasSquare(int[,] list)
    {
        if (list.GetLength(0) == list.GetLength(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Change(int[,] list)
    {
        int sum = 0;
        if (HasSquare(list) == true)
        {
            for (int i = 0; i < list.GetLength(1); i++)
            {
                for (int j = i + 1; j < list.GetLength(0); j++)
                {
                    sum += list[j, i];
                }
            }
            Console.WriteLine($"Сумма элеметнов под побочной диагональю равна {sum}");
        }
        else
        {
            int[] result = new int[list.GetLength(0)];
            for (int i = 0; i < list.GetLength(0); i++)
            {
                int min = list[i, 0];
                int max = list[i, 0];
                for (int j = 0; j < list.GetLength(1); j++)
                {
                    if (list[i, j] < min && list[i, j] % 3 == 0)
                    {
                        min = list[i, j];
                    }
                    if (list[i, j] > max && list[i, j] % 3 == 0)
                    {
                        max = list[i, j];
                    }
                }
                result[i] = max - min;
            }
            Console.WriteLine("вот новый сформированный массив");
            OutputDefault(result);
        }
        
    }
    static void Main()
    {
        Program program = new Program();
        int[,] list = new int[1, 1];
        program.Create(ref list);
        Console.WriteLine("Ваш массив:");
        program.OutputBinnary(list);

        program.Change(list);
    }
}