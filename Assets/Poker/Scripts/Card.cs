using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[Serializable]
//[SerializableAttribute]
//public struct Card
//{
   

//    public int suit;
//    public int rank;

//    public Card(int s, int r) : this()
//    {
//        this.suit = s;
//        this.rank = r;
//    }

//    public static Card nullCard
//    {
//        get { return new Card(0, 0); }
//    }
//    public enum SUIT { SPADES, CLUBS, DIAMONDS, HEARTS }
//    public enum VALUE
//    {
//        TWO = 2, THREE, FOUR,
//        FIVE, SIX, SEVEN, EIGHT,
//        NINE, TEN, JACK, QUEEN, KING, ACE
//    }

//    public SUIT Suit { get; set; }
//    public VALUE Value { get; set; }

//    //public int rank { get => (int)Value; }

//    public override string ToString()
//    {

//        var suitLabel = Suit.ToString();
//        var rankLabel = ((int)Value).ToString();

//        switch (Suit)
//        {
//            case SUIT.CLUBS:
//                suitLabel = "♣";

//                break;
//            case SUIT.DIAMONDS:
//                suitLabel = "♦";

//                break;
//            case SUIT.HEARTS:
//                suitLabel = "♥";

//                break;
//            case SUIT.SPADES:
//                suitLabel = "♠";

//                break;
//        }

//        switch ((int)Value)
//        {
//            case 11:
//                rankLabel = "J";

//                break;
//            case 12:
//                rankLabel = "Q";

//                break;
//            case 13:
//                rankLabel = "K";

//                break;
//            case 14:
//                rankLabel = "A";

//                break;
//        }

//        return $"{suitLabel} {rankLabel}";

//    }

//    public static bool operator ==(Card a, Card b)
//    {
//        //if (ReferenceEquals(a, b))
//        //{
//        //    return true;
//        //}
//        //if (a is null || b is null)
//        //{
//        //    return false;
//        //}
//        return a.suit == b.suit && a.rank == b.rank;
//    }

//    public static bool operator !=(Card a, Card b)
//    {
//        return !(a == b);
//    }

//    public override bool Equals(object obj)
//    {
//        if (!(obj is Card))
//            return false;

//        Card other = (Card)obj;
//        return this == other;
//    }

//    public override int GetHashCode()
//    {
//        return suit.GetHashCode() ^ rank.GetHashCode();
//    }



//}

