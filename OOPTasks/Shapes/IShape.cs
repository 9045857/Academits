namespace L2Shapes
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
        string GetName(); // ����� �������� ��� �������, ��� �� �������� �������� ������ � �������
    }
}
