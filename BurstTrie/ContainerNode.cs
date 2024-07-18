using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class ContainerNode : BurstNode
    {
        public BST<string> Container;
        private int Capacity;

        public override int Count { get { return Container.Count; } }

        public ContainerNode(BST<string>container, int capacity, BurstTrie parentTrie) 
            : base(parentTrie)
        {
            Container = container;
            Capacity = capacity;
            ParentTrie = parentTrie;
        }

        public override BurstNode Insert (string data, int index)
        {
            if (Count <= 5)
            {
                Container.Insert(data);
            }
            else
            {
                //create internal node
            }

            return this;
        }

        public override BurstNode? Remove(string data, int index, out bool removed )
        {
            BSTNode<string>? removedNode = null;

            removed = Container.Remove(data, out removedNode);

            return default;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            return default;
        }

        internal override void GetAll()
        {

        }
    }
}
