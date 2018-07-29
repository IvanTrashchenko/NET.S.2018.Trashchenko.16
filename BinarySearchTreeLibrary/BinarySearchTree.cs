using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Custom binary search tree class.
    /// </summary>
    /// <typeparam name="T">Type of tree element.</typeparam>
    public class BinarySearchTree<T>
    {
        #region Fields

        /// <summary>
        /// Comparer of tree elements.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Tree's root element.
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Field for tracking changes of the tree.
        /// </summary>
        private int version;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class with the specific comparer of type <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Thrown when comparer value is null.</exception>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class with the specific comparer of type <see cref="Comparison{T}"/>.
        /// </summary>
        /// <param name="comparison">The comparer delegate.</param>
        public BinarySearchTree(Comparison<T> comparison)
            : this(Comparer<T>.Create(comparison))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class with the help of <see cref="IEnumerable{T}"/> element."/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Thrown when comparer or collection value is null.</exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer = null)
            : this(comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can not be null.");
            }

            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class with the help of <see cref="IEnumerable{T}"/> element."/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparison">The comparer delegate.</param>
        /// <exception cref="ArgumentNullException">Thrown when collection value is null.</exception>
        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection, Comparer<T>.Create(comparison))
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets amount of elements in the tree.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Returns true if tree is empty; otherwise, false.
        /// </summary>
        public bool IsEmpty => this.Count == 0;

        #endregion

        #region Public methods

        /// <summary>
        /// Method which adds an element in the tree.
        /// </summary>
        /// <param name="element">Element to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when element value is null.</exception>
        public void Add(T element)
        {
            this.version++;

            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} can not be null.");
            }

            Node<T> node = new Node<T>(element);

            if (this.root == null)
            {
                this.root = node;
                this.Count++;
            }
            else
            {
                this.Grow(this.root, node);
            }
        }

        /// <summary>
        /// Method which clears tree's elements.
        /// </summary>
        public void Clear()
        {
            this.root = null;
            this.Count = 0;
            this.version++;
        }

        /// <summary>
        /// Method which determines whether the tree contains a specific element.
        /// </summary>
        /// <param name="element">Specific element.</param>
        /// <returns>True, if the tree contains the element; otherwise, false.</returns>
        public bool Contains(T element)
        {
            if (element == null)
            {
                return false; // ?
            }

            Node<T> current = this.root;

            while (current != null)
            {
                int comparisonResult = this.comparer.Compare(current.Value, element);

                if (comparisonResult == 0)
                {
                    return true;
                }

                current = comparisonResult > 0 ? current.Right : current.Left;
            }

            return false;
        }

        #endregion

        #region Tree Traversals

        /// <summary>
        /// InOrder traversal of the tree.
        /// </summary>
        /// <returns>InOrder <see cref="IEnumerable{T}"/> representation of the tree.</returns>
        public IEnumerable<T> InOrder() => this.InOrderMethod(this.root);

        /// <summary>
        /// PostOrder traversal of the tree.
        /// </summary>
        /// <returns>PostOrder <see cref="IEnumerable{T}"/> representation of the tree.</returns>
        public IEnumerable<T> PostOrder() => this.PostOrderMethod(this.root);

        /// <summary>
        /// PreOrder traversal of the tree.
        /// </summary>
        /// <returns>PreOrder <see cref="IEnumerable{T}"/> representation of the tree.</returns>
        public IEnumerable<T> PreOrder() => this.PreOrderMethod(this.root);

        #endregion

        #region Private methods

        private void Grow(Node<T> head, Node<T> @new)
        {
            int comparisonResult = this.comparer.Compare(head.Value, @new.Value);

            if (comparisonResult < 0)
            {
                if (head.Left == null)
                {
                    head.Left = @new;
                    this.Count++;
                }
                else
                {
                    this.Grow(head.Left, @new);
                }
            }
            else if (comparisonResult >= 0)
            {
                if (head.Right == null)
                {
                    head.Right = @new;
                    this.Count++;
                }
                else
                {
                    this.Grow(head.Right, @new);
                }
            }
        }

        private IEnumerable<T> InOrderMethod(Node<T> node)
        {
            int tempVersion = this.version;

            if (node.Left != null)
            {
                foreach (T element in this.InOrderMethod(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (T element in this.InOrderMethod(node.Right))
                {
                    yield return element;
                }
            }

            if (this.version != tempVersion)
            {
                throw new InvalidOperationException("Tree was changed.");
            }
        }

        private IEnumerable<T> PostOrderMethod(Node<T> node)
        {
            int tempVersion = this.version;

            if (node.Left != null)
            {
                foreach (T element in this.PostOrderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in this.PostOrderMethod(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Value;

            if (this.version != tempVersion)
            {
                throw new InvalidOperationException("Tree was changed.");
            }
        }

        private IEnumerable<T> PreOrderMethod(Node<T> node)
        {
            int tempVersion = this.version;

            yield return node.Value;

            if (node.Left != null)
            {
                foreach (T element in this.PreOrderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in this.PreOrderMethod(node.Right))
                {
                    yield return element;
                }
            }

            if (this.version != tempVersion)
            {
                throw new InvalidOperationException("Tree was changed.");
            }
        }

        #endregion

        #region Node class

        /// <summary>
        /// Class of tree's node.
        /// </summary>
        /// <typeparam name="T">Type of tree element.</typeparam>
        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public T Value { get; }
        }

        #endregion
    }
}