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
        //public T Data { get; set; }
        //public BinaryTree<T> Left { get; set; }
        //public BinaryTree<T> Right { get; set; }
        //public BinaryTree<T> Parent { get; set; }
        private BinaryTreeNode<T> head; 
        public Comparer<T> comparer;
        #endregion

        #region Ctors

        public BinaryTree()
        {
            
            if (!DefaultComparerValidator())
                throw new ArgumentException("This type isn't comparable");
            comparer = Comparer<T>.Default;
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
            if(data==null)
                throw new ArgumentNullException();
            //if (node.Data==null || node.Data.Equals(data))
            //{
            //    Data = data;
            //    return;
            //}
            //if (comparer.Compare(Data,data) > 0)
            //{
            //    if (Left == null) Left = new BinaryTree<T>();
            //    Insert(data, Left, this);
            //}
            //else
            //{
            //    if (Right == null) Right = new BinaryTree<T>();
            //    Insert(data, Right, this);
            //}
            
            BinaryTreeNode<T> newHead=new BinaryTreeNode<T>(data,null,null,null);
            Insert(newHead);
        }
        /// <summary>
        /// Find data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Find(T data)
        {
            if (comparer.Compare(head.Data, data) == 0) return head;
            if (comparer.Compare(head.Data, data) > 0)
            {
                return Find(data, head.Left);
            }
            return Find(data, head.Right);
        }
        /// <summary>
        /// Find data in some tree
        /// </summary>
        /// <param name="data"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Find(T data, BinaryTreeNode<T> node)
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
        public void Remove(BinaryTreeNode<T> node)
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
                //var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                node.Parent = node.Right;
                Insert(node);
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
            return CountElements(head);
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
            return PreOrderEnum(head);
        }

        public IEnumerable<T> InOrderEnum()
        {
            return InOrderEnum(head);
        }
        public IEnumerable<T> PostOrderEnum()
        {
            return PostOrderEnum(head);
        }
        #endregion

        #region Private Methods
        //private BinaryTreeNode<T> Minimum(BinaryTreeNode<T> node)
        //{
        //    while (node.Left != null)
        //        node = node.Left;
        //    return node;
        //}

        //private BinaryTreeNode<T> Maximum(BinaryTreeNode<T> node)
        //{
        //    while (node.Right != null)
        //        node = node.Right;
        //    return node;
        //}
        private IEnumerable<T> PreOrderEnum(BinaryTreeNode<T> node)
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

        private IEnumerable<T> InOrderEnum(BinaryTreeNode<T> node)
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

        private IEnumerable<T> PostOrderEnum(BinaryTreeNode<T> node)
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

        //private void Insert(BinaryTreeNode<T> newNode, T data)
        //{

        //    if(comparer.Compare(data,newNode.Data)<0)
        //        if(newNode.Left==null) newNode.Left=new BinaryTreeNode<T>(data,);
        //}
        private void Insert(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> tempParent = null;
            BinaryTreeNode<T> current = head;
            while (current != null)
            {
                tempParent = current;
                if (comparer.Compare(node.Data, current.Data) == -1)
                    current = current.Left;
                else
                    current = current.Right;
            }
            node.Parent = tempParent;
            if (tempParent == null)
                head = node;
            else if (comparer.Compare(node.Data, tempParent.Data) == -1)
                tempParent.Left = node;
            else
                tempParent.Right = node;
        }
        //private void Insert(T data, BinaryTree<T> node, BinaryTree<T> parent)
        //{
        //    if (node.Data == null || comparer.Compare(node.Data, data) == 0)
        //    {
        //        node.Data = data;
        //        node.Parent = parent;
        //        return;
        //    }
        //    if (comparer.Compare(node.Data, data) > 0)
        //    {
        //        if (node.Left == null) node.Left = new BinaryTree<T>();
        //        Insert(data, node.Left, node);
        //    }
        //    else
        //    {
        //        if (node.Right == null) node.Right = new BinaryTree<T>();
        //        Insert(data, node.Right, node);
        //    }
        //}


        //private void Insert(BinaryTreeNode<T> newNode)
        //{

        //    if (ReferenceEquals(node.Data,null) || comparer.Compare(node.Data, data.Data) == 0)
        //    {
        //        node.Data = data.Data;
        //        node.Left = data.Left;
        //        node.Right = data.Right;
        //        node.Parent = parent;
        //        return;
        //    }
        //    if (comparer.Compare(node.Data, data.Data) > 0)
        //    {
        //        if (node.Left == null) node.Left = new BinaryTree<T>();
        //        Insert(data, node.Left, node);
        //    }
        //    else
        //    {
        //        if (node.Right == null) node.Right = new BinaryTree<T>();
        //        Insert(data, node.Right, node);
        //    }
        //}
      
        private BinSide? MeForParent(BinaryTreeNode<T> node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return BinSide.Left;
            if (node.Parent.Right == node) return BinSide.Right;
            return null;
        }



       
        private long CountElements(BinaryTreeNode<T> node)
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
