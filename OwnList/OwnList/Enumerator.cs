using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnList
{
    /// <summary>
    /// The list Enumerator.
    /// </summary>
    /// <typeparam name="T">List.</typeparam>
    public class Enumerator<T> : IEnumerator<T>
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

        object IEnumerator.Current => throw new NotImplementedException();

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
