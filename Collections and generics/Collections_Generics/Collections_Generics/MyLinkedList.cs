using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Collections_Generics
{
    [Serializable]
    public class MyLinkedList<T> : IEnumerable<T>, ISerializable
    {

        internal Node<T> head;
        public int Count { get; private set; } = 0;
        public MyLinkedList() { }
        public MyLinkedList(Node<T> node)
        {
            ValidateNewNode(node);
            head = node;
        }
        public MyLinkedList(params T[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public MyLinkedList(SerializationInfo info, StreamingContext context)
        {
            int count = (int)info.GetValue("Count", typeof(int));
            int index = 0;
            while (index < count)
            {
                var item = (T)info.GetValue($"{index}", typeof(T));
                Add(item);
                index++;
            }
        }

        public void AddNodeFirst(Node<T> newNode)
        {
            if (head is null)
            {
                head = newNode;
                head.next = head;
                head.prev = head;
            }
            else
            {
                head.prev.next = newNode;
                newNode.prev = head.prev;
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            Count++;
        }
        
        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node is null || newNode is null)
            {
                throw new ArgumentException("Incorrect arguments");
            }
            newNode.prev = node;
            newNode.next = node.next;
            node.next.prev = newNode;
            node.next = newNode;
            Count++;
        }
        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            Count++;
        }
        public void RemoveNode(Node<T> nodeToDel)
        {
            if (Count == 1)
            {
                head = null;
            }
            else
            {
                nodeToDel.prev.next = nodeToDel.next;
                nodeToDel.next.prev = nodeToDel.prev;
                if (nodeToDel == head)
                {
                    head = nodeToDel.next;
                }
            }
            Count--;
        }

        public override string ToString()
        {
            if (head is null)
            {
                return "Empty.";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"Type of Collection: {typeof(T).FullName}\n");
            int index = 0;
            foreach (var item in this)
            {
                sb.Append($"Node {index}: {item}\n");
                index++;
            }

            return sb.ToString();
        }
        public Node<T> AddFirst(T value)
        {
            Node<T> result = new Node<T>(this, value);
            if (head is null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
                head = result;
            }
            return result;
        }
        public Node<T> AddBefore(Node<T> node, T value)
        {
            ValidateNode(node);
            Node<T> result = new Node<T>(node.list, value);
            InternalInsertNodeBefore(node, result);
            if (node == head)
            {
                head = result;
            }
            return result;
        }
        public Node<T> Add(T item)
        {
            return AddLast(item);
        }

        public Node<T> AddLast(T value)
        {
            Node<T> result = new Node<T>(this, value);
            if (head is null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
            }
            return result;
        }
        public void Add(Node<T> node)
        {
            AddLast(node);
        }
        public void AddFirst(Node<T> node)
        {
            ValidateNewNode(node);

            if (head is null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
                head = node;
            }
            node.list = this;
        }
        public void AddLast(Node<T> node)
        {
            ValidateNewNode(node);

            if (head is null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
            }
            node.list = this;
        }
        private void InternalInsertNodeBefore(Node<T> node, Node<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            Count++;
        }
        private void InternalInsertNodeToEmptyList(Node<T> newNode)
        {
            if (head != null && Count != 0)
            {
                throw new InvalidOperationException("list is not empty");
            }
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            Count++;
        }
        private void ValidateNewNode(Node<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.list != null)
            {
                throw new InvalidOperationException("node is already attached to another list");
            }
        }
        private void ValidateNode(Node<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.list != this)
            {
                throw new InvalidOperationException("node is already attached to another list");
            }
        }
        public void Clear()
        {
            Node<T> current = head;
            while (current != null)
            {
                Node<T> temp = current;
                current = current.Next;   
                temp.Invalidate();
            }

            head = null;
            Count = 0;
        }
        public void BubbleSort()
        {
            if (head is null || Count <= 1)
                return;

            Node<T> node;
            int maxIndex = Count - 1;
            while (maxIndex > 0)
            {
                node = head;
                int index = 0;
                while (index < maxIndex)
                {
                    if (Comparer<T>.Default.Compare(node.item, node.next.item) > 0)
                    {
                        SwapValues(node, node.next);
                    }
                    node = node.next;
                    index++;
                }
                maxIndex--;
            }
        }
        public void SaveToFile(string fileName = "MyLinkedList.txt")
        {
            if (head is null || Count == 0)
            {
                throw new InvalidOperationException("Can't save nothing to a file.");
            }
            using StreamWriter sw = File.CreateText(fileName);
            Node<T> node = head;
            int nodeIndex = 0;
            do
            {
                sw.WriteLine($"Node {nodeIndex}: {node}");
                nodeIndex++;
                node = node.next;
            }
            while (node != head);
        }
        public void DisplayToConsole()
        {
            if (head is null)
            {
                if (Count == 0)
                {
                    Console.WriteLine("List is empty.");
                }
                else
                {
                    Console.WriteLine("Head node points to nothing so nothing to display.");
                }
                return;
            }
            Node<T> node = head;
            int nodeIndex = 0;
            do
            {
                Console.WriteLine($"Node {nodeIndex}: {node}");
                nodeIndex++;
                node = node.next;
            }
            while (node != head);
        }
        private void SwapValues(Node<T> node1, Node<T> node2)
        {
            if (node1.list != node2.list || node1.list != this || node2.list != this)
            {
                throw new InvalidOperationException("Can't swap values between nodes in different lists.");
            }

            T temp = node1.item;
            node1.item = node2.item;
            node2.item = temp;
        }

        // Methods for interfaces
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly MyLinkedList<T> list;
            private Node<T>? node;
            private T current;
            private int index;

            internal Enumerator(MyLinkedList<T> list)
            {
                this.list = list;
                node = list.head;
                current = default;
                index = 0;
            }

            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || (index == list.Count + 1))
                    {
                        throw new InvalidOperationException("enum can't happen.");
                    }

                    return current;
                }
            }

            public bool MoveNext()
            {
                if (node is null)
                {
                    index = list.Count + 1;
                    return false;
                }

                index++;
                current = node.item;
                node = node.next;
                if (node == list.head)
                {
                    node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                current = default;
                node = list.head;
                index = 0;
            }

            public void Dispose()
            {
                //
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Count", Count);
            int index = 0;
            foreach (var item in this)
            {
                info.AddValue($"{index}", item);
                index++;
            }
        }
    }
}
