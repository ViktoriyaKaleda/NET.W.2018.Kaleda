using System.Runtime.CompilerServices;

namespace BinaryTree
{
	/// <summary>
	/// Represents node of the binary search tree.
	/// </summary>
	internal class Node<T>
	{
		public T element;
		public Node<T> left;
		public Node<T> right;

		public Node(T element)
			=> this.element = element;
	}
}