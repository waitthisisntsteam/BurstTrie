using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class BST<T> where T : IComparable<T>
    {
        public BSTNode<T>? Root;
        public int Count { get; private set; }

        public void Insert(T data)
        {
            var temp = new BSTNode<T>(data);
            if (Count == 0)
            {
                Root = temp;
                Count++;
                return;
            }
            else
            {
                var current = Root;
                while (true)
                {
                    if (temp.Data.CompareTo(current.Data) == 1)
                    {
                        if (current.Right == null)
                        {
                            current.Right = temp;
                            current.Right.Parent = current;
                            Count++;
                            return;
                        }
                        else current = current.Right;
                    }
                    else if (temp.Data.CompareTo(current.Data) == -1)
                    {
                        if (current.Left == null)
                        {
                            current.Left = temp;
                            current.Left.Parent = current;
                            Count++;
                            break;
                        }
                        else current = current.Left;
                    }
                    else throw new Exception("Can not enter a duplicate.");
                }
            }
        }

        public BSTNode<T>? Search(T data)
        {
            var current = Root;
            while (current != null)
            {
                int comparison = data.CompareTo(current.Data);
                if (comparison == 0) return current;
                else if (comparison < 0) current = current.Left;
                else current = current.Right;
            }
            return null;
        }

        public bool IsRightChild(BSTNode<T> node)
        {
            if (node.Parent == null) return false;
            return node.Parent.Right == node;
        }
        public bool IsRightChild(T data)
        {
            var current = Search(data);
            if (current.Parent == null) return false;
            if (current.Parent.Right == current) return true;
            return false;
        }
        public bool IsLeftChild(T data)
        {
            var current = Search(data);
            if (current.Parent == null) return false;
            if (current.Parent.Left == current) return true;
            return false;
        }

        public bool Remove(T data, out BSTNode<T>? removedNode)
        {
            BSTNode<T>? current = Search(data);
            BSTNode<T>? foundRemoved = null;

            if (Count == 0)
            {
                removedNode = null;
                return false;
            }
            else if (current == null)
            {
                removedNode = null;
                return false;
            }

            if (current.ChildCount == 2)
            {
                BSTNode<T>? candidateNode = GetMinimum(current.Right);
                foundRemoved = new BSTNode<T>(current.Data);
                current.Data = candidateNode.Data;
                current = candidateNode;
            }

            if (current.ChildCount == 0)
            {
                Count--;

                if (current == Root)
                {
                    removedNode = Root;
                    Root = null;
                    Count = 0;
                    return true;
                }

                if (IsRightChild(current))
                {
                    if (foundRemoved != null) removedNode = foundRemoved;
                    else removedNode = current.Parent.Right;
                    current.Parent.Right = null;
                    return true;
                }

                if (foundRemoved != null) removedNode = foundRemoved;
                else removedNode = current.Parent.Left;
                current.Parent.Left = null;
                return true;
            }
            else if (current.ChildCount == 1)
            {
                BSTNode<T>? child = current.Left;
                 
                if (child == null) child = current.Right;
                if (current == Root) Root = child;
                else if (IsRightChild(current)) current.Parent.Right = child;
                else current.Parent.Left = child;

                removedNode = child.Parent;
                child.Parent = current.Parent;
                Count--;
                return true;
            }

            removedNode = null;
            return false;
        }

        private BSTNode<T> GetMinimum(BSTNode<T> node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }
    }
}