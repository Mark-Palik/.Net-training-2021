using System;
using System.Collections.Generic;
using System.Text;

namespace _8th_lab__Collections_and_serialization_
{
    public class Node<T>
    {
        public Node(T value)
        {
            item = value;
        }
        public Node(MyLinkedList<T> list, T value)
        {
            this.list = list;
            item = value;
        }

        internal MyLinkedList<T>? list;
        internal Node<T>? next;
        internal Node<T>? prev;
        internal T item;
        public MyLinkedList<T>? List { get { return list; } }
        public Node<T> Next
        {
            get { return next == null || next == list.head ? null : next; }
        }
        public Node<T> Previous
        {
            get { return prev == null || this == list.head ? null : prev; }
        }
        public T Value { get { return item; } set { item = value; } }
        public void Invalidate()
        {
            list = null;
            next = null;
            prev = null;
        }
        public override string ToString()
        {
            if (item == null)
            {
                return "Empty";
            }
            string? result = item.ToString();
            if (string.IsNullOrEmpty(result))
            {
                return "Empty";
            }
            else
            {
                return result;
            }
        }
    }
}
