using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnList
{
    internal interface IOwnList<T>
    {
        public void Add(T item);
        public void AddRange(IEnumerable<T> items);
        public bool Remove(T item);
        public void RemoveAt(int index);
        public void Sort();

        public IEnumerator<T> GetEnumerator();
    }
}
