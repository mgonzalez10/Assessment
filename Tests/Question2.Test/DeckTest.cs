using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2.Implementations;
using Question2.Interfaces;

namespace Question2.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DealOneCard_Success()
        {
            // arrange
            var deckSut = this.CreateSut();

            // act
            var card = deckSut.DealOneCard();

            // assert
            Assert.IsNotNull(card);
            Assert.AreEqual(card.Number, 1);
        }

        [TestMethod]
        public void DealOneCard_After52Cards_NoCardIsReturned()
        {
            // arrange
            var deckSut = this.CreateSut();

            // act
            // Gets all cards in the deck (52)
            for (int i = 1; i < 53; i++)
            {
                deckSut.DealOneCard();
            }

            var emptyDeck = deckSut.GetCardDeck();

            // try to get another one. No result is returned:
            var cardNo53 = deckSut.DealOneCard();

            // assert
            Assert.IsNull(cardNo53);
            Assert.AreEqual(emptyDeck.Count, 0);
        }

        [TestMethod]
        public void Shuffle_Success()
        {
            // arrange
            var deckSut = this.CreateSut();
            var firstCard = deckSut.GetCardDeck()[0];

            // act
            deckSut.Shuffle();
            var deck = deckSut.GetCardDeck();

            // assert
            Assert.IsNotNull(deck);
            Assert.AreNotEqual(firstCard, deck[0]);
        }

        private IDeck CreateSut()
        {
            return new Deck(true);
        }
    }
}
