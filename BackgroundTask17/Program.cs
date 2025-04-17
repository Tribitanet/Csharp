class Equilateral_Trapezoid
{
    private int base_1;
    private int base_2;
    private int h;


    public Equilateral_Trapezoid(int base_1, int base_2, int h)
    {
        this.base_1 = base_1;
        this.base_2 = base_2;
        this.h = h;
    }

    public Equilateral_Trapezoid()
    {
        this.base_1 = 5;
        this.base_2 = 7;
        this.h = 3;
    }

    private double Side()
    {
        double side = Math.Sqrt((this.h * this.h) + Math.Pow((this.base_1 -this.base_2)/2, 2));
        return side;
    }
    public void output()
    {
        Console.WriteLine($"основания: {base_1} и {base_2}");
        Console.WriteLine($"высота - {h}");
        Console.WriteLine($"стороны - {this.Side()}");
    }

    public void change(string side, int val)
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


    public double Square()
    {
        double S = ((this.base_1 + this.base_2)/2) * this.h;
        return S;
    }


    public double Perimeter()
    {
        double P = this.base_1 + this.base_2 + this.Side() * 2;
        return P;
    }
}

class Program
{
    static void Main()
    {
        int base_1, base_2, side;
        Equilateral_Trapezoid trap;
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

            trap = new Equilateral_Trapezoid(base_1, base_2, side);
        }
        else
        {
            trap = new Equilateral_Trapezoid();
        }

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
    }
}