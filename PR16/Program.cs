using System.Security.Cryptography.X509Certificates;

class point3D
{
    public int x;
    public int y;
    public int z;

    public point3D()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public point3D(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public void print()
    {
        Console.WriteLine($"x - {x}, y - {y}, z - {z}");
    }

    public void change(string a, int b)
    {
        if (a == "x")
        {
            x += b;
        }
        else if (a == "y")
        {
            y += b;
        }
        else
        {
            z += b;
        }
    }


    public double radius_v()
    {
        double R = Math.Sqrt(x * x + y * y + z * z);
        return R;
    }


    public point3D plus(point3D otherPoint)
    {
        int newX = this.x + otherPoint.x;
        int newY = this.y + otherPoint.y;
        int newZ = this.z + otherPoint.z;

        return new point3D(newX, newY, newZ);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ты хочешь ввести координаты сам? y or n");
        string j = Console.ReadLine();
        point3D point, point_1, point_2;

        if (j == "n")
        {
            point = new point3D();
        }
        else
        {
            int x = Convert.ToInt16(Console.ReadLine());
            int y = Convert.ToInt16(Console.ReadLine());
            int z = Convert.ToInt16(Console.ReadLine());
            point = new point3D(x, y, z);
        }

        /*Console.WriteLine("Какое количество команд ты хочешь выполнить?");
        int s = Convert.ToInt16(Console.ReadLine());

        for (int i = 0; i < s; i++)
        {
            Console.WriteLine("Измени одну из координат или вывести координаты твоей точки в консоль?");
            string ans = Console.ReadLine();

            if (ans == "print")
            {
                point.print();
            }
            else
            {
                Console.WriteLine("Координата которую хочешь изменить");
                string h = Console.ReadLine();
                Console.WriteLine("На сколько ты хочешь изменить её");
                int cou = Convert.ToInt16(Console.ReadLine());
                point.change(h, cou);
            }
        }*/

        point_1 = new point3D();
        point_1.change("X", 50);
        point_1.change("y", 15);
        
        Console.WriteLine("Радиус-вектор 1 точки:");
        Console.WriteLine(point.radius_v());
        Console.WriteLine("Радиус-вектор 2 точки:");
        Console.WriteLine(point_1.radius_v());
        
        point_2 = new point3D();
        point_2 = point.plus(point_1);

        Console.WriteLine("результат сложения двух точек:");
        point_2.print();

        


        Main();
    }
}
