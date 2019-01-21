using System;
using System.Collections;
using System.Collections.Generic;

namespace SingleLinkedList
{
    public class SingleLinkedList<T> : IEnumerable
    {
        private int modCount;

        public SingleLinkedList() { }

        //•	получение размера списка
        public int Count { get; private set; }

        //•	получение значение первого элемента
        public ListItem<T> Head { get; private set; }

        //•	вставка элемента в начало
        public void AddFirst(T item)
        {
            ListItem<T> addedItem = new ListItem<T>(item, Head);

            Head = addedItem;

            Count++;

            modCount++;
        }

        private ListItem<T> GetListItem(int index)
        {
            ListItem<T> currentItem = Head;

            for (int i = 1; i <= index; i++)
            {
                currentItem = currentItem.Next;
            }

            return currentItem;
        }

        //•	получение/изменение значения по указанному индексу.
        public T this[int index]
        {
            get
            {
                string methodName = "get[int index]";
                CheckIndexInRange(methodName, index, 0, Count - 1);

                return GetListItem(index).Data;
            }

            set
            {
                string methodName = "set[int index]";
                CheckIndexInRange(methodName, index, 0, Count);

                GetListItem(index).Data = value;

                modCount++;
            }
        }

        private void CheckIndexInRange(string methodName, int index, int lowBound, int upBound)
        {
            if (index < lowBound || index > upBound)
            {
                string errorMessage = string.Format(WarningStrings.IndexOutRange, methodName, index);
                throw new IndexOutOfRangeException(errorMessage);
            }
        }

        //•	вставка элемента по индексу
        public void InsertTo(int index, T item)
        {
            string methodName = "InsertTo(int index, T item)";
            CheckIndexInRange(methodName, index, 0, Count);

            if (index == 0)
            {
                ListItem<T> insertedItem = new ListItem<T>(item, Head);
                Head = insertedItem;
            }
            else if (index < Count)
            {
                ListItem<T> insertedItem = new ListItem<T>(item, GetListItem(index));
                GetListItem(index - 1).Next = insertedItem;
            }
            else
            {
                ListItem<T> insertedItem = new ListItem<T>(item);
                GetListItem(index - 1).Next = insertedItem;
            }

            Count++;

            modCount++;
        }

        //• Изменение значения по индексу пусть выдает старое значение.
        public T Replace(int index, T newData)
        {
            string methodName = "Replace(int index, T newData)";
            CheckIndexInRange(methodName, index, 0, Count - 1);

            ListItem<T> currentItem = Head;

            for (int i = 0; i < index; i++)
            {
                currentItem = currentItem.Next;
            }

            T resultData = currentItem.Data;

            currentItem.Data = newData;

            modCount++;

            return resultData;
        }

        //•	удаление элемента по индексу, пусть выдает значение элемента
        public T RemoveAt(int index)
        {
            string methodName = "RemoveAt(int index)";
            CheckIndexInRange(methodName, index, 0, Count - 1);

            ListItem<T> currentItem = Head;

            T resultItem;

            if (index == 0)
            {
                resultItem = Head.Data;

                Head = currentItem.Next;

                Count--;

                modCount++;

                return resultItem;
            }

            if (index == Count)
            {
                for (int i = 1; i < Count - 1; i++)
                {
                    currentItem = currentItem.Next;
                }

                resultItem = currentItem.Next.Data;

                currentItem.Next = null;

                Count--;

                modCount++;

                return resultItem;
            }

            for (int i = 1; i < index; i++)
            {
                currentItem = currentItem.Next;
            }

            resultItem = currentItem.Next.Data;

            currentItem.Next = currentItem.Next.Next;

            Count--;

            modCount++;

            return resultItem;
        }

        //•	удаление узла по значению, пусть выдает true, если элемент был удален
        public bool Remove(T item)
        {
            if (Equals(Head.Data, item))
            {
                Head = Head.Next;

                Count--;

                modCount++;

                return true;
            }

            ListItem<T> currentItem = Head;

            for (int i = 0; i < Count - 1; i++)
            {
                if (Equals(currentItem.Next.Data, item))
                {
                    currentItem.Next = currentItem.Next.Next;

                    Count--;

                    modCount++;

                    return true;
                }

                currentItem = currentItem.Next;
            }

            return false;
        }

        //•	удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new Exception();
            }

            T headData = Head.Data;

            Head = Head.Next;

            Count--;

            modCount++;

            return headData;
        }

        //•	разворот списка за линейное время
        public void Reverse()
        {
            ListItem<T> currentItem = Head;
            ListItem<T> previewItem = null;
            ListItem<T> nextItem;

            while (currentItem.Next != null)
            {
                nextItem = currentItem.Next;
                currentItem.Next = previewItem;
                previewItem = currentItem;
                currentItem = nextItem;
            }

            currentItem.Next = previewItem;
            Head = currentItem;

            modCount++;
        }

        //•	копирование списка
        public static void Copy(SingleLinkedList<T> sourceList, SingleLinkedList<T> destinationList)
        {
            ListItem<T> currentSourceItem = sourceList.Head;
            ListItem<T> currentDestinationItem = new ListItem<T>(sourceList.Head.Data);

            destinationList.Head = currentDestinationItem;
            destinationList.Count = sourceList.Count;

            while (currentSourceItem.Next != null)
            {
                currentDestinationItem.Next = new ListItem<T>(currentSourceItem.Next.Data);
                currentSourceItem = currentSourceItem.Next;
                currentDestinationItem = currentDestinationItem.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            ListItem<T> currentItem = Head;

            yield return currentItem.Data;

            for (int i = 1; i < Count; i++)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException(WarningStrings.ChangeCountInForeach);
                }

                currentItem = currentItem.Next;

                yield return currentItem.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

