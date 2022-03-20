using System.Collections.Generic;

namespace Question2.Interfaces
{
    public interface IDeck
    {
        List<ICard> GetCardDeck();

        void Suffle();

        ICard DealOneCard();
    }
}
