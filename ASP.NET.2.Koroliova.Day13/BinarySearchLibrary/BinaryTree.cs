using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLibrary
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        #region Fields
        private T Data { get; set; }
        private BinaryTree<T> Left { get; set; }
        private BinaryTree<T> Right { get; set; }
        private BinaryTree<T> Parent { get; set; }
        private Comparer<T> comparer;
        #endregion

        #region Ctors

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
            if (!DefaultComparerValidator())
                throw new ArgumentException("This type isn't comparable");
        }

        public BinaryTree(IEnumerable<T> collection)
            : this()
        {
            TreeInitializer(collection);
        }

        public BinaryTree(Comparison<T> comparison)
        {
            ComparisonInitializer(comparison);
        }
         public BinaryTree(IComparer<T> comparer)
        {
            ComparerInitializer(comparer);
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="comparison"></param>
        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            ComparisonInitializer(comparison);
            TreeInitializer(collection);
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="comparer"></param>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            ComparerInitializer(comparer);
            TreeInitializer(collection);
        }
        #endregion
        #region Public Methods
        public void Insert(T data)
        {
            if (Data == null || Data.Equals(data))
            {
                Data = data;
                return;
            }
            if (comparer.Compare(Data,data) > 0)
            {
                if (Left == null) Left = new BinaryTree<T>();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree<T>();
                Insert(data, Right, this);
            }
        }
        /// <summary>
        /// Find data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTree<T> Find(T data)
        {
            if (comparer.Compare(Data, data) == 0) return this;
            if (comparer.Compare(Data, data) > 0)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }
        /// <summary>
        /// Find data in some tree
        /// </summary>
        /// <param name="data"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTree<T> Find(T data, BinaryTree<T> node)
        {
            if (node == null) return null;

            if (comparer.Compare(node.Data,data) == 0) return node;
            if (comparer.Compare(node.Data, data) > 0)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }
        /// <summary>
        /// Remove node
        /// </summary>
        /// <param name="node"></param>
        public void Remove(BinaryTree<T> node)
        {
            if (node == null) return;
            var me = MeForParent(node);

            if (node.Left == null && node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }

            if (node.Left == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }
            if (node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }


            if (me == BinSide.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == BinSide.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }
        /// <summary>
        /// Remote data
        /// </summary>
        /// <param name="data">Remoting data</param>
        public void Remove(T data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }
        public long CountElements()
        {
            return CountElements(this);
        }
        #region IEnumerotors
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderEnum().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrderEnum()
        {
            return PreOrderEnum(this);
        }

        public IEnumerable<T> InOrderEnum()
        {
            return InOrderEnum(this);
        }
        public IEnumerable<T> PostOrderEnum()
        {
            return PostOrderEnum(this);
        }
        #endregion

        #region Private Methods
        private BinaryTree<T> Minimum(BinaryTree<T> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        private BinaryTree<T> Maximum(BinaryTree<T> node)
        {
            while (node.Right != null)
                node = node.Right;
            return node;
        }
        private IEnumerable<T> PreOrderEnum(BinaryTree<T> node)
        {
            if (!ReferenceEquals(node, null))
            {
                yield return node.Data;
                foreach (var item in PreOrderEnum(node.Left))
                    yield return item;
                foreach (var item in PreOrderEnum(node.Right))
                    yield return item;
            }
        }

        private IEnumerable<T> InOrderEnum(BinaryTree<T> node)
        {
            if (!ReferenceEquals(node, null))
            {
                foreach (var item in InOrderEnum(node.Left))
                    yield return item;
                yield return node.Data;
                foreach (var item in InOrderEnum(node.Right))
                    yield return item;
            }
        }

        private IEnumerable<T> PostOrderEnum(BinaryTree<T> node)
        {
            if (!ReferenceEquals(node, null))
            {
                foreach (var item in PostOrderEnum(node.Left))
                    yield return item;
                foreach (var item in PostOrderEnum(node.Right))
                    yield return item;
                yield return node.Data;
            }
        }
        #endregion
        
        private void Insert(T data, BinaryTree<T> node, BinaryTree<T> parent)
        {
            if (node.Data == null || comparer.Compare(node.Data, data) == 0)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (comparer.Compare(node.Data, data) > 0)
            {
                if (node.Left == null) node.Left = new BinaryTree<T>();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree<T>();
                Insert(data, node.Right, node);
            }
        }


        private void Insert(BinaryTree<T> data, BinaryTree<T> node, BinaryTree<T> parent)
        {

            if (node.Data == null || comparer.Compare(node.Data, data.Data) == 0)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (comparer.Compare(node.Data, data.Data) > 0)
            {
                if (node.Left == null) node.Left = new BinaryTree<T>();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree<T>();
                Insert(data, node.Right, node);
            }
        }
      
        private BinSide? MeForParent(BinaryTree<T> node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return BinSide.Left;
            if (node.Parent.Right == node) return BinSide.Right;
            return null;
        }



       
        private long CountElements(BinaryTree<T> node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += CountElements(node.Right);
            }
            if (node.Left != null)
            {
                count += CountElements(node.Left);
            }
            return count;
        }


        #region Initialisation
        private void TreeInitializer(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            foreach (var item in collection)
                Insert(item);
        }

        private bool DefaultComparerValidator()
        {
            return typeof(T).GetInterfaces().Contains(typeof(IComparable<T>));
        }

        private void ComparisonInitializer(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            comparer = Comparer<T>.Create(comparison);
        }

        private void ComparerInitializer(IComparer<T> ourComparer)
        {
            if (ourComparer == null)
                throw new ArgumentNullException("ourComparer");
            this.comparer = Comparer<T>.Create(ourComparer.Compare);
        }
        #endregion
        #endregion
    }
}
