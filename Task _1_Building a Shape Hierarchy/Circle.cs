public class Circle : Shape
{
    public double Radius { set; get; }
    private double PI = Math.PI;
    public override double CalculateArea()
    {
        return PI * Radius * Radius;
    }
}
