using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
	/// <summary>
	/// Class that represents binary search tree.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BinaryTree<T> : IEnumerable<T>
	{
		/// <summary>
		/// Returns true if tree is empty, else false.
		/// </summary>
		public bool IsEmpty
		{
			get => Root == null;
		}

		#region Private fields

		private Node<T> Root { get; set; }
		private readonly Comparison<T> _comparison;

		#endregion

		/// <summary>
		/// Initialize new binary tree object.
		/// </summary>
		public BinaryTree()
		{
			_comparison = Comparer<T>.Default.Compare;
		}

		/// <summary>
		/// Initialize new binary tree object with given comparer.
		/// </summary>
		/// <param name="comparer">The comparer.</param>
		public BinaryTree(IComparer<T> comparer)
		{
			_comparison = comparer.Compare;
		}

		/// <summary>
		/// Initialize new binary tree object with given comparison.
		/// </summary>
		/// <param name="comparison">The comparison</param>
		public BinaryTree(Comparison<T> comparison)
		{
			_comparison = comparison;
		}

		/// <summary>
		/// Returns true if the tree contains given element, else false.
		/// </summary>
		/// <param name="element">The element for search.</param>
		/// <returns>Returns true if the tree contains given element, else false.</returns>
		/// <exception cref="ArgumentNullException">Throws when given element is null.</exception>
		public bool Find(T element)
		{
			if (element == null)
				throw new ArgumentNullException(nameof(element), "Value can not be undefined.");

			return FindElement(Root, element);
		}

		/// <summary>
		/// Insert new element in the tree.
		/// </summary>
		/// <param name="element">The element for inserting.</param>
		public void Insert(T element)
		{
			if (IsEmpty)
			{
				Root = new Node<T>(element);
			}
			else
			{
				var root = Root;
				InsertElement(ref root, element);
			}
		}

		/// <summary>
		/// Traverse tree in order.
		/// </summary>
		/// <returns>IEnumerable of tree elements in order.</returns>
		public IEnumerable<T> InOrder()
			=> Traverse(TraverseInOrder);

		/// <summary>
		/// Traverse tree pre order.
		/// </summary>
		/// <returns>IEnumerable of tree elements pre order.</returns>
		public IEnumerable<T> PreOrder()
			=> Traverse(TraversePreOrder);

		/// <summary>
		/// Traverse tree post order.
		/// </summary>
		/// <returns>IEnumerable of tree elements post order.</returns>
		public IEnumerable<T> PostOrder()
			=> Traverse(TraversePostOrder);

		/// <summary>
		/// Returns tree enumerator object that traverse in order.
		/// </summary>
		/// <returns>Tree enumerator object that traverse in order.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			foreach (T element in InOrder())
			{
				yield return element;
			}
		}

		/// <summary>
		/// Returns tree enumerator object that traverse in order.
		/// </summary>
		/// <returns>Tree enumerator object that traverse in order.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Private methods

		/// <summary>
		/// Returns true if the tree contains given element, else false.
		/// </summary>
		/// <param name="root">The root of the tree.</param>
		/// <param name="element">The element for search.</param>
		/// <returns>Returns true if the tree contains given element, else false.</returns>
		private bool FindElement(Node<T> root, T element)
		{
			if (root == null)
				return false;

			if (_comparison.Invoke(root.element, element) == 0)
				return true;

			else if (_comparison.Invoke(root.element, element) < 0)
				return FindElement(root.right, element);

			else if (_comparison.Invoke(root.element, element) > 0)
				return FindElement(root.left, element);

			return false;
		}

		/// <summary>
		/// Inserts element in the tree.
		/// </summary>
		/// <param name="root">The root of the tree.</param>
		/// <param name="element">The element to insert.</param>
		private void InsertElement(ref Node<T> root, T element)
		{
			if (root == null)
			{
				root = new Node<T>(element);
				return;
			}

			if (_comparison.Invoke(element, root.element) < 0)
				InsertElement(ref root.left, element);

			else
				InsertElement(ref root.right, element);
		}

		/// <summary>
		/// Returns IEnumerable of tree elements.
		/// </summary>
		/// <param name="traversalType">The delegate that implements traverse.</param>
		/// <returns>IEnumerable of tree elements.</returns>
		private IEnumerable<T> Traverse(Func<Node<T>, IEnumerable<Node<T>>> traversalType)
		{
			IEnumerable<Node<T>> traversal = traversalType.Invoke(Root);
			foreach (Node<T> node in traversal)
			{
				yield return node.element;
			}
		}

		/// <summary>
		/// Implementation of in order traverse.
		/// </summary>
		/// <param name="root">The root of the tree.</param>
		/// <returns>IEnumerable of tree nodes.</returns>
		private IEnumerable<Node<T>> TraverseInOrder(Node<T> root)
		{
			if (root == null)
				yield break;

			if (root.left != null)
				foreach (Node<T> node in TraverseInOrder(root.left))
					yield return node;

			yield return root;

			if (root.right != null)
				foreach (Node<T> node in TraverseInOrder(root.right))
					yield return node;
		}

		/// <summary>
		/// Implementation of pre order traverse.
		/// </summary>
		/// <param name="root">The root of the tree.</param>
		/// <returns>IEnumerable of tree nodes.</returns>
		private IEnumerable<Node<T>> TraversePreOrder(Node<T> root)
		{
			if (root == null)
				yield break;

			yield return root;

			if (root.left != null)
				foreach (Node<T> node in TraversePreOrder(root.left))
					yield return node;

			if (root.right != null)
				foreach (Node<T> node in TraversePreOrder(root.right))
					yield return node;
		}

		/// <summary>
		/// Implementation of post order traverse.
		/// </summary>
		/// <param name="root">The root of the tree.</param>
		/// <returns>IEnumerable of tree nodes.</returns>
		private IEnumerable<Node<T>> TraversePostOrder(Node<T> root)
		{
			if (root == null)
				yield break;

			if (root.left != null)
				foreach (Node<T> node in TraversePostOrder(root.left))
					yield return node;


			if (root.right != null)
				foreach (Node<T> node in TraversePostOrder(root.right))
					yield return node;

			yield return root;
		}

		#endregion
	}
}