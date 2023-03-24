using System;
using UnityEngine;


[Serializable]
public class Card
{
    [Flags]
    public enum SUIT { SPADES, CLUBS, DIAMONDS, HEARTS }
    public enum VALUE
    {
        TWO = 2, THREE, FOUR,
        FIVE, SIX, SEVEN, EIGHT,
        NINE, TEN, JACK, QUEEN, KING, ACE
    }

    public SUIT Suit { get; set; }
    public VALUE Value { get; set; }



    public override string ToString()
    {

        var suitLabel = Suit.ToString();
        var rankLabel = ((int)Value).ToString();

        switch (Suit)
        {
            case SUIT.CLUBS:
                suitLabel = "♣";

                break;
            case SUIT.DIAMONDS:
                suitLabel = "♦";

                break;
            case SUIT.HEARTS:
                suitLabel = "♥";

                break;
            case SUIT.SPADES:
                suitLabel = "♠";

                break;
        }

        switch ((int)Value)
        {
            case 11:
                rankLabel = "J";

                break;
            case 12:
                rankLabel = "Q";

                break;
            case 13:
                rankLabel = "K";

                break;
            case 14:
                rankLabel = "A";

                break;
        }

        return $"{suitLabel} {rankLabel}";

    }



    //[Flags]
    //public enum CSuit
    //{

    //    Clubs = 1 << 0,

    //    Diamonds = 1 << 1,

    //    Hearts = 1 << 2,

    //    Spades = 1 << 3

    //}

    //public int rank;

    //public CSuit suit;
    //public override string ToString()
    //{

    //    var suitLabel = suit.ToString();
    //    var rankLabel = rank.ToString();

    //    switch (suit)
    //    {
    //        case CSuit.Clubs:
    //            suitLabel = "♣";

    //            break;
    //        case CSuit.Diamonds:
    //            suitLabel = "♦";

    //            break;
    //        case CSuit.Hearts:
    //            suitLabel = "♥";

    //            break;
    //        case CSuit.Spades:
    //            suitLabel = "♠";

    //            break;
    //    }

    //    switch (rank)
    //    {
    //        case 11:
    //            rankLabel = "J";

    //            break;
    //        case 12:
    //            rankLabel = "Q";

    //            break;
    //        case 13:
    //            rankLabel = "K";

    //            break;
    //        case 14:
    //            rankLabel = "A";

    //            break;
    //    }

    //    return $"{suitLabel} {rankLabel}";

    //}

}

