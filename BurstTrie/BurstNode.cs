using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public abstract class BurstNode
    {
        public abstract int Count { get; }

        internal BurstTrie ParentTrie;        
        protected BurstNode(BurstTrie parent) => ParentTrie = parent;

        public abstract BurstNode Insert(string value, int index);
        public abstract BurstNode? Remove(string value, int index, out bool success);
        public abstract BurstNode? Search(string prefix, int index);    
        internal abstract void GetAll();
    }
}
