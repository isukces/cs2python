using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lang.Python
{
    public class PyList<T> : IList<T>
    {
        public PyList(List<T> result)
        {
            _list = result;
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }

        public int Count => _list.Count;

        public           bool     IsReadOnly => _list.IsReadOnly;
        private readonly IList<T> _list;

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }
    }
}