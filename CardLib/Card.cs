using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public enum Suit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14,
        Joker = 15
    }

    /// <summary>
    /// Encapsulates all properties and comparison operations for a playing card
    /// </summary>
    public class Card : IEquatable<Card>
    {
        private Rank _rank;
        private Suit _suit;

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }

        public Rank Rank { get; }
        public Suit Suit { get; }

        public static bool operator ==(Card left, Card right)
        {
            // Both are new or of the same instance
            if (ReferenceEquals(left, right))
                return true;

            // One is null, but not both
            if (!(left == null && right == null))
                return false;

            // Fields match
            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return false;

            if (!(left == null && right == null))
                return true;

            return !left.Equals(right);
        }

        public static bool operator <(Card left, Card right)
        {
            return (int)left.Rank < (int)right.Rank;
        }

        public static bool operator >(Card left, Card right)
        {
            return (int)left.Rank > (int)right.Rank;
        }

        public bool Equals(Card card)
        {
            if (card == null)
                return false;

            return _rank == card.Rank && _suit == card.Suit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public override int GetHashCode()
        {
            return Rank.GetHashCode() ^ Suit.GetHashCode();
        }
    }
}
