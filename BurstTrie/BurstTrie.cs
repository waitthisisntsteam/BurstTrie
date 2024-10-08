﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

        public BurstTrie(int containerCapacity) 
        {
            ContainerCapacity = containerCapacity;
            Root = new ContainerNode(this);
        }

        public void Insert (string data) => Root = Root.Insert(data, 0);

        public bool Remove (string data) 
        { 
            bool removed = false;
            Root.Remove(data, 0, out removed); 
            return removed;
        }

        public BurstNode? Search (string data) => Root.Search(data, 0);

        public List<string> GetAll() => Root.GetAll();

        public List<string> BurstSort (List<string> input)
        {
            BurstTrie burstTrie = new(ContainerCapacity);

            foreach (string s in input) 
            {
                burstTrie.Insert(s);
            }

            return burstTrie.GetAll();
        }
    }
}
