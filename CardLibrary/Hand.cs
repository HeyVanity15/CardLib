using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand
    {
        /// <summary>
        /// A stack would be more appropriate here, but I chose this in order to gain experience with indexers
        /// </summary>
        private List<Card> _cards;
        /// <summary>
        /// The event that will be handled by OnDraw
        /// </summary>
        public event EventHandler Draw;

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

        public Card DrawFromDeck(Deck deck)
        {
            Card card = null;

            if (deck != null && deck.Count > 0)
            {
                card = deck.Draw();
                _cards.Add(card);
            }

            return card;
        }

        /// <summary>
        /// Event handler for the draw event
        /// This can be overridden by derived classes
        /// This method is not necessary unless the event is handled within the same class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDraw(object sender, EventArgs e)
        {
            // event handlers nullable by default?
            Draw?.Invoke(this, e);
        }
    }
}
