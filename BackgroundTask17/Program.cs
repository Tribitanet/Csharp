class Equilateral_Trapezoid
{
    private int base_1;
    private int base_2;
    private int side;


    public Equilateral_Trapezoid(int base_1, int base_2, int side)
    {
        this.base_1 = base_1;
        this.base_2 = base_2;
        this.side = side;
    }

    public void output()
    {
        Console.WriteLine($"основания: {base_1} и {base_2}");
        Console.WriteLine($"боковые стороны - {side}");
    }

    public void change(string side, int val)
    {
         Console.WriteLine("Что хочешь поменять в своей трапеции? 1 - основание 1; 2 - основание 2; 3 - боковая сторона.");
         switch (side)
         {
            case "1": this.base_1 = val; break;
            case "2": this.base_2 = val; break;
            case "3": this.side = val; break;
         }
    }


    public double Square()
    {
        double S = ((this.base_1 + this.base_2)/2) * Math.Sqrt((this.side * this.side) - Math.Pow((this.base_1 - this.base_2)/2, 2));
        return S;
    }


    public double Perimeter()
    {
        double P = this.base_1 + this.base_2 + this.side * 2;
        return P;
    }
}

class Program
{
    static void Main()
    {
        int base_1, base_2, side;

        Console.WriteLine("Ты хочешь создать р/б трапецию? y or n");
        string ans = Console.ReadLine();
        if (ans == "y")
        {
            Console.WriteLine("Введите длину 1-ого основания");
            base_1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите длину 2-ого основания");
            base_2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите длину боковой стороны");
            side = Convert.ToInt16(Console.ReadLine());

            Equilateral_Trapezoid trap_1 = new Equilateral_Trapezoid(base_1, base_2, side);
        }

        Console.WriteLine("Ты хочешь узнать периметр трапеции? y or n");
        ans = Console.ReadLine();
        if (ans == "y");
        {
            Console.WriteLine("Периметр трапеции равен:");
            Console.WriteLine(trap_1.Perimeter());
        }

        Console.WriteLine("Ты хочешь узнать площадь трапеции? y or n");
        ans = Console.ReadLine();
        if (ans = "y");
        {
            Console.WriteLine("Площадь трапеции равна:");
            Console.WriteLine(trap_1.Square());
        }
    }
}