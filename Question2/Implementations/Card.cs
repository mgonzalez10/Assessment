using Question2.Common;
using Question2.Interfaces;

namespace Question2.Implementations
{
    public class Card : ICard
    {
        public Card(Suit suit, int number, bool isWildCard = false)
        {
            this.Suit = suit;
            this.Number = number;
            this.IsWildCard = isWildCard;
        }

        public Suit Suit { get; set; }

        public int Number { get; set; }

        public bool IsWildCard { get; set; }
    }
}
