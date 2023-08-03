void Main(string[] args)
{
    Circle circle = new Circle();
    circle.Radius = 2;
    PrintShapeArea(circle);

    Rectangle rectangle = new Rectangle();
    rectangle.Width = 2;
    rectangle.Height = 2;
    PrintShapeArea(rectangle);

    Triangle triangle = new Triangle();
    triangle.Basee = 2;
    triangle.Height = 2;
    PrintShapeArea(triangle);
}

Main(args);

void PrintShapeArea(Shape obj)
{
    Console.WriteLine(obj.Name + " has an area of " + obj.CalculateArea());
}
class Shape{
    private string name; 
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public virtual double CalculateArea()
    {
        return 0;
    }

}
class Circle: Shape
{
    private double radius;
    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    public override double CalculateArea()
    {
        return 3.14 * radius * radius;
    }
}
class Rectangle: Shape
{
    private double height;
    private double width;
    public double Height
    {
        set { height = value; }
        get { return height; }
    }
    public double Width
    {
        set { width = value; }
        get { return width; }
    }
    public override double CalculateArea()
    {
        return height * width;
    }

}
class Triangle: Shape
{
    private double basee;
    private double height;
    public double Basee
    {
        set { basee = value; }
        get { return basee; }
    }
    public double Height
    {
        set { height = value; }
        get { return height; }
    }
    public override double CalculateArea()
    {
        return 0.5 * basee * height;
    }
}



    
    




