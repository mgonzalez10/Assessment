using Question2.Common;
using Question2.Interfaces;

namespace Question2
{
    public static class HighCard
    {
        public static GameResult Play(IDeck deck, bool resolveTiesBySuit = false, bool dealAdditionalCardInDraws = false)
        {
            ICard player1CurrentCard;
            ICard player2CurrentCard;
            GameResult result;

            do
            {
                player1CurrentCard = deck.DealOneCard();
                player2CurrentCard = deck.DealOneCard();

                result = EvaluateGame(player1CurrentCard, player2CurrentCard, resolveTiesBySuit);
            } while (result == GameResult.Draw && dealAdditionalCardInDraws);

            return result;
        }

        public static  GameResult EvaluateGame(ICard player1CurrentCard, ICard player2CurrentCard, bool resolveTiesBySuit)
        {
            if (player1CurrentCard.Number == player2CurrentCard.Number)
            {
                if (resolveTiesBySuit && player1CurrentCard.Suit != player2CurrentCard.Suit)
                {
                    return GameResult.Win;
                }
                else
                {
                    return GameResult.Draw;
                }
            }
            else if ((!player1CurrentCard.IsWildCard && player2CurrentCard.IsWildCard) || 
                    (player1CurrentCard.Number < player2CurrentCard.Number))
            {
                return GameResult.Win;
            }
            else
            {
                return GameResult.Lose;
            }
        }
    }
}
