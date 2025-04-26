class Program
{
    public void Fill(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = Convert.ToInt16(Console.ReadLine());
        }
    }


    public void Output(int[] list)
    {
        foreach (int i in list)
        {
            Console.Write(i);
            Console.Write(" ");
        }
        Console.WriteLine();
    }


    public int Min(int[] list)
    {
        int min = list[0];
        foreach (int i in list)
        {
            if (i < min)
            {
                min = i;
            }
        }
        return min;
    }


    public void Change(int[] list)
    {
        for (int i = 1; i < (list.Length - 1); i++)
        {
            list[i] += list[i + 1];
        }
    }


    public void Replace(ref int[] list)
    {
        int[] minus = new int[list.Length];
        int[] zero = new int[list.Length];
        int[] plus = new int[list.Length];
        int[] result = new int[list.Length];

        foreach (int i in list)
        {
            if (i < 0)
            {
                minus.Append(i);
            }
            if (i == 0)
            {
                zero.Append(i);
            }
            if (i > 0)
            {
                plus.Append(i);
            }
        }

        foreach (int i in minus)
        {
            result.Append(i);
        }

        foreach (int i in zero)
        {
            result.Append(i);
        }

        foreach (int i in plus)
        {
            result.Append(i);
        }

        list = result;
    }


    static void Main()
    {
        int [] list;
        int n;
        Program program = new Program();

        Console.WriteLine("Сколько элементов будет в массиве");
        n = Convert.ToInt32(Console.ReadLine());
        list = new int[n];

        Console.WriteLine("Заполните свой список:");
        program.Fill(list);

        Console.WriteLine("Ваш массив:");
        program.Output(list);

        Console.WriteLine($"Минимальный элемент массива - {program.Min(list)}");

        Console.WriteLine("Замена порядка:");
        program.Replace(ref list);
        program.Output(list);

    }
}
