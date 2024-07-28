using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public BurstNode[]? Buckets;

        public override int Count 
        {  
            get 
            {
                int counter = 0;
                for (int i = 0; i < Buckets.Length; i++)
                {
                    if (Buckets[i] != null && Buckets[i].Count > 0) counter++; 
                }
                return counter; 
            } 
        }

        public InternalNode (BurstTrie parentTrie, ContainerNode previousContainer, int index)
            : base (parentTrie)
        {
            ParentTrie = parentTrie;

            Buckets = new BurstNode[27];

            if (previousContainer != null)
            {
                while (previousContainer.Count > 0)
                {
                    bool removed = false;
                    string removedWord = previousContainer.Container.Root.Data;

                    BurstNode? removedBurstNode = previousContainer.Remove(removedWord, index, out removed);

                    if (removed)
                    {
                        int bucketIndex = index - 96;
                        if (Buckets[bucketIndex] == null) Buckets[bucketIndex] = removedBurstNode;
                        else Buckets[bucketIndex].Insert(removedWord, index);
                    }
                }
            }
        }

        public override BurstNode Insert(string value, int index)
        {
            int bucketIndex = index- 96;

            if (Buckets[bucketIndex] == null)
            {
                ContainerNode containerNode = new ContainerNode(ParentTrie);
                containerNode.Insert(value, index);

                Buckets[bucketIndex] = containerNode;
            }
            else Buckets[bucketIndex].Insert(value, index);

            return this;
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            int bucketIndex = index- 96;

            if (Buckets[bucketIndex] != null)
            {
                bool removed = false;
                var removedNode = Buckets[bucketIndex].Remove(value, index, out removed);

                success = removed;
                return removedNode;
            }

            success = false;
            return null;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll()
        {
        }
    }
}
