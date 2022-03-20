using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2.Common;
using Question2.Implementations;
using Question2.Interfaces;

namespace Question2.Test
{
    [TestClass]
    public class HighCardTest
    {
        [TestMethod]
        public void Play_RamdomDeck_Successfully()
        {
            // Arrange
            var deck = this.CreateSut();
            deck.Shuffle();

            // Act
            var result = HighCard.Play(deck);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Play_WithTies_Draw()
        {
            // Arrange
            var deck = this.CreateSutWithTieCards();

            // Act
            var result = HighCard.Play(deck);

            // Assert
            Assert.IsTrue(result == GameResult.Draw);
        }

        [TestMethod]
        public void Play_ResolveTiesBySuit_Win()
        {
            // Arrange
            var deck = this.CreateSutWithTieCards();

            // Act
            var result = HighCard.Play(deck, true);

            // Assert
            Assert.IsTrue(result == GameResult.Win);
        }

        [TestMethod]
        public void Play_DealAdditionalCardInDraw_Win()
        {
            // Arrange
            var deck = this.CreateSutWithSeveralTieCards();

            // Act
            var result = HighCard.Play(deck, false, true);

            // Assert
            Assert.IsTrue(result == GameResult.Win);
        }

        [TestMethod]
        public void Play_WithWildCard_Lose()
        {
            // Arrange
            var deck = this.CreateSut();

            // Act
            var result = HighCard.Play(deck);

            // Assert
            Assert.IsTrue(result == GameResult.Win);
        }

        [TestMethod]
        public void Play_WithMultipleDecks_Sucessfully()
        {
            // Arrange
            var deck = this.CreateSutMultipleDecks();

            // Act
            var result = HighCard.Play(deck);

            // Assert
            Assert.IsTrue(result == GameResult.Win);
        }


        private IDeck CreateSut()
        {
            return new Deck(true);
        }
        private IDeck CreateSutMultipleDecks()
        {
            return new Deck(true, 3);
        }

        private IDeck CreateSutWithWildCard()
        {
            var deck = new Deck(false)
            {
                Cards = new Dictionary<Guid, ICard>()
            };
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Clubs, 2, false));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Spades, 1, true));
            return deck;
        }

        private IDeck CreateSutWithTieCards()
        {
            var deck = new Deck(false)
            {
                Cards = new Dictionary<Guid, ICard>()
            };
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Clubs, 2));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Spades, 2));
            return deck;
        }

        private IDeck CreateSutWithSeveralTieCards()
        {
            var deck = new Deck(false)
            {
                Cards = new Dictionary<Guid, ICard>()
            };
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Clubs, 2));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Spades, 2));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Diamonds, 10));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Hearts, 10));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Diamonds, 5));
            deck.Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(Suit.Hearts, 6));
            return deck;
        }

    }
}

