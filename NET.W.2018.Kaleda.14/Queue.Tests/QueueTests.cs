using System;
using NUnit.Framework;
using Queue;

namespace Queue.Tests
{
	[TestFixture]
	public class QueueTests
	{
		public static int[] source = { 4, 1, 2, 6, 7, 9, 3, 10, 0, 8 };

		[Test]
		public void Count_ConstructorWithSourceItems_ElementsCount()
		{
			var queue = new Queue<int>(source);
			Assert.That(queue.Count, Is.EqualTo(10));
		}

		[Test]
		public void Queue_EnqueueDequeuePeekValues_ValidResult()
		{
			var queue = new Queue<int>();
			foreach (int i in source)
				queue.Enqueue(i);

			Assert.That(queue.Dequeue(), Is.EqualTo(4));
			Assert.That(queue.Dequeue(), Is.EqualTo(1));
			Assert.That(queue.Peek(), Is.EqualTo(2));
			Assert.That(queue.Peek(), Is.EqualTo(2));
		}

		[Test]
		public void Queue_IteratoinOnElements_ValidResult()
		{
			var queue = new Queue<int>(source);

			int i = 0;
			foreach(int item in queue)
			{
				Assert.That(item == source[i]);
				i++;
			}
		}
	}
}
