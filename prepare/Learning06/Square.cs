public class Square : Shape
{
    private double _side; // Length of the square's side

    // Constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method
    public override double GetArea()
    {
        return _side * _side;
    }
}
