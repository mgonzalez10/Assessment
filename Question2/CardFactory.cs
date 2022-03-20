using Question2.Common;
using Question2.Implementations;
using Question2.Interfaces;

namespace Question2
{
    public static class CardFactory
    {
        public static ICard CreateCard(Suit suit, int number, bool isWildCard = false)
        {
            return new Card(suit, number, isWildCard);
        }
    }
}
