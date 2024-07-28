namespace BurstTrie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BurstTrie burstTrie = new();

            burstTrie.Insert("bob", 'b');
            burstTrie.Insert("bill", 'b');
            burstTrie.Insert("a", 'a');
            burstTrie.Insert("adam", 'a');
            burstTrie.Insert("screen", 's');
            //burst

            burstTrie.Insert("abe", 'a');
            burstTrie.Insert("ace", 'a');
            burstTrie.Insert("aces", 'a' + 1);
            //burst

            ;
        }
    }
}
