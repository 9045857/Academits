using System;
using System.Collections;
using System.Collections.Generic;


namespace MyListAnalog
{
    class MyListOnArray<T> : IList<T>
    {
        private T[] items;
        private int modCount;

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    string methodName = "Capacity set";
                    string errorString = string.Format(WarningStrings.SetOutRange, methodName, value, Count);
                    throw new ArgumentOutOfRangeException(errorString);
                }

                Array.Resize(ref items, value);
            }
        }

        public int Count { get; private set; }

        public MyListOnArray()
        {
            Count = 0;

            int defaultCapacity = 10;
            items = new T[defaultCapacity];
        }

        public MyListOnArray(int beginCapacity)
        {
            Count = 0;
            items = new T[beginCapacity];
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                string methodName = "get";
                CheckIndexOutRange(methodName, index, 0, Count - 1);

                return items[index];
            }

            set
            {
                string methodName = "set";
                CheckIndexOutRange(methodName, index, 0, Count - 1);

                items[index] = value;

                modCount++;
            }
        }

        private void CheckIndexOutRange(string methodName, int index, int lowBound, int upBound)
        {
            if (index < lowBound || (index > upBound))
            {
                string errorString = string.Format(WarningStrings.IndexOutRange, methodName, index, lowBound, upBound);
                throw new IndexOutOfRangeException(errorString);
            }
        }

        private void IncreaseCapacityIfNeed()
        {
            if (Count >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
        }

        public void TrimExcess()
        {
            double allowedDeltaBetweenCountAndCapacity = 0.1;

            if (((double)Capacity / Count - 1) < allowedDeltaBetweenCountAndCapacity)
            {
                Array.Resize(ref items, Count);
            }
        }

        public void Add(T item)
        {
            IncreaseCapacityIfNeed();

            items[Count] = item;

            Count++;

            modCount++;
        }

        public void RemoveAt(int index)
        {
            string methodName = "RemoveAt(int index)";
            CheckIndexOutRange(methodName, index, 0, Count - 1);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            Count--;

            modCount++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item == null && items[i] == null)// нужно с налами разобраться
                {
                    return i;
                }
                else if (item != null && items[i] != null && item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            string methodName = "Insert(int index, T item)";
            CheckIndexOutRange(methodName, index, 0, Count);

            Count++;

            IncreaseCapacityIfNeed();

            for (int i = 1; i < (Count - index); i++)
            {
                items[Count - i] = items[Count - 1 - i];
            }

            items[index] = item;

            modCount++;
        }

        public void Clear()
        {
            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }

            return true;
        }

        private bool IsArrayLengthEnoughToCopy(int arrayLength, int beginIndex)
        {
            int indexNumberingShift = 1;
            return Count <= (arrayLength - (beginIndex + indexNumberingShift));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            string methodName = "CopyTo(T[] array, int arrayIndex)";
            CheckIndexOutRange(methodName, arrayIndex, 0, array.Length - 1);

            if (!IsArrayLengthEnoughToCopy(array.Length, arrayIndex))
            {
                string errorString = string.Format(WarningStrings.ArrayLengthNotEnoughToCopy, methodName, Count, arrayIndex, array.Length);
                throw new Exception(errorString);
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            Array.Copy(items, itemIndex + 1, items, itemIndex, Count - itemIndex - 1);

            Count--;

            modCount++;

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (currentModCount != modCount)
                {
                    string errorString = string.Format(WarningStrings.ChangeListError);
                    throw new InvalidOperationException(errorString);
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}