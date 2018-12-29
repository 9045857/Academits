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
        private int itemsListLength;

        public HashTable(int itemsListCount)
        {
            itemsListLength = itemsListCount;
            itemsList = new List<T>[itemsListCount];
        }

        public int Count//TODO что это такое? количество всех элементов в таблице или размер массива?
        {
            get
            {
                int itemsCount = 0;
                foreach (List<T> list in itemsList)
                {
                    if (list!=null)
                    {
                        itemsCount += list.Count;
                    }
                }

                return itemsCount;
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                //TODO Не понимаю, для чего используется этот метод? 
                throw new NotImplementedException();
            }
        }

        private int GetItemListIndex(T item)
        {
            return Math.Abs(item.GetHashCode()) % itemsListLength;
        }

        public void Add(T item) //TODO нужно ли добавлять в хэш-таблицу элемент, если такой уже есть?
        {
            int itemListIndex = GetItemListIndex(item);

            if (itemsList[itemListIndex] == null)
            {
                itemsList[itemListIndex] = new List<T>();
            }

            itemsList[itemListIndex].Add(item);

        }

        public void Clear() //TODO что должна делать Clear?
        {
            itemsListLength = 0;
            itemsList = null;
        }

        public bool Contains(T item)
        {
            int itemListIndex = GetItemListIndex(item);

            return itemsList[itemListIndex].Contains(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            //TODO нужно разобраться постановкой задачи, и логикой исключений

            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            int itemListIndex = GetItemListIndex(item);
            
            if (itemsList[itemListIndex]==null)
            {
                return false;
            }

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
            if (itemsList==null)
            {
                return "null";
            }

            StringBuilder hashTableStringBuilder = new StringBuilder();
            string lineDivider = "\n";

            for (int i = 0; i < itemsList.Length; i++)
            {
                hashTableStringBuilder.Append(i);
                hashTableStringBuilder.Append(": ");                
                            
                if (itemsList[i] != null)
                {
                    string divider = ", ";

                    foreach (T element in itemsList[i])
                    {

                        hashTableStringBuilder.Append(element);
                        hashTableStringBuilder.Append(divider);
                    }
                    hashTableStringBuilder.Remove(hashTableStringBuilder.Length - divider.Length, divider.Length);
                }

                hashTableStringBuilder.Append(lineDivider);
            }
            hashTableStringBuilder.Remove(hashTableStringBuilder.Length - lineDivider.Length, lineDivider.Length);

            return hashTableStringBuilder.ToString();
        }

        // TODO нужно ли переопределять метод Equals?

    }
}
