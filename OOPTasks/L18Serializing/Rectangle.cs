using System;
using System.Runtime.Serialization;

namespace L18Serializing
{
    //Создать свой класс Rectangle с полями ширина, высота и площадь
    //•Должен быть конструктор, который принимает ширину и высоту, сохраняет их в поля.Затем, вычисляет площадь 
    //и сохраняет в поле
    //•Пометить поле площадь как NonSerialized
    //•Попробовать сериализовать объект класса Rectangle в файл, а затем десериализовать его из файла. И чтобы площадь при этом заполнилась
    //•Используйте методы с атрибутами OnSerializing, OnDeserialized
    [Serializable]
    class Rectangle
    {
        private double height;

        private double width;

        [NonSerialized]
        private double area;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
            this.area = height * width;
        }

        [OnDeserialized]
        private void GetAreaOnDeserialized(StreamingContext context)
        {
            area = height * width;
        }

        public override string ToString()
        {
            return string.Concat("Прямоугольник ", height, " x ", width, " с площадью ", area);
        }
    }
}
