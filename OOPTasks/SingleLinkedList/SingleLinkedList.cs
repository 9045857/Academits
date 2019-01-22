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
                CheckIndexInRange(methodName, index, 0, Count - 1);

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
        public void InsertTo(int index, T data)
        {
            string methodName = "InsertTo(int index, T data)";
            CheckIndexInRange(methodName, index, 0, Count);

            if (index == 0)
            {
                ListItem<T> insertedItem = new ListItem<T>(data, Head);
                Head = insertedItem;
            }
            else if (index < Count)
            {
                ListItem<T> previewInsertedListItem = GetListItem(index - 1);
                ListItem<T> nextInsertedListItem = previewInsertedListItem.Next;

                previewInsertedListItem.Next = new ListItem<T>(data, nextInsertedListItem);
            }
            else
            {
                ListItem<T> insertedItem = new ListItem<T>(data);
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

            ListItem<T> currentItem = GetListItem(index);

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

            ListItem<T> currentItem;

            T resultItem;

            if (index == 0)
            {
                currentItem = Head;

                resultItem = Head.Data;
                Head = currentItem.Next;
                Count--;

                modCount++;

                return resultItem;
            }

            if (index == Count)
            {
                currentItem = GetListItem(Count - 2);

                resultItem = currentItem.Next.Data;
                currentItem.Next = null;
                Count--;

                modCount++;

                return resultItem;
            }

            currentItem = GetListItem(index - 1);

            resultItem = currentItem.Next.Data;
            currentItem.Next = currentItem.Next.Next;
            Count--;

            modCount++;

            return resultItem;
        }

        //•	удаление узла по значению, пусть выдает true, если элемент был удален
        public bool Remove(T item)
        {
            if (Count == 0 || Head == null)
            {
                return false;
            }

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

        private static void CheckOnEmptyList(string methodName, SingleLinkedList<T> list)
        {
            if (list.Count == 0 || Equals(list.Head, null))
            {
                string errorMessage = string.Format(WarningStrings.EmptyList, methodName);
                throw new NullReferenceException(errorMessage);
            }
        }

        //•	удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            string methodName = "RemoveFirst()";
            CheckOnEmptyList(methodName, this);

            T headData = Head.Data;
            Head = Head.Next;
            Count--;

            modCount++;

            return headData;
        }

        //•	разворот списка за линейное время
        public void Reverse()
        {
            if (Equals(Head, null))
            {
                return;
            }

            ListItem<T> currentItem = Head;
            ListItem<T> previewItem = null;

            while (currentItem.Next != null)
            {
                ListItem<T> nextItem = currentItem.Next;
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
            if (sourceList.Count == 0 || Equals(sourceList.Head, null))
            {
                destinationList.Count = 0;
                destinationList.Head = null;

                return;
            }

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

        //7. Итератор упадет на пустом списке
        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (ListItem<T> currentItem = Head; currentItem != null; currentItem = currentItem.Next)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException(WarningStrings.ChangeCountInForeach);
                }

                yield return currentItem.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

