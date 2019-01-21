using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class ListItem<T>
    {
        public ListItem(T data)
        {
            Data = data;
            Next = null;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }

        public ListItem<T> Next { get; set; }
    }
}
