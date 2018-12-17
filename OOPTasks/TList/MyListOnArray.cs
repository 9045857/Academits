using System;

namespace TArrayListHome
{
    class MyListOnArray<T>
    {
        private T[] items = new T[10];
        private int length;

        public int Count
        {
            get { return length; }
        }

        public T this[int index]
        { //TODO бросить исключение если выход за length 
            get { return items[index]; }
            //TODO бросить исключение если выход за length 
            set { items[index] = value; }
        }

        public void Add(T obj)
        {
            if (length >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[length] = obj;

            ++length;
        }

        public void AddAt(int index, object obj)
        { // TODO проверить выход за границы  - за границы длины(последний индекс+1) (последний +1 допускается)

            ++length;

            if (index < length - 1)
            {
                Array.Copy(items, index, items, index + 1, length - index);//TODO проверить по индексам все ли верно
            }

            items[index] = (T)obj;//TODO не до конца понятно, что делать со ссылочными типами. есть ощущение, что они не будут корректно работать
        }

        public void RemoveAt(int index)
        { // TODO проверить выход за границы 
            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            --length;
        }
    }
}