using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public ContainerNode[] Buckets;

        public override int Count 
        {  
            get 
            {
                int counter = 0;
                for (int i = 0; i < Buckets.Length; i++)
                {
                    if (Buckets[i].Count > 0)
                    {
                        counter++;
                    }
                }
                return counter; 
            } 
        }

        public InternalNode (BurstTrie parentTrie)
            : base (parentTrie)
        {
            ParentTrie = parentTrie;

            //Buckets = [
            //    "NIL", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            //    ];
        }

        public override BurstNode Insert(string value, int index)
        {
            throw new NotImplementedException();
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            throw new NotImplementedException();
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
