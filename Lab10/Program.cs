using System;
using System.Collections.Generic;

namespace Lab10 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Stack Portion:");
            var stack = new MyStack<string>();
            stack.Push("Hello");
            stack.Push("Goodbye");
            stack.Push("Zombies");
            Console.WriteLine($"Initial contents of the stack: {stack}");
            Console.WriteLine("Adding: 'Street'");
            stack.Push("Street");
            Console.WriteLine($"Stack after adding another item: {stack}");
            Console.WriteLine($"Removing: {stack.Pop()}");
            Console.WriteLine($"Stack after removing an item: {stack}");
            Console.WriteLine($"Peeking: {stack.Peek()}");
            Console.WriteLine($"Stack after peeking an item: {stack}");

            Console.WriteLine("Queue Portion:");
            var queue = new MyQueue<string>();
            queue.Enqueue("Hola");
            queue.Enqueue("Hast la Vista");
            queue.Enqueue("Zombis");
            Console.WriteLine($"Initial contents of the queue: {queue}");
            Console.WriteLine("Adding: 'Calle'");
            queue.Enqueue("Calle");
            Console.WriteLine($"Queue after adding another item: {queue}");
            Console.WriteLine($"Removing: {queue.Dequeue()}");
            Console.WriteLine($"Queue after removing an item: {queue}");
            Console.WriteLine($"Peeking: {queue.Peek()}");
            Console.WriteLine($"Queue after peeking an item: {queue}");
        }
    }

    class MyStack<T> {
        private LinkedList<T> _list;

        public MyStack() {
            _list = new LinkedList<T>();
        }

        public override string ToString() {
            string ret = "";
            foreach (T i in _list) {
                ret += $"{i} ";
            }
            return ret;
        }

        public void Push(T item) {
            _list.AddLast(item);
        }

        public T Pop() {
            T ret = _list.Last.Value;
            _list.RemoveLast();
            return ret;
        }

        public T Peek() {
            return _list.Last.Value;
        }
    }

    class MyQueue<T> {
        private LinkedList<T> _list;

        public MyQueue() {
            _list = new LinkedList<T>();
        }
        
        public override string ToString() {
            string ret = "";
            foreach (T i in _list) {
                ret += $"{i} ";
            }
            return ret;
        }
        public void Enqueue(T item) {
            _list.AddLast(item);
        }

        public T Dequeue() {
            T ret = _list.First.Value;
            _list.RemoveFirst();
            return ret;
        }

        public T Peek() {
            return _list.First.Value;
        }
    }
}
