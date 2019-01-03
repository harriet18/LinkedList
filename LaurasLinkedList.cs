using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program2
    {
        static void Main()
        {
            LaurasLinkedList<int> intLinkedList = new LaurasLinkedList<int>();
            intLinkedList.AddFirst(5);
            intLinkedList.AddLast(7);
            intLinkedList.AddFirst(2);
            intLinkedList.AddLast(9);
            int howmany = intLinkedList.Count;

            intLinkedList.RemoveFirst();
            intLinkedList.RemoveLast();
            bool doesItHave2 = intLinkedList.Contains(2);

        }
    }
    public class LaurasLinkedList<T> : ICollection<T>
    {
        public LaurasLinkedListNode<T> Head
        {
            get; private set;
        }
        public LaurasLinkedListNode<T> Tail
        {
            get; private set;
        }

        public void AddFirst(T value)
        {
            AddFirst(new LaurasLinkedListNode<T>(value));
        }
        public void AddFirst(LaurasLinkedListNode<T> node)
        {
            LaurasLinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            Count++;
            if (Count == 1) Tail = Head;
        }
        public void AddLast(T value)
        {
            AddLast(new LaurasLinkedListNode<T>(value));
        }

        public void AddLast(LaurasLinkedListNode<T> node)
        {
            if (Count == 0) Head = node;
            else Tail.Next = node;
            Tail = node;
            Count++;

        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0) Tail = null;
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    // item1, item2, item3
                    // want to remove item3. So set Tail = item2
                    LaurasLinkedListNode<T> current = Head;
                    while (current.Next != Tail) current = current.Next;
                }
                Count--;
            }
        }
        public int Count
        {
            get; private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LaurasLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // copy all elements from the linked list into the array. 
            LaurasLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {

            // possible things that this needs to deal with. 1) there is no node to begin with (it is empty) 2) there is only one node in the list
            // 3) the list contains many nodes and we need to remove either the first, or an item from middle or last
            LaurasLinkedListNode<T> previous = null;
            LaurasLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        // this means there is more than one item in the list
                        // set the next point of previous to the next pointer of current (as current is going away)
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            // this means that now we've reached the tail
                            Tail = previous;
                        }
                        Count--;
                    }
                    else RemoveFirst();
                    return true;

                }
                previous = current;
                current = current.Next;

            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            LaurasLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }

    public class LaurasLinkedListNode<T>
    {
        public LaurasLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LaurasLinkedListNode<T> Next { get; set; }
    }
}
