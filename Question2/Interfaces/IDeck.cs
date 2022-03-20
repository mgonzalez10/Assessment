using System.Collections.Generic;

namespace Question2.Interfaces
{
    public interface IDeck
    {
        List<ICard> GetCardDeck();

        void Shuffle();

        ICard DealOneCard();
    }
}
