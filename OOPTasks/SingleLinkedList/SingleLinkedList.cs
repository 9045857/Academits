using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class SingleLinkedList<T>
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
                // исключение на индекс

                //  string methodName = "get";

                return GetListItem(index).Data;
            }

            set
            {
                string methodName = "set";

                //CheckIndexOutRange(methodName, index, 0, Count - 1); // исключение на индекс

                GetListItem(index).Data = value;//Нужно проверить, что бы ссылочный тип работал правильно

                //items[index] = value;

                modCount++;
            }
        }

        //•	вставка элемента по индексу
        public void InsertTo(int index, T item)
        {
            if (index > Count)
            {
                string methodName = "InsertTo(int index, T item)";
                throw new Exception();
            }

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




        //•	удаление элемента по индексу, пусть выдает значение элемента








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




        //•	копирование списка
        public static void Copy(SingleLinkedList<T> sourceList, SingleLinkedList<T> destinationList)
        {
            int sourceListCount = sourceList.Count;
            int destinationListCount = destinationList.Count;

            destinationList.Head.Data = sourceList.Head.Data;// не понятно, если data ссылочный тип. Как делать присвоение?

            ListItem<T> currentSourceItem = new ListItem<T>(sourceList.Head.Data);
               
            

             //   sourceList.Head;


            ListItem<T> currentDestinationItem = destinationList.Head;
            
            if (sourceListCount <= destinationListCount)
            {
                for (int i = 1; i < sourceList.Count; i++)
                {
                    currentDestinationItem.Data = currentSourceItem.Data;
                }

                
            }
            else
            {


            }

            destinationList.Count = sourceList.Count;
            destinationList.Head = sourceList.Head;

          
            


        }
    }
}

