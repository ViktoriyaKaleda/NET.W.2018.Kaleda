using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
	/// <summary>
	/// Class that implement queue data structure.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Queue<T> : IEnumerable<T>
	{
		/// <summary>
		/// Returns number of elements in given queue.
		/// </summary>
		public int Count
		{
			get => _size;
		}

		#region Private fields
		private const int DefaultCapacity = 4;

		private T[] _elementsArray;
		private int _head;
		private int _tail;
		private int _size;
		private int _version;
		#endregion

		/// <summary>
		/// Initialize new queue object.
		/// </summary>
		public Queue()
		{
			_elementsArray = new T[DefaultCapacity];
		}

		/// <summary>
		/// Initialize new queue object with start capacity.
		/// </summary>
		/// <param name="capacity">Start capacity of queue.</param>
		/// <exception cref="ArgumentException"></exception>
		public Queue(int capacity)
		{
			if (capacity < 0)
				throw new ArgumentException("Non negative number expected.", nameof(capacity));

			_elementsArray = new T[capacity];
			_head = 0;
			_tail = 0;
			_size = 0;
		}

		/// <summary>
		/// Initialize new queue object with given elements.
		/// </summary>
		/// <param name="source">Elements for filling new queue object.</param>
		/// <exception cref="ArgumentNullException">Throws when given source is null.</exception>
		public Queue(IEnumerable<T> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source), "Value can not be undefined.");

			_elementsArray = new T[DefaultCapacity];

			foreach (var element in source)
			{
				Enqueue(element);
			}
		}

		/// <summary>
		/// Adds element to the tail of the queue.
		/// </summary>
		/// <param name="element">Element for adding.</param>
		public void Enqueue(T element)
		{
			if (_size == _elementsArray.Length)
			{
				Array.Resize(ref _elementsArray, _size * 2);
			}

			_elementsArray[_tail] = element;
			_tail++;
			_size++;
			_version++;
		}

		/// <summary>
		/// Removes element from the head of the queue and returns it.
		/// </summary>
		/// <returns>The tail element in the queue.</returns>
		/// <exception cref="InvalidOperationException">Throws when the queue is empty.</exception>
		public T Dequeue()
		{
			if (_size == 0)
				throw new InvalidOperationException("Queue is empty.");

			T element = _elementsArray[_head];
			_elementsArray[_head] = default(T);
			_head++;
			_size--;
			_version++;

			return element;
		}

		/// <summary>
		/// Returns the tail element of the queue without removing it.
		/// </summary>
		/// <returns>The tail element of the queue.</returns>
		/// <exception cref="InvalidOperationException">Throws when the queue is empty.</exception>
		public T Peek()
		{
			if (_size == 0)
				throw new InvalidOperationException("Queue is empty.");

			return _elementsArray[_head];
		}
		private T this[int i]
		{
			get => _elementsArray[i];
		}

		/// <summary>
		/// Returns an enumerator for this queue.
		/// </summary>
		/// <returns>Returns an enumerator for this queue.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new QueueEnumerator(this);
		}

		/// <summary>
		/// Returns an enumerator for this queue.
		/// </summary>
		/// <returns>Returns an enumerator for this queue.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new QueueEnumerator(this);
		}

		/// <summary>
		/// Implements an enumerator for a queue.
		/// </summary>
		public struct QueueEnumerator : IEnumerator<T>
		{
			/// <summary>
			/// Gives current queue element.
			/// </summary>
			/// <exception cref="InvalidOperationException">Throws when out of bounds.</exception>
			public T Current
			{
				get
				{
					if (_index == -1 || _index == _queue.Count)
					{
						throw new InvalidOperationException("Out of range.");
					}

					return _queue[_index];
				}
			}

			object IEnumerator.Current => Current;

			#region Private fields

			private Queue<T> _queue;
			private int _index;
			private int _version;

			#endregion

			public QueueEnumerator(Queue<T> queue)
			{
				_queue = queue;
				_index = queue._head - 1;
				_version = queue._version;
			}

			/// <summary>
			/// Implements moving through queue elements.
			/// </summary>
			/// <returns>True if there elements in queue.</returns>
			/// <exception cref="InvalidOperationException">Throws when queue was changed.</exception>
			public bool MoveNext()
			{
				if (_queue._version != _version)
					throw new InvalidOperationException("Queue was changed.");

				_index++;
				return _index < _queue.Count;
			}

			/// <summary>
			/// Resets index of enumerator to the beginning.
			/// </summary>
			public void Reset() => _index = -1;

			/// <summary>
			/// Dispose enumerator after usage.
			/// </summary>
			public void Dispose() => Reset();
		}
	}
}