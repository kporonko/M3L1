using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnList
{
    internal class OwnList<T> : IOwnList<T>
    {
        /// <summary>
        /// Base array we work with as a container.
        /// </summary>
        private T[] _elements;

        /// <summary>
        /// Size of array with elements (imaginary length) (dont count the default values that appeared after resizing).
        /// </summary>
        private int _size = 0;

        /// <summary>
        /// Actual length of the array with default valuess after resizing.
        /// </summary>
        private int _capacity = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnList{T}"/> class.
        /// Constructor creates the array of 'capacity value' elements. Default capacity - 10.
        /// </summary>
        public OwnList()
        {
            _elements = new T[_capacity];
        }

        /// <summary>
        /// Gets the imaginary size of our array (without 'empty' values).
        /// </summary>
        /// <value>
        /// The imaginary size of our array - number of elements.
        /// </value>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Array elements indexer.
        /// </summary>
        /// <param name="index">Index by which we want to seek the array.</param>
        /// <returns>Element of of array by that index.</returns>
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _size)
                {
                    return _elements[index];
                }

                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < _size)
                {
                    _elements[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Method prints on the console the array by size length (not count the empty capacity).
        /// </summary>
        public void PrintList()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.Write(_elements[i] + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Adds the element to the end of List (array actually).
        /// </summary>
        /// <param name="item">Element you want to insert.</param>
        public void Add(T item)
        {
            if (_size == _capacity)
            {
                ResizeArray();
            }

            _elements[_size] = item;
            _size++;
        }

        /// <summary>
        /// Adds the range of elements to the end of the list.
        /// </summary>
        /// <param name="items">IEnumerable collection of elements.</param>
        public void AddRange(IEnumerable<T> items)
        {
            int tempIndex = _size;
            while (_capacity - _size < items.Count())
            {
                // If the array has no space for this range - we increase capacity by 10.
                ResizeArray();
            }

            try
            {
                for (int i = 0; i < items.Count(); i++)
                {
                    // Adding the elements to the end of array one by one.
                    _elements[tempIndex] = items.ElementAt(i);
                    _size++;
                    tempIndex++;
                }
            }
            catch (NullReferenceException)
            {
                // If collection was null.
                Console.WriteLine("items were null");
            }
        }

        /// <summary>
        /// Removes the first element with same value (Exactly deleting - not value, but full container cell - with decrementing of both size and capacity).
        /// </summary>
        /// <param name="item">Element to remove.</param>
        /// <returns>Whether the element was deleted or no.</returns>
        public bool Remove(T item)
        {
            var tempList = _elements.ToList();
            if (_elements.Contains(item))
            {
                tempList.RemoveAt(Array.IndexOf(_elements, item));
                _elements = tempList.ToArray();
                _size--;
                _capacity--;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the element by particular index.
        /// </summary>
        /// <param name="index">Index, element with which will be deleted.</param>
        /// <exception cref="ArgumentOutOfRangeException">If there is no such an index.</exception>
        public void RemoveAt(int index)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempList = _elements.ToList();
            tempList.RemoveAt(index);
            _elements = tempList.ToArray();
            _size--;
            _capacity--;
        }

        /// <summary>
        /// Sorts the imaginary list (part in array without 'empty elements').
        /// </summary>
        public void Sort()
        {
            // There was a problem of sorting all the default values we actually dont have yet (after the _size).
            // I split the array into two arrays - first with only '_size elements' we need to and second - with default values - 'capacity values'.
            T[] temp = new T[_size];
            Array.Copy(_elements, temp, _size);
            T[] temp2Part = new T[_capacity - _size];
            Array.Sort(temp);
            temp.Concat(temp2Part);
            _elements = temp;
        }

        /// <summary>
        /// Gets the Enumerator of the List.
        /// </summary>
        /// <returns>The Enumerator of the List.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Actually it returns the 'List' elements and not contains the 'empty values' caused by Resizing (capacity increasing).
            T[] temp = new T[_size];
            Array.Copy(_elements, temp, _size);
            return new Enumerator(temp);
        }

        /// <summary>
        /// Method resizes the array, adding 10 to it`s length. These elements are filled by default value.
        /// </summary>
        private void ResizeArray()
        {
            T[] newArray = new T[_elements.Length + 10];
            Array.Copy(_elements, newArray, _elements.Length);
            _elements = newArray;
            _capacity = _elements.Length;
        }

        /// <summary>
        /// The list enumerator.
        /// </summary>
        public class Enumerator : IEnumerator<T>
        {
            /// <summary>
            /// An indexating array.
            /// </summary>
            private T[] _elements;

            /// <summary>
            /// Current position.
            /// </summary>
            private int _position = -1;

            public Enumerator(T[] elements)
            {
                _elements = elements;
            }

            /// <summary>
            /// Gets current element.
            /// </summary>
            /// <value>
            /// Current element of the enumerable.
            /// </value>
            public T Current
            {
                get
                {
                    if (_position >= _elements.Length && _position == -1)
                    {
                        throw new InvalidOperationException();
                    }

                    return _elements[_position];
                }
            }

            /// <summary>
            /// Gets current element of the collection.
            /// </summary>
            /// <value>
            /// Current element of the collection.
            /// </value>
            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
            }

            /// <summary>
            /// Moves to next element of collection.
            /// </summary>
            /// <returns>Whether we have next element or not.</returns>
            public bool MoveNext()
            {
                if (_position < _elements.Length - 1)
                {
                    _position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }
}
