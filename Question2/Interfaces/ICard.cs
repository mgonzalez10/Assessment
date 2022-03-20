using Question2.Common;

namespace Question2.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; set; }

        int Number { get; set; }

        bool IsWildCard { get; set; }
    }
}
