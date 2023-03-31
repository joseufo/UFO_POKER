using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokerSharp;
public class DevGamePlayTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var hand = new List<Cardd>{
    new Cardd { suit = Cardd.Suit.Clubs, rank = 14 },
    new Cardd { suit = Cardd.Suit.Diamonds, rank = 2 },
    new Cardd { suit = Cardd.Suit.Hearts, rank = 3 },
    new Cardd { suit = Cardd.Suit.Spades, rank =4 },
    new Cardd { suit = Cardd.Suit.Clubs, rank = 5 }
     };
        //foreach (var card in hand)
            //Debug.Log(card.ToString());
        Debug.Log((int)hand.DetermineHandRankings());

        var hand2 = new List<Cardd>{
    new Cardd { suit = Cardd.Suit.Clubs, rank = 2 },
    new Cardd { suit = Cardd.Suit.Diamonds, rank = 3 },
    new Cardd { suit = Cardd.Suit.Hearts, rank = 4 },
    new Cardd { suit = Cardd.Suit.Spades, rank =5 },
    new Cardd { suit = Cardd.Suit.Clubs, rank = 6 }
     };
        Debug.Log((int)hand2.DetermineHandRankings());
        var hs = DetermineWinner.CalculateHighestHandRanking(hand, hand2);
        //foreach (var x in hs)
        //Debug.Log(x);
        Debug.Log(hs);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
