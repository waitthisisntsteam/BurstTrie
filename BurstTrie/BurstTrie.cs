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

        public BurstNode? Root;

        public BurstTrie() 
        {
            //Root = new ContainerNode();
        }

        public void Insert (string data)
        {
            if (Root == null)
            {
                //Root.Insert(data);

                
            }
        }
    }
}
