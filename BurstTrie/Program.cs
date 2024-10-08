﻿namespace BurstTrie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BurstTrie burstTrie = new(5);

            burstTrie.Insert("bob");
            burstTrie.Insert("bill");
            burstTrie.Insert("a");
            burstTrie.Insert("adam");
            burstTrie.Insert("screen"); //burst

            burstTrie.Insert("abe");
            burstTrie.Insert("ace");
            burstTrie.Insert("aces"); //burst

            burstTrie.Insert("bobbies");
            burstTrie.Insert("bobb");
            burstTrie.Insert("bobs");
            burstTrie.Insert("bobby"); //burst

            var b = burstTrie.Search("bobby");
            var words = burstTrie.GetAll();

            List<string> wordsToBeSorted= new List<string>();
            wordsToBeSorted.Add("bob");
            wordsToBeSorted.Add("abe");
            wordsToBeSorted.Add("ace");
            wordsToBeSorted.Add("bobby");
            wordsToBeSorted.Add("lee");


            var burstSort = burstTrie.BurstSort(wordsToBeSorted);

            Console.ReadKey();
        }
    }
}
