using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmSummary
{
    public class PriorityQueue<T> : IEnumerable<T>, ICollection, IEnumerable
    {
        //默认容量
        private const int defaultCapacity = 11;
        //存放堆的数组
        private T[] heap;
        private IComparer<T> comparer;

        public int Count { get; private set; } = 0;

        public object SyncRoot => heap.SyncRoot;

        public bool IsSynchronized => heap.IsSynchronized;

        public T this[int index] 
        {
            get
            {
                return heap[index];
            }
            set
            {
                Update(index, value);
            }
        }

        public PriorityQueue()
        {
            Initial(defaultCapacity, null);
        }

        public PriorityQueue(int initialCapacity)
        {
            Initial(initialCapacity, null);
        }

        public PriorityQueue(int initialCapacity, IComparer<T> comparer)
        {
            Initial(initialCapacity, comparer);
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            Initial(defaultCapacity, comparer);
        }

        public PriorityQueue(ICollection<T> collection)
        {
            if (collection.GetType() == typeof(PriorityQueue<T>))
            {
                PriorityQueue<T> p = (PriorityQueue<T>)collection;
                heap = p.ToArray();
                Count = p.Count;
                comparer = p.comparer;
            }
            else
            {
                T[] array = collection.ToArray();
                heap = array;
                Count = array.Length;
                Heapify();
            }
        }

        private void Initial(int initialCapacity, IComparer<T> comparer)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            heap = new T[initialCapacity];
            this.comparer = comparer;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Array.Copy(heap, array, Count);
            return array;          
        }

        public void Add(T e)
        {
            Enqueue(e);
        }

        public bool Enqueue(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }
            else
            {               
                int i = Count;
                if (i >= heap.Length)
                {
                    Grow(i + 1);
                }

                SiftUp(i, e);
                Count = i + 1;
                return true;
            }
        }

        public T Peek()
        {
            return heap[0];
        }

        public T Dequeue()
        {
            T result;
            if ((result = heap[0]) != null)
            {
                int n = --Count;
                T x = heap[n];
                heap[n] = default;
                if (n > 0)
                {                  
                    if (comparer == null)
                    {
                        SiftDownComparable(0, x, n);
                    }
                    else
                    {
                        SiftDownUsingComparator(0, x, n);
                    }
                }
            }

            return result;
        }

        public bool Remove(T e)
        {
            int i = IndexOf(e);
            if (i == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(i);
                return true;
            }
        }

        private void Update(int i, T e)
        {
            SiftDown(i, e);
            if (ReferenceEquals(heap[i], e))
            {
                SiftUp(i, e);
            }
        }

        private int IndexOf(T e)
        {
            if (e != null)
            {
                int i = 0;
                for (int n = Count; i < n; ++i)
                {
                    if (EqualityComparer<T>.Default.Equals(e, heap[i]))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private T RemoveAt(int i)
        {
            int s = --this.Count;
            if (s == i)
            {
                heap[i] = default;
            }
            else
            {
                T moved = heap[s];
                heap[s] = default;
                SiftDown(i, moved);
                if (ReferenceEquals(heap[i], moved))
                {
                    SiftUp(i, moved);
                    if (!ReferenceEquals(heap[i], moved))
                    {
                        return moved;
                    }
                }
            }

            return default;
        }

        private void SiftUp(int k, T element)
        {
            if (this.comparer != null)
            {
                SiftUpUsingComparator(k, element);
            }
            else
            {
                SiftUpComparable(k, element);
            }

        }

        private void SiftUpComparable(int k, T element)
        {
            IComparable<T> key;
            int parent;
            for (key = (IComparable<T>)element; k > 0; k = parent)
            {
                parent = k - 1 >> 1;
                T e = heap[parent];
                if (key.CompareTo(e) >= 0)
                {
                    break;
                }

                heap[k] = e;
            }

            heap[k] = element;
        }

        private void SiftUpUsingComparator(int k, T element)
        {
            while (true)
            {
                if (k > 0)
                {
                    int parent = k - 1 >> 1;
                    T e = heap[parent];
                    if (comparer.Compare(element, e) < 0)
                    {
                        heap[k] = e;
                        k = parent;
                        continue;
                    }
                }

                heap[k] = element;
                return;
            }
        }

        private void SiftDown(int k, T element)
        {
            if (comparer != null)
            {
                SiftDownUsingComparator(k, element, Count);
            }
            else
            {
                SiftDownComparable(k, element, Count);
            }
        }

        private void SiftDownComparable(int k, T element, int n)
        {
            IComparable<T> key = (IComparable<T>)element;

            int child;
            for (int half = n >> 1; k < half; k = child)
            {
                child = (k << 1) + 1;
                T obj = heap[child];
                int right = child + 1;
                if (right < n && ((IComparable<T>)obj).CompareTo(heap[right]) > 0)
                {
                    child = right;
                    obj = heap[right];
                }

                if (key.CompareTo(obj) <= 0)
                {
                    break;
                }
                heap[k] = obj;
            }

            heap[k] = element;
        }

        private void SiftDownUsingComparator(int k, T element, int n)
        {          
            int child;
            for (int half = n >> 1; k < half; k = child)
            {
                child = (k << 1) + 1;
                T obj = heap[child];
                int right = child + 1;
                if (right < n && comparer.Compare(obj, heap[right]) > 0)
                {
                    child = right;
                    obj = heap[right];
                }

                if (comparer.Compare(element, obj) <= 0)
                {
                    break;
                }
                heap[k] = obj;
            }

            heap[k] = element;
        }

        /// <summary>
        /// 自底向上维护最小堆
        /// </summary>
        private void Heapify()
        {
            for (int i = Count >> 1 - 1; i >= 0; i--)
            {
                if (comparer == null)
                {
                    SiftDownComparable(i, heap[i], Count);
                }
                else
                {
                    SiftDownUsingComparator(i, heap[i], Count);
                }
            }
        }

        /// <summary>
        /// 扩容
        /// </summary>
        /// <param name="minCapacity"></param>
        private void Grow(int minCapacity)
        {
            int oldCapacity = heap.Length;
            int newCapacity = oldCapacity + (oldCapacity < 64 ? oldCapacity + 2 : oldCapacity >> 1);            
            if (newCapacity - 2147483639 > 0)
            {
                newCapacity = HugeCapacity(minCapacity);
            }
            T[] array = new T[newCapacity];
            Array.Copy(heap, array, newCapacity);
            heap = array;
        }

        private static int HugeCapacity(int minCapacity)
        {
            if (minCapacity < 0)
            {
                throw new OutOfMemoryException();
            }
            else
            {
                return minCapacity > 2147483639 ? 2147483647 : 2147483639;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            
            return new PriorityQueueEnumerator<T>(heap, 0, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Array.ConstrainedCopy(heap, index, array, 0, Count - index);
        }

        [Serializable]
        private sealed class PriorityQueueEnumerator<T2> : IEnumerator, ICloneable, IEnumerator<T2>
        {
            // Fields
            private bool _complete;
            private int[] _indices;
            private Array array;
            private int endIndex;
            private int index;
            private int startIndex;

            // Methods
            internal PriorityQueueEnumerator(Array array, int index, int count)
            {
                this.array = array;
                this.index = index - 1;
                this.startIndex = index;
                this.endIndex = index + count;
                this._indices = new int[array.Rank];
                int num = 1;
                for (int i = 0; i < array.Rank; i++)
                {
                    this._indices[i] = array.GetLowerBound(i);
                    num *= array.GetLength(i);
                }
                this._indices[this._indices.Length - 1]--;
                this._complete = num == 0;
            }

            public object Clone()
            {
                return base.MemberwiseClone();
            }

            private void IncArray()
            {
                int rank = this.array.Rank;
                this._indices[rank - 1]++;
                for (int i = rank - 1; i >= 0; i--)
                {
                    if (this._indices[i] > this.array.GetUpperBound(i))
                    {
                        if (i == 0)
                        {
                            this._complete = true;
                            return;
                        }
                        for (int j = i; j < rank; j++)
                        {
                            this._indices[j] = this.array.GetLowerBound(j);
                        }
                        this._indices[i - 1]++;
                    }
                }
            }

            public bool MoveNext()
            {
                if (this._complete)
                {
                    this.index = this.endIndex;
                    return false;
                }
                this.index++;
                this.IncArray();
                return !this._complete;
            }

            public void Reset()
            {
                this.index = this.startIndex - 1;
                int num = 1;
                for (int i = 0; i < this.array.Rank; i++)
                {
                    this._indices[i] = this.array.GetLowerBound(i);
                    num *= this.array.GetLength(i);
                }
                this._complete = num == 0;
                this._indices[this._indices.Length - 1]--;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            // Properties
            public object Current
            {
                get
                {
                    if (this.index < this.startIndex)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
                    }
                    if (this._complete)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumEnded");
                    }
                    return this.array.GetValue(this._indices);
                }
            }

            T2 IEnumerator<T2>.Current => (T2)Current;
        }
    }
}
