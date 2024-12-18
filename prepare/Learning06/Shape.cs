public class Shape
{
    private string _color; // Color of the shape

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter and Setter for color
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method for GetArea()
    public virtual double GetArea()
    {
        return 0.0; // Default implementation, overridden in derived classes
    }
}
