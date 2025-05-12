Console.WriteLine("Номер 1");
Console.WriteLine();


double x = 0.65;
double y = 1;
double R = Math.Sqrt((x * x) + (y * y));
double U;
if ((y > 0) && (R <= 2) && (R >= 1)) U = 1/(5 * x) + y;
else U = Math.Abs(1 - (x * y));
Console.WriteLine(U);


Console.WriteLine("Номер 2");
Console.WriteLine();


double N = 3;
double a, b, P, maxP;
maxP = 0;
for (int i = 0; i < N; i++)
{
    Console.WriteLine("Введите A:");
    a = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите B:");
    b = Convert.ToDouble(Console.ReadLine());

    P = 2 * a + 2 * b;
    if (P > maxP && P < 5)
    {
        maxP = P;
    }
}
Console.WriteLine($"Максимальный периметр меньший 5 - {maxP}");