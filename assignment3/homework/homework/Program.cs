using System;
using System.Collections.Generic;

namespace homework
{
    //定义接口
    public interface IShape
    {
        double Area { get; }
        bool IsValid();
    }
    //抽象类
    public abstract class Shape : IShape
    {
        public abstract double Area { get; }
        public abstract bool IsValid();
    }
    //具体形状类
    public class Rectangle : Shape 
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area => width * height;
        public override bool IsValid() => width > 0 && height > 0;
    }
    public class Square : Shape
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }

        public override double Area => side * side;
        public override bool IsValid() => side > 0;

    }
    public class Triangle : Shape
    {
        private double baseLength;
        private double height;

        public Triangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override double Area => (baseLength * height) / 2;
        public override bool IsValid() => baseLength > 0 && height > 0;
    }
    public class shapeFactory
    { 
        public static IShape CreateShape(string type,params double[] parameters)
        {
            switch (type.ToLower())
            {
                case "rectangle":
                    return new Rectangle(parameters[0], parameters[1]);
                case "square":
                    return new Square(parameters[0]);
                case "triangle":
                    return new Triangle(parameters[0], parameters[1]);
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            List<IShape> shapes = new List<IShape>();
            for(int i=0;i<10;i++)
            {
                int shapeType = random.Next(3);
                double[] parameters;

                switch (shapeType)
                {
                    case 0://Rectangle
                        parameters = new double[2];
                        parameters[0] = random.Next(1, 10);//width
                        parameters[1] = random.Next(1, 10);//height
                        shapes.Add(shapeFactory.CreateShape("rectangle", parameters[0], parameters[1]));
                        break;
                    case 1://Square
                        parameters = new double[1];
                        parameters[0] = random.Next(1, 10);//side
                        shapes.Add(shapeFactory.CreateShape("square", parameters[0]));
                        break;
                    case 2://Triangle
                        parameters = new double[2];
                        parameters[0] = random.Next(1, 10);//baseLength
                        parameters[1] = random.Next(1, 10);//height
                        shapes.Add(shapeFactory.CreateShape("Triangle", parameters[0], parameters[1]));
                        break;
                }
                double totalArea = 0;
                foreach ( var shape in shapes)
                {
                    if(shape.IsValid())
                    {
                        totalArea += shape.Area;
                    }

                }
                Console.WriteLine($"Total area of valid shapes:{totalArea}");
            }

        }
    }
}
