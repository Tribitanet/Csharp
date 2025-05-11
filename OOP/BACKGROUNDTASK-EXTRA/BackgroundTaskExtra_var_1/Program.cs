class Weather 
{
    private int[] temperature;
    private int date;
    private int month;


    //средний макс и средний мин
    private static int[] minTemp = new int[] {-24, -21, -13, -4, 0, 5, 10, 6, 0, -4, -13, -19};
    private static int[] maxTemp = new int[] {2, 3, 11, 21, 27, 29, 31, 29, 24, 17, 8, 4};


    //свойства
    private int LastDay
    {
        get
        {
            if (this.month == 1 || this.month == 3 || this.month == 5 || this.month == 7 || this.month == 8 || this.month == 10 || this.month == 12)
            {
                return 31;
            }
            if (this.month == 4 || this.month == 6 || this.month == 9 || this.month == 11)
            {
                return 30;
            }
            if (this.month == 2)
            {
                return 28;
            }
            return -1;
        }
    }


    private int AverageTemp
    {
        get
        {
            int summ = 0;
            foreach (int i in this.temperature)
            {
                summ += i;
            }
            return summ / this.temperature.Length;
        }
    }


    public int Days
    {
        get
        {
            return this.LastDay - this.date + 1;
        }
    }


    public int Month
    {
        get
        {
            return this.month;
        }
    }


    public int Hottest
    {
        get
        {  
            int hottest = this.temperature[0];
            int hotIndex = 0;
            for (int i = 0; i < this.temperature.Length; i++)
            {
                if (this.temperature[i] > hottest)
                {
                    hottest = this.temperature[i];
                    hotIndex = i;
                }
            }
            return hotIndex + this.date;
        }
    }


    public int Coldest
    {
        get
        {   
            int coldest = this.temperature[0];
            int coldIndex = 0;
            for (int i = 0; i < this.temperature.Length; i++)
            {
                if (this.temperature[i] < coldest)
                {
                    coldest = this.temperature[i];
                    coldIndex = i;
                }
            }
            return coldIndex + this.date;
        }
    }


    public int Transitions
    {
        get
        {   
            int amountTransitions = 0;
            for (int i = 0; i < this.temperature.Length - 1; i++)
            {
                if (((this.temperature[i] > 0) && (this.temperature[i + 1] < 0)) || ((this.temperature[i] < 0) && (this.temperature[i + 1] > 0)))
                {
                    amountTransitions++;
                }
            }
            return amountTransitions;
        }
    }


    public int Date
    {
        get
        {
            return this.date;
        }
        set
        {
            if (value <= this.date)
            {
                Console.WriteLine("Значение должно быть больше текужего значения date");
            }
            else
            {   
                int[] temporaryArray = new int[this.LastDay - value + 1];
                int k = 0;
                for (int i = value - this.date; i < this.temperature.Length; i++)
                {
                    temporaryArray[k] = this.temperature[i];
                    k++;
                }
            this.date = value;
            this.temperature = temporaryArray;
            }
        }
    }

    //для конструкторов
    private void CreateTemperature()
    {
        Random rand = new Random();
        for (int i = 0; i < this.temperature.Length; i++)
        {
            this.temperature[i] = rand.Next(minTemp[this.month - 1], maxTemp[this.month - 1]);
        }
    }

    public Weather()
    {
        this.month = 1;
        this.date = 20;
        this.temperature = new int[this.LastDay - this.date + 1];
        CreateTemperature();
    }

    public Weather(int month, int date)
    {
        this.month = month;
        this.date = date;
        this.temperature = new int[this.LastDay - this.date + 1];
        CreateTemperature();
    }


    //методы
    public void Output()
    {
        Console.WriteLine("Date     temp");
        int dateCount = this.date;
        foreach (int i in temperature)
        {
            Console.WriteLine($"{dateCount}.{this.month}     {i}");
            dateCount++;
        }
    }


    public int Average()
    {   
        int maxDelta = Math.Abs(this.AverageTemp - this.temperature[0]);
        int maxIndex = 0;
        for (int i = 0; i < this.temperature.Length; i++)
        {
            if (Math.Abs(this.AverageTemp - this.temperature[i]) > maxDelta)
            {
                maxDelta = Math.Abs(this.AverageTemp - this.temperature[i]);
                maxIndex = i;
            }
        }
        return maxIndex + this.date;
    }


    public void Average(int delta, ref int[] list)
    {   
        int count = 0;
        for (int i = 0; i < this.temperature.Length; i++)
        {
            if (Math.Abs(this.AverageTemp - this.temperature[i]) <= delta)
            {
                count++;
            }
        }
        int[] result = new int[count];
        int indexApp = 0;
        for (int i = 0; i < this.temperature.Length; i++)
        {
            if (Math.Abs(this.AverageTemp - this.temperature[i]) <= delta)
            {
                result[indexApp] = this.date + i;
                indexApp++;
            }
        }
        list = result;
    }


}


class Program
{
    static void Main()
    {
        string ans;
        Weather dairy;
        int month, date, delta;

        Console.WriteLine("Ты хочешь создать дневник сам? y/n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.WriteLine("Введи номер месяца");
            month = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введи дату, с которой ведётся наблюдение");
            date = Convert.ToInt16(Console.ReadLine());
            dairy = new Weather(month, date);
        }
        else
        {
            dairy = new Weather();
        }
        Console.WriteLine("Твой дневник:");
        dairy.Output();

        Console.WriteLine($"Максимальное отклонение от среднего значение было - {dairy.Average()}");
        
        Console.WriteLine("Какая дельта будет у новых дней в массиве?");
        delta = Convert.ToInt16(Console.ReadLine());
        int[] list = new int[1];
        dairy.Average(delta, ref list);
        Console.WriteLine("Вот твой новый массив:");
        foreach (int i in list)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        Console.WriteLine($"Количество дней в дневнике - {dairy.Days}");

        Console.WriteLine("Ты хочешь поменять дату начала наблюдения вдневнике? y/n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.WriteLine("Насколько ты хочешь поменять?");
            date = Convert.ToInt16(Console.ReadLine());
            dairy.Date = date;

            Console.WriteLine("Твой новый массив:");
            dairy.Output();
        }

        Console.WriteLine($"Номер месяца - {dairy.Month}");

        Console.WriteLine($"Самый тёплый день - {dairy.Hottest}");

        Console.WriteLine($"Самый холодный день - {dairy.Coldest}");

        Console.WriteLine($"Количество переходов через ноль в твоём дневнике - {dairy.Transitions}");   
    }
}