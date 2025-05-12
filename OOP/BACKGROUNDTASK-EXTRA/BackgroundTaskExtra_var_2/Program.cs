class Weather
{
    //погодка
    public enum WeatherType
    {
        Sunny,
        Cloudy,
        Overcast,
        Rain,
        Snow,
    }

    //средний макс и средний мин
    private static int[] minTemp = new int[] {-24, -21, -13, -4, 0, 5, 10, 6, 0, -4, -13, -19};
    private static int[] maxTemp = new int[] {2, 3, 11, 21, 27, 29, 31, 29, 24, 17, 8, 4};

    //поля
    private int[] temperature;
    private WeatherType[] weather;
    private int date;
    private int month;

    //объект для генерации случайности
    Random rand = new Random();

    //приватные свойства
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

    //публичные свойства
    public int Days
    {
        get
        {
            return this.LastDay - this.date + 1;
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
            if (value < this.date || value > this.LastDay)
            {
                Console.WriteLine("Так нельзя");
            }
            else
            {
                int[] temporaryArray = new int[this.LastDay - value + 1];
                WeatherType[] weatherArray = new WeatherType[this.LastDay - value + 1];

                int k = 0;
                for (int i = value - this.date; i < this.temperature.Length; i++)
                {
                    temporaryArray[k] = this.temperature[i];
                    k++;
                }

                k = 0;
                for (int i = value - this.date; i < this.weather.Length; i++)
                {
                    weatherArray[k] = this.weather[i];
                    k++;
                }

                this.date = value;
                this.weather = weatherArray;
                this.temperature = temporaryArray;
            }
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

    //генерация массивов
    private void CreateTemperature()
    {
        for (int i = 0; i < this.temperature.Length; i++)
        {
            this.temperature[i] = rand.Next(minTemp[this.month - 1], maxTemp[this.month - 1]);
        }
    }

    private void CreateWeather()
    {
        for (int i = 0; i < this.weather.Length; i++)
        {
            this.weather[i] = (WeatherType) rand.Next(0, 5);
        }
    }

    //конструкторы
    public Weather()
    {
        this.month = 1;
        this.date = 20;
        this.temperature = new int[this.Days];
        this.weather =  new WeatherType[this.Days];
        CreateTemperature();
        CreateWeather();
    }

    public Weather(int month, int date)
    {
        this.month = month;
        this.date = date;
        this.temperature = new int[this.Days];
        this.weather =  new WeatherType[this.Days];
        CreateTemperature();
        CreateWeather();
    }

    //методы
    public void Output()
    {
        Console.Write("DATE         ");
        for (int i = 0; i < this.Days; i++)
        {
            Console.Write($"{this.date + i}.{this.month}".PadRight(10));
        }
        Console.WriteLine();

        Console.Write("TEMP         ");
        foreach (int i in this.temperature)
        {
            Console.Write($"{i}".PadRight(10));
        }
        Console.WriteLine();

        Console.Write("WEATHER      ");
        foreach (WeatherType i in this.weather)
        {
            Console.Write($"{i}".PadRight(10));
        }
        Console.WriteLine();
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

    public WeatherType WeatherDay()
    {   
        int[] counts = new int[5];
        
        foreach (WeatherType weather in this.weather)
        {
            counts[(int)weather]++;
        }
        
        int maxIndex = 0;
        for (int i = 1; i < counts.Length; i++)
        {
            if (counts[i] > counts[maxIndex])
                maxIndex = i;
        }
        return (WeatherType)maxIndex;
    }

    public void WeatherDay(out int[] counts)
    {
        counts = new int[5];
        
        foreach (WeatherType weather in this.weather)
        {
            counts[(int)weather]++;
        }
    }
}

class Program
{
    public static void Main()
    {
        string ans;
        Weather dairy;
        int month, date;
        int[] list;

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

        Console.WriteLine($"В этом дневнике больше всего дней с погодой - {dairy.WeatherDay()}");

        Console.WriteLine("Количество дней с разным типом погоды");
        dairy.WeatherDay(out list);
        Console.WriteLine("Weather       Number");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{(Weather.WeatherType)i,-12}    {list[i],-5}");
        }

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

        Console.WriteLine($"Самый тёплый день - {dairy.Hottest}");

        Console.WriteLine($"Самый холодный день - {dairy.Coldest}");
    }
}