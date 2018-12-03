using System;

namespace L2Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // � main � ���� �������� ������ �����, ����� � �� ���� ����� 5 - 10 ������ �����. 

            IShape[] shapes = new IShape[]
            {
                new Circle(1),
                new Circle(3),
                new Rectangle(2, 10),
                new Rectangle(10, 3),
                new Square(10),
                new Square(13),
                new Triangle(0, 0, 10, 0, 10, 5),
                new Triangle(0, 0, 10, 0, 10, 10)
            };

            // ������ � �������� �������, ������� ������� ������ � ������������ ��������.
            // ������� � ��� ����� ������ � ����������� ���������� � ������ � �������. 

            Console.WriteLine("������ ��������");
            PrintShapesAreaArray(shapes);
            Console.WriteLine();

            Array.Sort(shapes, new ShapesAreaComparer());

            Console.WriteLine("������ ����� ����� ���������� �� ������� �������");
            PrintShapesAreaArray(shapes);
            Console.WriteLine();

            Console.WriteLine("-= 1-� ������ �� �������: =-");
            Console.WriteLine("����� {0} ({1}) � �������� {2} ", shapes[0].GetType(), shapes[0].GetName(), shapes[0].GetArea());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Array.Sort(shapes, new ShapesPerimeterComparer());

            Console.WriteLine("������ ����� ���������� �� ������� ���������");
            PrintShapesPerimeterArray(shapes);
            Console.WriteLine();

            Console.WriteLine("-= 2-� ������ �� ����� ���������: =-");
            Console.WriteLine("����� {0} ({1}) � ���������� {2} ", shapes[1].GetType(), shapes[1].GetName(), shapes[1].GetPerimeter());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-= ��������� ��������������� ToString() =-");
            Console.WriteLine(new Circle(145).ToString());
            Console.WriteLine(new Rectangle(12, 23.2).ToString());
            Console.WriteLine(new Square(145).ToString());
            Console.WriteLine(new Triangle(0, 0, 5, 0, 5, 10).ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-= ��������� ��������� � ����������������� ��������� Equals() =-");
            Circle circle1 = new Circle(12);
            Circle circle2 = new Circle(14);
            Console.WriteLine("��������� ({0}) � ({1}): {2}", circle1, circle2, circle1.Equals(circle2));

            Triangle triangle1 = new Triangle(0, 0, 5, 0, 5, 10);
            Triangle triangle2 = new Triangle(1, 0, 5, 1, 5, 10);
            Console.WriteLine("��������� ({0}) � ({1}): {2}", triangle1, triangle2, triangle1.Equals(triangle2));

            Rectangle rectangle1 = new Rectangle(12, 23.2);
            Rectangle rectangle2 = new Rectangle(12, 23.2);
            Console.WriteLine("��������� ({0}) � ({1}): {2}", rectangle1, rectangle2, rectangle1.Equals(rectangle2));

            Square square1 = new Square(1.2);
            Square square2 = new Square(1.2);
            Console.WriteLine("��������� ({0}) � ({1}): {2}", square1, square2, square1.Equals(square2));
            Console.WriteLine();
        }

        private static void PrintShapesAreaArray(IShape[] shapes)
        {
            foreach (IShape shape in shapes)
            {
                Console.Write("{0} ", shape.GetArea());
            }
            Console.WriteLine();
        }

        private static void PrintShapesPerimeterArray(IShape[] shapes)
        {
            foreach (IShape shape in shapes)
            {
                Console.Write("{0} ", shape.GetPerimeter());
            }
            Console.WriteLine();
        }
    }
}
