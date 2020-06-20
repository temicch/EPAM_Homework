using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    internal class Node<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        public T Data { get; set; }
    }

    public class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public BinarySearchTree()
        {
            Count = 0;
            comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(IComparer<T> comparer) : this()
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public BinarySearchTree(IEnumerable<T> collection) : this(collection, null)
        {
        }

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (collection is ICollection<T> c)
            {
                var count = c.Count;
                if (count <= 0) return;
                foreach (var item in c)
                    Add(item);
            }
            else
            {
                using (var en = collection.GetEnumerator())
                {
                    while (en.MoveNext()) Add(en.Current);
                }
            }
        }

        private Node<T> Root { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(Root, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Need non negative num");

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Target array too small", nameof(arrayIndex));

            foreach (var item in this.AsEnumerable()) array[arrayIndex++] = item;
        }

        public bool Remove(T item)
        {
            var isNodeDeleted = false;
            var removeResult = Remove(Root, item, ref isNodeDeleted);
            Root = removeResult;
            return isNodeDeleted;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Node<T>>();
            var node = Root;

            PushToStack(node, stack);
            while (stack.Count > 0)
            {
                node = stack.Pop();

                if (node == null)
                    continue;

                yield return node.Data;
                node = node.RightNode;
                PushToStack(node, stack);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal static void PushToStack(Node<T> node, Stack<Node<T>> stack, bool inOrder = true)
        {
            while (node != null)
            {
                stack.Push(node);
                node = inOrder ? node.LeftNode : node.RightNode;
            }
        }

        /// <summary>Returns an enumerator that iterates over a collection in reverse order.</summary>
        /// <returns>An enumerator that can be used to iterate over a collection in reverse order.</returns>
        public IEnumerable<T> GetReversedEnumerator()
        {
            return new BSTReversedIterator(Root);
        }

        private Node<T> Remove(Node<T> parent, T item, ref bool isNodeDeleted)
        {
            if (parent == null)
                return parent;

            if (comparer.Compare(item, parent.Data) < 0)
            {
                parent.LeftNode = Remove(parent.LeftNode, item, ref isNodeDeleted);
            }
            else if (comparer.Compare(item, parent.Data) > 0)
            {
                parent.RightNode = Remove(parent.RightNode, item, ref isNodeDeleted);
            }
            else
            {
                Count--;
                isNodeDeleted = true;
                if (parent.LeftNode == null)
                    return parent.RightNode;
                if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data, ref isNodeDeleted);
            }

            return parent;
        }

        private static T MinValue(Node<T> node)
        {
            var minValue = node.Data;

            while (node.LeftNode != null)
            {
                minValue = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minValue;
        }

        private bool Find(Node<T> parent, T item)
        {
            if (parent != null)
            {
                if (comparer.Compare(parent.Data, item) == 0)
                    return true;
                if (comparer.Compare(parent.Data, item) < 0)
                    return Find(parent.LeftNode, item);
                return Find(parent.RightNode, item);
            }

            return false;
        }

        /// <summary>Adds an item to the <see cref="T:BinaryTree.BinarySearchTree`1" />.</summary>
        /// <param name="item">The object to add to the <see cref="T:BinaryTree.BinarySearchTree`1" />.</param>
        public void Add(T item)
        {
            Node<T> before = null, after = Root;

            while (after != null)
            {
                before = after;
                if (comparer.Compare(after.Data, item) > 0)
                    after = after.LeftNode;
                else if (comparer.Compare(after.Data, item) < 0)
                    after = after.RightNode;
                else
                    return;
            }

            var newNode = new Node<T>
            {
                Data = item
            };

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                if (comparer.Compare(before.Data, item) > 0)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            Count++;
        }

        private class BSTReversedIterator : IEnumerator<T>, IEnumerable<T>
        {
            private readonly Stack<Node<T>> stack;
            private Node<T> currentItem;

            public BSTReversedIterator(Node<T> root)
            {
                stack = new Stack<Node<T>>();

                PushToStack(root, stack, false);
            }

            public T Current => currentItem.Data;
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (stack.Count == 0)
                    return false;

                var node = stack.Pop();
                if (node == null)
                    return false;

                PushToStack(node.LeftNode, stack, false);

                currentItem = node;
                return true;
            }

            #region Unused methods

            public void Dispose()
            {
            }

            public void Reset()
            {
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }

            #endregion
        }
    }
}