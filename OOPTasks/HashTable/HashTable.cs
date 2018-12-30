using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] itemsList;

        public HashTable(int itemsListCount)
        {
            itemsList = new List<T>[itemsListCount];
        }

        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

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

            Count += 1;
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
        }

        public bool Contains(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            return itemsList[itemListIndex] == null ? false : itemsList[itemListIndex].Contains(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(itemsList, array, arrayIndex);
        }

        public bool Remove(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            if (itemsList[itemListIndex] == null)
            {
                return false;
            }

            Count -= 1;

            return itemsList[itemListIndex].Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder hashTableStringBuilder = new StringBuilder();

            for (int i = 0; i < itemsList.Length; i++)
            {
                hashTableStringBuilder.Append(i);
                hashTableStringBuilder.Append(": ");

                if (itemsList[i] != null && itemsList[i].Count > 0)
                {
                    string divider = ", ";

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
