using System;
using System.Collections;
using System.Collections.Generic;


namespace MyListAnalog
{
    class MyListOnArray<T> : IList<T>
    {
        private T[] items = new T[10];
        private int length;
        private int modCount;

        public MyListOnArray()
        {
            length = 0;
        }

        public int Count
        {
            get { return length; }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                string methodName = "get";
                CheckIndexOutRange(methodName, index, 0, length - 1);

                return items[index];
            }

            set
            {
                string methodName = "set";
                CheckIndexOutRange(methodName, index, 0, length - 1);

                items[index] = value;

                modCount++;
            }
        }

        private void CheckIndexOutRange(string methodName, int index, int lowBound, int upBound)
        {
            if (index < lowBound || (index > upBound))
            {
                string errorString = string.Format(WarningStrings.IndexOutRange, methodName, index, lowBound, upBound);
                throw new Exception(errorString);
            }
        }

        private void EnsureCapacity()
        {
            if (length >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
        }

        private void TrimToSize()
        {
            Array.Resize(ref items, length);
        }

        public void Add(T item)
        {
            EnsureCapacity();

            items[length] = item;

            length++;

            modCount++;
        }

        public void RemoveAt(int index)
        {
            string methodName = "RemoveAt(int index)";
            CheckIndexOutRange(methodName, index, 0, length - 1);

            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            length--;

            modCount++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            string methodName = "Insert(int index, T item)";
            CheckIndexOutRange(methodName, index, 0, length - 1);

            items[index] = item;

            modCount++;
        }

        public void Clear()
        {
            length = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsArrayLengthEnoughToCopy(int arrayLength, int beginIndex)
        {
            int indexNumberingShift = 1;
            return length <= (arrayLength - (beginIndex + indexNumberingShift));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            string methodName = "CopyTo(T[] array, int arrayIndex)";
            CheckIndexOutRange(methodName, arrayIndex, 0, array.Length - 1);

            if (!IsArrayLengthEnoughToCopy(array.Length, arrayIndex))
            {
                string errorString = string.Format(WarningStrings.ArrayLengthNotEnoughToCopy, methodName, length, arrayIndex, array.Length);
                throw new Exception(errorString);
            }

            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    Array.Copy(items, i + 1, items, i, length - i - 1);

                    length--;

                    modCount++;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < length; i++)
            {
                if (currentModCount != modCount)
                {
                    string errorString = string.Format(WarningStrings.ChangeListError);
                    throw new Exception(errorString);
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}