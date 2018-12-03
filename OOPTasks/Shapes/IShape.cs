namespace L2Shapes
{
    interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
        string GetName(); // метод добавлен вне задания, что бы выводить название фигуры в консоль
    }
}
