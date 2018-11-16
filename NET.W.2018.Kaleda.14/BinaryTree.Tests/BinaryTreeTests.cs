using System;
using NUnit.Framework;
using BinaryTree;
using System.Linq;
using Books.Entities;

namespace BinaryTree.Tests
{
	[TestFixture]
	public class BinaryTreeTests
	{
		#region Tests for System.Int32
		[TestCase(new int[] { 5, 1, 10, 7, 15 }, ExpectedResult = new int[] { 5, 1, 10, 7, 15 })]
		public int[] PreOrder_IntTreeWithDefaultComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>();
			foreach (int i in source)
				tree.Insert(i);

			return tree.PreOrder().ToArray();
		}

		[TestCase(new int[] { 5, 1, 2, 4, 3 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
		public int[] InOrder_IntTreeWithDefaultComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>();
			foreach (int i in source)
				tree.Insert(i);

			return tree.InOrder().ToArray();
		}

		[TestCase(new int[] { 5, 1, 2, 4, 3 }, ExpectedResult = new int[] { 3, 4, 2, 1, 5 })]
		public int[] PostOrder_IntTreeWithDefaultComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>();
			foreach (int i in source)
				tree.Insert(i);

			return tree.PostOrder().ToArray();
		}

		[TestCase(new int[] { 5, -1, 10, 7, -15 }, ExpectedResult = new int[] { 5, -1, 10, 7, -15 })]
		public int[] PreOrder_IntTreeWithCustomComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>(intComparison);
			foreach (int i in source)
				tree.Insert(i);

			return tree.PreOrder().ToArray();
		}

		[TestCase(new int[] { -5, -1, 2, 4, 3 }, ExpectedResult = new int[] { -1, 2, 3, 4, -5 })]
		public int[] InOrder_IntTreeWithCustomComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>(intComparison);
			foreach (int i in source)
				tree.Insert(i);

			return tree.InOrder().ToArray();
		}

		[TestCase(new int[] { -5, -1, 2, 4, 3 }, ExpectedResult = new int[] { 3, 4, 2, -1, -5 })]
		public int[] PostOrder_IntTreeWithCustomComparer_ValidResult(int[] source)
		{
			var tree = new BinaryTree<int>(intComparison);
			foreach (int i in source)
				tree.Insert(i);

			return tree.PostOrder().ToArray();
		}

		[TestCase(new int[] { 1, 5, 2, 4, 3 })]
		[TestCase(new int[] { 3, 7, 1, 2 })]
		public void Find_IntExistingElement_True(int[] source)
		{
			var tree = new BinaryTree<int>();
			foreach (int i in source)
				tree.Insert(i);
			Assert.That(tree.Find(1), Is.EqualTo(true));
		}

		[TestCase(new int[] { 5, 2, 4, 3 })]
		[TestCase(new int[] { 3, 7, 2 })]
		public void Find_IntNonExistingElement_False(int[] source)
		{
			var tree = new BinaryTree<int>();
			foreach (int i in source)
				tree.Insert(i);
			Assert.That(tree.Find(1), Is.EqualTo(false));
		}
		#endregion

		#region System.String tests
		[Test]
		public void Find_StringWithDefaultComparerExistingElement_True()
		{
			var tree = new BinaryTree<string>();
			var source = new string[] { "bb", "cc", "aa", "dd" };
			foreach (string i in source)
				tree.Insert(i);
			Assert.That(tree.Find("cc"), Is.EqualTo(true));
		}

		[Test]
		public void Find_StringWithCustomComparerExistingElement_True()
		{
			var tree = new BinaryTree<string>(stringComparison);
			var source = new string[] { "bb", "cc", "aa", "dd" };
			foreach (string i in source)
				tree.Insert(i);
			Assert.That(tree.Find("CC"), Is.EqualTo(true));
		}
		#endregion

		#region Book tests
		[Test]
		public void Find_BookWithDefaultComparerExistingElement_True()
		{
			var tree = new BinaryTree<Book>();
			var source = new Book[] 
			{
				new Book() { Title = "atitle" },
				new Book() { Title = "ctitle" },
				new Book() { Title = "btitle" }
			};
			foreach (var i in source)
				tree.Insert(i);
			Assert.That(tree.Find(new Book() { Title = "ctitle" }), Is.EqualTo(true));
		}

		[Test]
		public void Find_BookWithCustomComparerExistingElement_True()
		{
			var tree = new BinaryTree<Book>(bookComparison);
			var source = new Book[]
			{
				new Book() { Price = 50 },
				new Book() { Price = 15},
				new Book() { Price = 100 }
			};
			foreach (var i in source)
				tree.Insert(i);
			Assert.That(tree.Find(new Book() { Price = 100 }), Is.EqualTo(true));
		}
		#endregion

		public static Comparison<int> intComparison = (x, y) =>
		{
			x = Math.Abs(x);
			y = Math.Abs(y);

			if (x < y)
				return -1;

			else if (x > y)
				return 0;

			else return 0;
		};

		public static Comparison<string> stringComparison = (x, y) =>
		{
			x = x.ToUpper();
			y = y.ToUpper();

			if (x.CompareTo(y) < 0)
				return -1;

			else if (x.CompareTo(y) > 0)
				return 0;

			else return 0;
		};

		public static Comparison<Book> bookComparison = (x, y) =>
		{
			return x.Price.CompareTo(y.Price);
		};

	}
}
