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

        private int GetBucketIndex (string value, int index)
        {
            if (index < value.Length)
            {
                int bucketIndex = value[index] - 96;
                if (bucketIndex < 0) throw new Exception("Bucket Index out of range.");
                return bucketIndex;
            }
            return 0;
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
                        int bucketIndex = GetBucketIndex(removedWord, index);
                        if (Buckets[bucketIndex] == null) Buckets[bucketIndex] = removedBurstNode;
                        else Buckets[bucketIndex] = Buckets[bucketIndex].Insert(removedWord, index + 1);
                    }
                }
            }
        }

        public override BurstNode Insert(string value, int index)
        {
            int bucketIndex = GetBucketIndex(value, index);

            if (Buckets[bucketIndex] == null) Buckets[bucketIndex] = new ContainerNode(ParentTrie);
            Buckets[bucketIndex] = Buckets[bucketIndex].Insert(value, index + 1);

            return this;
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            int bucketIndex = GetBucketIndex(value, index);

            if (Buckets[bucketIndex] != null)
            {
                bool removed = false;
                var removedNode = Buckets[bucketIndex].Remove(value, index + 1, out removed);

                success = removed;
                return removedNode;
            }

            success = false;
            return null;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            BurstNode? searchedNode = null;

            foreach (var n in Buckets)
            {
                if (n != null)
                {
                    searchedNode = n.Search(prefix, index);
                    if (searchedNode != null) break;
                }
            }

            return searchedNode;
        }

        internal override List<string> GetAll()
        {
            List<string> words = new List<string>();
            foreach (var n in Buckets)
            {
                if (n != null) words.AddRange(n.GetAll());
            }
            return words;
        }
    }
}
