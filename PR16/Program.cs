class Point3D
{
    private double x;
    private double y;
    private double z;


    public Point3D()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }


    public Point3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }


    public Point3D(decimal n)
    {
        this.x = (double) n;
        this.y = (double) n;
        this.z = 0;
    }


    public void Move(string axis, double val)
    {
        switch (axis)
        {
            case "x": this.x = val; break;
            case "y": this.y = val; break;
            case "z": this.z = val; break;
        }
    }


    public void Output()
    {
        Console.WriteLine($"x - {this.x}, y - {this.y}, z - {this.z}");
    }


    public double RVector()
    {
        double r = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        return r;
    }


    public Point3D Summ(Point3D point)
    {
        double x = this.x + point.x;
        double y = this.y + point.y;
        double z = this.z + point.z;
        return new Point3D(x, y, z);
    }


    public Point3D Summ(double x, double y, double z)
    {
        double x_1 = x + this.x;
        double y_1 = y + this.y;
        double z_1 = z + this.z;
        return new Point3D(x_1, y_1, z_1);
    }


    public Point3D Summ(double n)
    {
        double x = this.x + n;
        double y = this.y + n;
        double z = this.z + n;
        return new Point3D(x, y, z);
    }


    public double X
    {
        get
        {
            return x;
        }
        set
        {
            if (value >= 0)
            {
                this.x = value;
            }
            else
            {
                Console.WriteLine("Значение не может быть отрицательным");
            }
        }
    }


    public double Y
    {
        get
        {
            return this.y;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.y = value;
            }
            else
            {
                Console.WriteLine("Значение должно пренадлежать промежутку [0; 100]");
            }
        }
    }


    public double Z 
    {
        get
        {
            return this.z;
        }
        set
        {
            if (value <= this.x + this.y)
            {
                this.z = value;
            }
            else
            {
                Console.WriteLine("Z должна быть меньше чем X + Y");
            }
        }
    }


    public bool HasHit
    {
        get
        {
            
        }
    }
}

class Program
{
    static void Main()
    {
        string ans, axis;
        Point3D point1, point2, point3;
        double x, y, z, val;
        
        Console.WriteLine("Ты хочешь создать точку сам? y/n");
        ans = Console.ReadLine();
        if (ans = "y")
        {
            Console.WriteLine("Введи x своей точки");
            x = Convert.ToInt16(Console.Readline());
            Console.WriteLine("Введи y своей точки");
            y = Convert.ToInt16(Console.Readline());
            Console.WriteLine("Введи z своей точки");
            z = Convert.ToInt16(Console.Readline());

            point1 = new Point3D(x, y, z);
        }
        else
        {
            point1 = new Point3D();
        }
         
        Console.WriteLine("Ты хочещь сдвинуть точку? y/n");
        ans = Console.ReadLine();
        if (ans = "y")
        {
            Console.WriteLine("По какой оси?");
            axis = Console.ReadLine();
            Console.WriteLine("На сколько");
            val = Convert.ToInt16(Console.ReadLine());
            
            point1.Output();
            point1.Move(axis, val);
            point1.Output();
        }

        
        //PR16.2
        point2 = new Point3D();
        point2.Move("x", 50);
        point2.Move("y", 15);
        point2.Output();
        Console.WriteLine($"Длина радиус-вектора 1 точки - {point1.RVector()}, длина радиус-вектора 2 точки - {point2.RVector()}");
        point3 = point1.Summ(point2);

    }
}