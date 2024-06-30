using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class ContainerNode
    {
        public BST<string> Container;
        private int Capacity;

        public ContainerNode(BST<string>container, int capacity) 
        {
            Container = container;
            Capacity = capacity; 
        }

        public void Insert (string data)
        {
            Container.Insert(data);

            if (Container.Count > 5)
            {

            }
        }
        public void Remove(string data)
        {
            Container.Remove(data);
        }
    }
}
