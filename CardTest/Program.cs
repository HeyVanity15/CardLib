using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace CardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck(true, shuffle: true);

            foreach (Card c in deck)
            {
                Console.WriteLine(c.ToString());
            }

            Console.Read();
        }
    }
}
