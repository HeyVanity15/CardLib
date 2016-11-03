using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Deck : Stack<Card>
    {
        /// <summary>
        /// ***This may be a bad example.
        /// Task.Run() should never be used in a method implementation.
        /// Instead, it should be used when calling the method.***
        /// Returns an instance of the Deck class.
        /// This static method exists in order to make Deck initialization asynchronous.
        /// Constructor methods cannot be marked async.
        /// </summary>
        /// <param name="includeJokers"></param>
        /// <returns></returns>
        public static async Task<Deck> InitializeDeckAsync(bool includeJokers)
        {
            // Create a Deck instance to populate and return to the caller.
            var deck = new Deck();
            // PopulateDeck() is a synchronous method
            // It can be run on a background thread by running it inside its own Task.
            // This way, the method that calls PopulateDeck can run asynchronously.
            // Use ConfigureAwait() to specify whether or not the task should continue on the same thread.
            await Task.Run(() => deck.PopulateDeck(includeJokers)).ConfigureAwait(false);
            await Task.Run(() => deck.Shuffle()).ConfigureAwait(false);

            return deck;
        }

        /// <summary>
        /// Shuffles elements of the Deck (Stack) instance
        /// </summary>
        public void Shuffle()
        {
            var cards = this.ToArray();
            var random = new Random();

            for (int i = cards.Length - 1; i >= 0; i--)
            {
                int j = random.Next(i);
                Card card = cards[i];
                cards[i] = cards[j];
                cards[j] = card;
            }

            this.Clear();
            PopulateDeckFromArray(cards);
        }

        public Card Draw()
        {
            return this.Pop();
        }

        public Card[] Draw(int quantity)
        {
            var cardList = new List<Card>();

            for (int i = 1; i <= quantity; i++)
            {
                if (this.Count() - quantity < 0)
                    break;

                cardList.Add(this.Pop());
            }

            return cardList.ToArray();
        }

        private void PopulateDeckFromArray(Card[] cards)
        {
            foreach (Card card in cards)
            {
                this.Push(card);
            }
        }

        /// <summary>
        /// Creates a card Deck instance and returns it
        /// </summary>
        /// <param name="includeJokers"></param>
        /// <returns></returns>
        private void PopulateDeck(bool includeJokers)
        {
            int maxRank = includeJokers ? (int)Rank.Joker : (int)Rank.Ace;
            var ranks = Enum.GetValues(typeof(Rank));
            var suits = Enum.GetValues(typeof(Suit));

            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    if ((int)rank <= maxRank)
                    {
                        var card = new Card(rank, suit);
                        this.Push(card);
                    }
                }
            }
        }
    }
}
