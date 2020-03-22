using System;
using System.Collections.Generic;

namespace Lab10 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }

    class MyStack<T> {
        private LinkedList<T> _list;

        public Stack(){
            _list = new LinkedList<T>();
        }

        public override string ToString() {
            foreach (T i in _list) {
                ret += $"{i} ";
            }
            return ret;
        }

        public void Push(T item) {
            _list.Add(item);
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

        public Queue() {
            _list = new LinkedList<T>();
        }
        
        public override string ToString() {
            foreach (T i in _list) {
                ret += $"{i} ";
            }
            return ret;
        }
        public void Enqueue(T item) {
            _list.Add(item);
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
