using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class BurstTrie
    {
        public int Count { get; set; }
        public int ContainerCapacity { get; set; }

        public BurstNode Root;

        public BurstTrie() 
        {
            ContainerCapacity = 5;
            Root = new ContainerNode(this);
        }

        public void Insert (string data)
        {
            Root = Root.Insert(data, 0);
        }

        public bool Remove (string data) 
        { 
            bool removed = false;
            Root.Remove(data, 0, out removed); 
            return removed;
        }
    }
}
