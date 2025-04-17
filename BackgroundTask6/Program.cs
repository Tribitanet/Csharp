//exercise 1

double x = 0.65;
double y = 1;
double R = Math.Sqrt((x * x) + (y * y));
double U;
if ((y > 0) && (R <= 2) && (R >= 1)) U = 1/(5 * x) + y;
else U = Math.Abs(1 - (x * y));
Console.WriteLine(U);


//exercise 2
