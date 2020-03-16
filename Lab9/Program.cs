using System;

namespace Lab9 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Testing ArrayList:");
            ArrayList<int> alist = new ArrayList<int>();
            var loop = true;
            do {
                Console.Write("Enter a number: ");
                alist.Add(Convert.ToInt32(Console.ReadLine()));
                string yn;
                do {
                    Console.Write("Are you done entering numbers (y/n)? ");
                    yn = Console.ReadLine().ToLower();
                } while (!(yn == "y" || yn == "n"));
                if (yn == "y")
                    loop = false;
            } while(loop);
            Console.WriteLine($"Initial contents of the list: {alist}");
            Console.Write("Please enter another number to add: ");
            alist.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Contents after adding another item: {alist}");
            Console.Write("Please enter the index of the element to remove: ");
            alist.Remove(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Contents after removing an item: {alist}");
            Console.Write($"Please enter the index of the element to retrieve: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Element at position {index} is: {alist[index]}");
            Console.WriteLine($"Sum of all items in the ArrayList: {SumArrayList(alist)}");


            Console.WriteLine("Testing LinkedList:");
            LinkedList<int> llist = new LinkedList<int>();
            loop = true;
            do {
                Console.Write("Enter a number: ");
                llist.Add(Convert.ToInt32(Console.ReadLine()));
                string yn = "";
                while (!(yn == "y" || yn == "n")) {
                    Console.Write("Are you done entering numbers (y/n)? ");
                    yn = Console.ReadLine().ToLower();
                }
                if (yn == "y")
                    loop = false;
            } while(loop);
            Console.WriteLine($"Initial contents of the list: {llist}");
            Console.Write("Please enter another number to add: ");
            llist.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Contents after adding another item: {llist}");
            Console.Write("Please enter the index of the element to remove: ");
            llist.Remove(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Contents after removing an item: {llist}");
            Console.Write($"Please enter the index of the element to retrieve: ");
            index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Element at position {index} is: {llist.Read(index)}");
            Console.WriteLine($"Sum of all items in the LinkedList: {SumLinkedList(llist)}");
        }

        static int SumArrayList(ArrayList<int> list) {
            int sum = 0;
            for (int i = 0; i < list.Count; i++) {
                sum += list[i];
            }
            return sum;
        }

        static int SumLinkedList(LinkedList<int> list) {
            int sum = 0;
            var node = list.First;
            while (node != null) {
                sum += node.Value;
                node = node.Next;
            }
            return sum;
        }
    }
    class ArrayList<T> {
        private T[] _arr;

        public int Count {get; private set;}
        public int Capacity {
            get => _arr.Length;
            set {
                if (value < Count)
                    throw new ArgumentOutOfRangeException("Capacity can not be set to less than it's contents");
                if (value != _arr.Length)
                    Array.Resize<T>(ref _arr, value);
            }
        }
        public T this[int index] {
            get {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Index out of range");
                return _arr[index];
            }
            set {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Index out of range");
                _arr[index] = value;
            }
        }

        public ArrayList() : this(0) {}

        public ArrayList(int size) {
            if (size <= 0)
                _arr = new T[0];
            else
                _arr = new T[size];
            Count = 0;
            Capacity = size;
        }

        public void Add(T item) {
            if (Capacity == 0)
                Capacity = 16;
            if (Count == Capacity)
                Capacity *= 2;
            Count++;
            _arr[Count-1] = item;
        }

        public void Remove(int index) {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Arguement out of range");
            if (index < --Count)
                Array.Copy(_arr, index + 1, _arr, index, Count - index);
            
            _arr[Count] = default(T);
            
            if (Capacity > Count * 4)
                Capacity = Count * 2;
        }

        public override string ToString() {
            string ret = "";
            for (int i = 0; i < Count - 1; i++)
                ret += $"{_arr[i]}, ";
            ret += $"{_arr[Count - 1]}";
            return ret;
        }
    }
    class LinkedList<T> {
        public int Count { get; private set; }
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }

        public LinkedList() {
            Count = 0;
            First = null;
            Last = null;
        }

        public void Add(T item) {
            Node<T> node;
            if (Count == 0) {
                node = new Node<T>(item, this, null, null);
                First = node;
                Last = node;
            }
            else {
                node = new Node<T>(item, this, Last, null);
                Last.Next = node;
                Last = node;
            }
            Count++;
        }

        public void Remove(int index) {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Arguement out of range");
            if (--Count == 0) {
                First = null;
                Last = null;
            }
            var node = First;
            for (int i = 0; i != Count; i++) {
                node = node.Next;
            }
            node.Previous.Next = node.Next;
            if (node.Next != null)
                node.Next.Previous = node.Previous;
        }

        public T Read(int index) {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Arguement out of range");
            var node = First;
            for (int i = 0; i != index; i++) {
                node = node.Next;
            }
            return node.Value;
        }

        public override string ToString() {
            string ret = "";
            var node = First;
            while (node.Next != null) {
                ret += $"{node.Value}, ";
                node = node.Next;
            }
            ret += $"{node.Value}";
            return ret;
        }

        public class Node<U> {
            public LinkedList<T> List;
            public Node<U> Previous;
            public Node<U> Next;
            public U Value;

            public Node(U value, LinkedList<T> list, Node<U> prev, Node<U> next) {
                Value = value;
                List = list;
                Previous = prev;
                Next = next;
            }
        }
    }
}
