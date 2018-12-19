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
        {
            get
            {
                CheckIndexOutRange(index, 0, length);

                return items[index];
            }

            set
            {
                CheckIndexOutRange(index, 0, length);

                if (length >= items.Length)
                {
                    Array.Resize(ref items, items.Length * 2);
                }

                items[index] = value;

                ++length;
            }
        }

        private void CheckIndexOutRange(int index, int lowBound, int upBound)
        {
            if (index < lowBound || index > upBound)
            {
                string errorString = string.Format(WarningStrings.IndexOutRange, index, lowBound, upBound);
                throw new Exception(errorString);
            }
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

        public void Insert(int index, object obj)
        {
            CheckIndexOutRange(index, 0, length);

            ++length;

            if (index < length - 1)
            {
                Array.Copy(items, index, items, index + 1, length - index);
            }

            items[index] = (T)obj;
        }

        public void RemoveAt(int index)
        {
            CheckIndexOutRange(index, 0, length);

            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            --length;
        }
    }
}