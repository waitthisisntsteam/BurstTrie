using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{ 
    public class BSTNode<T>
    {
        public BSTNode<T>? Parent;
        public BSTNode<T>? Left;
        public BSTNode<T>? Right;
        public T Data;

        public BSTNode(T data)
        {
            Data = data;
        }

        public int ChildCount
        {
            get
            {
                int count = 0;
                if (Left != null) count++;
                if (Right != null) count++;
                return count;
            }
        }
    }
}