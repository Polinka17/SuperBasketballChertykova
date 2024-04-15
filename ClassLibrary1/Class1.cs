namespace ClassLibrary1;

public class Class1
{
    public double CalcT(double v)
    {
        double t = Math.Round(2 * v / 9.8, 2);
        return t;
    }
}