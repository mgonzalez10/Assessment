using System;
using System.Collections.Generic;
using System.Linq;
using Question2.Common;
using Question2.Interfaces;

namespace Question2.Implementations
{
    public class Deck : IDeck
    {
        private const int SuitCardMaxNumber = 20; // Initially it was 13

        public Dictionary<Guid, ICard> Cards { get; set; }

        public Deck(bool initilizeDeck = false, int decksNumber = 1)
        {
            if (initilizeDeck)
            {
                InitializeDeck(decksNumber);
            }
        }

        private void InitializeDeck(int decksNumber)
        {
            Cards = new Dictionary<Guid, ICard>();

            for (int i = 1; i <= decksNumber; i++)
            {
                PopulateDeck();
            }
        }

        private void PopulateDeck()
        {
            var suitType = Enum.GetValues(typeof(Suit)).Cast<Suit>();

            // We get the ramdom index for the WildCard:
            Random r = new();
            int wildcardIndex = r.Next(1, SuitCardMaxNumber);

            foreach (var suit in suitType)
            {
                for (int j = 1; j <= SuitCardMaxNumber; j++)
                {
                    Cards.Add(Guid.NewGuid(), CardFactory.CreateCard(suit, j, j == wildcardIndex));
                }
            }
        }

        /// <summary>
        /// <see cref="IDeck.DealOneCard"/>
        /// </summary>
        public ICard DealOneCard()
        {
            if (!Cards.Any())
                return null;

            // Gets a card key from deck:
            var pickedCard = Cards.First();

            // Remove that card from deck:
            Cards.Remove(pickedCard.Key);

            return pickedCard.Value;

        }

        /// <summary>
        /// <see cref="IDeck.Shuffle"/>
        /// </summary>
        public void Shuffle()
        {
            if (!Cards.Any())
                return;

            Cards = Cards.OrderBy(x => Guid.NewGuid()).ToDictionary(x => x.Key, x => x.Value);
        }

        public List<ICard> GetCardDeck()
        {
            if (!Cards.Any())
                return new List<ICard>(); // return empty deck

            return Cards.Select(x => x.Value).ToList();
        }
    }
}
