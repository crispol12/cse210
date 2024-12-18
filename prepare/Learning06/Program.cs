using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 5, 3);
        Circle circle = new Circle("Green", 2.5);

        Console.WriteLine($"Square: Color = {square.GetColor()}, Area = {square.GetArea()}");
        Console.WriteLine($"Rectangle: Color = {rectangle.GetColor()}, Area = {rectangle.GetArea()}");
        Console.WriteLine($"Circle: Color = {circle.GetColor()}, Area = {circle.GetArea()}");

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Iterate through the list and display each shape's color and area
        Console.WriteLine("\nShapes in the list:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
