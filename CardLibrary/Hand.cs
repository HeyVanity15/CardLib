using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand
    {
        private List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }
        
        public Card this[int index]
        {
            get
            {
                return _cards[index];
            }
        }

        public void Add(Card card)
        {
            if (card != null)
                _cards.Add(card);
        }
    }
}
