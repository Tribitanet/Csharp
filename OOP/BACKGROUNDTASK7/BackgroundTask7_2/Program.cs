class EquilateralTrapezoid
{
    private double base_1;
    private double base_2;
    private double h;


    public EquilateralTrapezoid(double base_1, double base_2, double h)
    {
        this.base_1 = base_1;
        this.base_2 = base_2;
        this.h = h;
    }


    public EquilateralTrapezoid()
    {
        this.base_1 = 5;
        this.base_2 = 7;
        this.h = 3;
    }


    private double Side
    {   
        get
        {
            double side = Math.Sqrt((this.h * this.h) + Math.Pow((this.base_1 -this.base_2)/2, 2));
            return side;
        }
    }


    public double Base_1
    {
        get 
        {
            return this.base_1;
        }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Основание 1 должно быть положительным числом");
            }
            else
            {
                this.base_1 = value;
            }
        }
    }


    public double Base_2
    {
        get
        {
            return this.base_2;
        }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Основание 2 должно быть положительным числом");
            }
            else
            {
                this.base_2 = value;
            }
        }
    }


    public double H
    {
        get
        {
            return this.h;
        }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Высота должна быть положительной");
            }
            else
            {
                this.h = value;
            }
        }
    }


    public bool HasInscribedCircle
    {
        get 
        {
            return ((this.base_1 + this.base_2) == 2 * this.Side);
        }
    }


    public void Change(string side, int val)
    {
         Console.WriteLine("Что хочешь поменять в своей трапеции? 1 - основание 1; 2 - основание 2; 3 - высоту.");
         side = Console.ReadLine();
         Console.WriteLine("На сколько ты хочешь поменять?");
         val = Convert.ToInt16(Console.ReadLine());
         switch (side)
         {
            case "1": this.base_1 = val; break;
            case "2": this.base_2 = val; break;
            case "3": this.h = val; break;
         }
    }


    public void Output()
    {
        Console.WriteLine($"основания: {base_1} и {base_2}");
        Console.WriteLine($"высота - {h}");
        Console.WriteLine($"стороны - {this.Side}");
    }


    public double MiddleLine()
    {
        double middleLine = (this.base_1 + this.base_2)/2;
        return middleLine;
    }


    public double Square()
    {
        double S = this.MiddleLine() * this.h;
        return S;
    }


    public double Perimeter()
    {
        double P = this.base_1 + this.base_2 + this.Side * 2;
        return P;
    }


    public double Diagonal()
    {
        double diagonal = Math.Sqrt((Math.Pow((this.base_1 + this.base_2) / 2, 2) + Math.Pow(this.h, 2)));
        return diagonal;
    }
    

    public double CircumscribedRadius()
    {
        double R = Diagonal() / (2 * this.Side / this.h);
        return R;
     }

    
    public double? InscribedRadius()
    {
        if (HasInscribedCircle == true)
        {
            double R = Square() / (Perimeter() / 2);
            return R;
        }
        else
        {
            Console.WriteLine("В данную трапецию нельзя вписать окружность");
            return null;
        }
    }
}


class Program
{
    static void Main()
    {
        int base_1, base_2, side;
        EquilateralTrapezoid trap;
        Console.WriteLine("Ты хочешь создать р/б трапецию сам? y or n");
        string ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.WriteLine("Введите длину 1-ого основания");
            base_1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите длину 2-ого основания");
            base_2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите длину боковой стороны");
            side = Convert.ToInt16(Console.ReadLine());

            trap = new EquilateralTrapezoid(base_1, base_2, side);
        }
        else
        {
            trap = new EquilateralTrapezoid();
        }

        Console.WriteLine("Твоя трапеция:");
        trap.Output();

        Console.WriteLine("Ты хочешь узнать периметр трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.Write("Периметр трапеции равен: ");
            Console.WriteLine(trap.Perimeter());
        }

        Console.WriteLine("Ты хочешь узнать площадь трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.Write("Площадь трапеции равна: ");
            Console.WriteLine(trap.Square());
        }

        Console.WriteLine("Ты хочешь узнать среднюю линию трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.Write("Средняя линия трапеции равна: ");
            Console.WriteLine(trap.MiddleLine());
        }

        Console.WriteLine("Ты хочешь узнать диагональ трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.Write("Диагональ трапеции равна: ");
            Console.WriteLine(trap.Diagonal());
        }

        Console.WriteLine("Ты хочешь узнать радиус окружности описанной вокруг трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.Write("Радиус окружности равен: ");
            Console.WriteLine(trap.CircumscribedRadius());
        }

        Console.WriteLine("Ты хочешь узнать радиус окружности вписанной в трапецию? y or n");
        ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.WriteLine(trap.InscribedRadius());
        }
    }
}