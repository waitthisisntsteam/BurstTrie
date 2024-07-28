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

        public override int Count => Container.Count;

        public ContainerNode(BurstTrie parentTrie) 
            : base(parentTrie)
        {
            Container = new BST<string>();
            ParentTrie = parentTrie;
        }

        public override BurstNode Insert (string data, int index)
        {
            if (Count < ParentTrie.ContainerCapacity) Container.Insert(data);
            if (Count >= ParentTrie.ContainerCapacity) return new InternalNode(ParentTrie, this, index);

            return this;
        }

        public override BurstNode? Remove(string data, int index, out bool removed)
        {
            BSTNode<string>? removedBSTNode = null;
            removed = Container.Remove(data, out removedBSTNode);
            
            if (!removed) return null;

            var removedBurstNode = new ContainerNode(ParentTrie);
            removedBurstNode.Insert(removedBSTNode.Data, index);

            return removedBurstNode;
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
