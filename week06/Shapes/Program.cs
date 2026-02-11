using System;

class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new Square("blue", 5);
        Rectangle myRectangle = new Rectangle("red", 2, 6);
        Circle myCircle = new Circle("green", 3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(myCircle);
        shapes.Add(myRectangle);
        shapes.Add(mySquare);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetArea());
            Console.WriteLine(shape.GetColor());
        }
    }
}