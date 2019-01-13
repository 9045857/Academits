using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] itemsList;

        private int modCount = 0;

        public HashTable(int itemsListCount)
        {
            itemsList = new List<T>[itemsListCount];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int GetItemListIndex(T item)
        {
            return Math.Abs(item.GetHashCode() % itemsList.Length);
        }

        public void Add(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            if (itemsList[itemListIndex] == null)
            {
                itemsList[itemListIndex] = new List<T>();
            }

            itemsList[itemListIndex].Add(item);

            Count++;

            modCount++;
        }

        public void Clear()
        {
            foreach (List<T> list in itemsList)
            {
                if (list != null)
                {
                    list.Clear();
                }
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            return (itemsList[itemListIndex] != null) && itemsList[itemListIndex].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Массив в который нужно копировать = null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс массива, с которого начнется копирование из таблицы меньше 0");
            }

            if (Count + arrayIndex > array.Length)
            {
                throw new ArgumentException("Размер массива меньше, чем количество элементов в таблице");
            }

            int position = 0;
            for (int i = 0; i < itemsList.Length; i++)
            {
                if (itemsList[i] != null)
                {
                    itemsList[i].CopyTo(array, position);

                    position += itemsList[i].Count;
                }
            }
        }

        public bool Remove(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            if (itemsList[itemListIndex] == null)
            {
                return false;
            }

            if (itemsList[itemListIndex].Remove(item))
            {
                Count--;

                modCount++;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < itemsList.Length; ++i)
            {
                if (itemsList[i] != null)
                {
                    for (int j = 0; j < itemsList[i].Count; j++)
                    {
                        if (currentModCount != modCount)
                        {
                            throw new InvalidOperationException("Изменился набор таблицы во время прохода foreach");
                        }

                        yield return itemsList[i][j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            StringBuilder hashTableStringBuilder = new StringBuilder();

            string divider = ", ";
            for (int i = 0; i < itemsList.Length; i++)
            {
                hashTableStringBuilder.Append(i);
                hashTableStringBuilder.Append(": ");

                if (itemsList[i] != null && itemsList[i].Count > 0)
                {


                    foreach (T element in itemsList[i])
                    {

                        hashTableStringBuilder.Append(element);
                        hashTableStringBuilder.Append(divider);
                    }
                    hashTableStringBuilder.Remove(hashTableStringBuilder.Length - divider.Length, divider.Length);
                }

                hashTableStringBuilder.AppendLine();
            }
            int appendLineLength = 1;
            hashTableStringBuilder.Remove(hashTableStringBuilder.Length - appendLineLength, appendLineLength);

            return hashTableStringBuilder.ToString();
        }
    }
}
