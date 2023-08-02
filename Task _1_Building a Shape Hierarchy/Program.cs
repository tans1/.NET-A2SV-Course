class Program
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle() { 
            Name = "circle", 
            Radius = 10 };

        Rectangle rectangle = new Rectangle() {
            Name = "Rectangle",
            Height = 10,
            Width = 10 };

        Triangle triangle = new Triangle() {
            Name = "Triangle",
            Base = 10,
            Height = 10 };
        


        Shape[] shapes = { circle, rectangle, triangle };
        foreach(Shape shape in shapes)
        {
            PrintShapeArea(shape);
        }


    }


    public static void PrintShapeArea(Shape shape)
    {
        double area = shape.CalculateArea();
        Console.WriteLine($"Name : {shape.Name}");
        Console.WriteLine($"Area :  {area}\n");
    }
}