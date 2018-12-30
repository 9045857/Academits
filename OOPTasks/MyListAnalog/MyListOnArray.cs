using System;
using System.Collections;
using System.Collections.Generic;


namespace MyListAnalog
{
    class MyListOnArray<T> : IList<T>
    {
        private T[] items = new T[10];
        private int length;

        public int Count
        {
            get { return length; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

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
            //TODO исключение для индекса в рамках списка
            //TODO исключение для нессылочных типов значение item = null
            //TODO тип вставляемого объекта должен быть такой же как у массива

            //            Исключения
            //ArgumentOutOfRangeException
            //Значение параметра index меньше 0.

            //- или - Значение index больше значения Count.

            items[index] = item;
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T item)
        {
            //TODO исключение что бы тип итем был типом массива ?
            for (int i = 0; i < length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // Исключения           ArgumentNullException
            //Свойство array имеет значение null.
            //ArgumentOutOfRangeException
            //Значение параметра arrayIndex меньше 0.
            //ArgumentException
            //Число элементов в исходной коллекции List<T> больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array.

            Array.Copy(items, array, arrayIndex);

            //            Комментарии
            //Этот метод использует Array.Copy копируются элементы.

            //Элементы копируются Array в том же порядке, в котором перечислитель перемещается по List<T>.

            //Этот метод является операцией O (n) операции, где n является Count.
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            //            Исключения
            //ArgumentNullException
            //Свойство array имеет значение null.
            //ArgumentOutOfRangeException
            //Значение параметра index меньше 0.

            //- или - Значение параметра arrayIndex меньше 0.


            //  - или - Значение параметра count меньше 0.
            //ArgumentException
            //Значение параметра index больше или равно значению Count исходного списка List<T>.

            //-или - Число элементов от index до конца исходного списка List<T> больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array.
            Array.Copy(items, index, array, arrayIndex, count);

            //            Комментарии
            //Этот метод использует Array.Copy копируются элементы.

            //Элементы копируются Array в том же порядке, в котором перечислитель перемещается по List<T>.

            //Этот метод является операцией O (n) операции, где n является Count.
        }

        public void CopyTo(T[] array)
        {

            //            Параметры
            //array
            //T[]
            //Одномерный массив Array, в который копируются элементы из интерфейса List<T>. Массив Array должен иметь индексацию, начинающуюся с нуля.
            //Исключения
            //ArgumentNullException
            //Свойство array имеет значение null.
            //ArgumentException
            //Число элементов в исходном массиве List<T> больше числа элементов, которые может содержать массив назначения array.

            items.CopyTo(array, length);
        }

        public bool Remove(T item)
        {
            //TODO какое исключение?

            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    Array.Copy(items, i + 1, items, i, length - i - 1);
                    
                    --length;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}