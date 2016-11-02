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
        /// Returns an instance of the Deck class.
        /// This static method exists in order to make Deck initialization asynchronous.
        /// Constructor methods cannot be marked async.
        /// </summary>
        /// <param name="includeJokers"></param>
        /// <returns></returns>
        public static async Task<Deck> InitializeDeck(bool includeJokers)
        {
            // PopulateDeck() is a synchronous method
            // It can be on a background thread by running it inside its own Task instance
            // This way, the method that calls PopulateDeck can run asynchronously
            Deck deck = await Task<Deck>.Run(() => PopulateDeck(includeJokers));

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
                if (this.Count() <= 0)
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
        private static Deck PopulateDeck(bool includeJokers)
        {
            int maxRank = includeJokers ? (int)Rank.Joker : (int)Rank.Ace;
            var ranks = Enum.GetValues(typeof(Rank));
            var suits = Enum.GetValues(typeof(Suit));
            var deck = new Deck();

            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    if ((int)rank <= maxRank)
                    {
                        var card = new Card(rank, suit);
                        deck.Push(card);
                    }
                }
            }

            return deck;
        }
    }
}
