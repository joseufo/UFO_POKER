using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoker : MonoBehaviour
{
    EvalHand Eval = new EvalHand();
    public Card[] PlayerHand1 = new Card[2];
    public Card[] PlayerHand2 = new Card[2];
    public Card[] Board = new Card[5];
    public int cardsShown = 5;
    int whoWon = 0;

    Ranks RankName = new Ranks();
    private void CheckWinner()//int[] rank, int[] opp_rank
    {
        int[] rank = Eval.Evaluate(PlayerHand1, Board, cardsShown);
        int[] opp_rank = Eval.Evaluate(PlayerHand2, Board, cardsShown);
        //StopDraws();

        if (rank[0] > opp_rank[0])
        {
            Debug.Log("You WIN with " + RankName.getString(rank[0]));
            whoWon = 1;
        }
        else if (rank[0] == opp_rank[0])
        {
            if (rank[1] > opp_rank[1])
            {
                Debug.Log("You WIN with your higher " + RankName.getString(rank[0]));
                whoWon = 1;
            }
            else if (rank[1] == opp_rank[1])
            {
                if (rank[2] > opp_rank[2])
                {
                    Debug.Log("You WIN with your higher " + RankName.getString(rank[0]));
                    whoWon = 1;
                }
                else if (rank[2] == opp_rank[2])
                {
                    Debug.Log("You SPLIT the POT with " + RankName.getString(rank[0]));
                    whoWon = 0;  //Drawwwwwwwwwwwwwwwwwwww
                }
            }
            else
            {
                Debug.Log("You LOSE with your lower " + RankName.getString(rank[0]));
                whoWon = 2;
            }


        }
        else
        {
            Debug.Log("You LOSE to " + RankName.getString(opp_rank[0]));
            whoWon = 2;
        }



    }
    private void Start()
    {
        PlayerHand1[0].Suit = Card.SUIT.DIAMONDS; PlayerHand1[0].Value = Card.VALUE.FIVE;
        PlayerHand1[1].Suit = Card.SUIT.SPADES; PlayerHand1[1].Value = Card.VALUE.TEN;

        PlayerHand2[0].Suit = Card.SUIT.DIAMONDS; PlayerHand2[0].Value = Card.VALUE.SEVEN;
        PlayerHand2[1].Suit = Card.SUIT.SPADES; PlayerHand2[1].Value = Card.VALUE.JACK;

        Board[0].Suit = Card.SUIT.SPADES; Board[0].Value = Card.VALUE.FIVE;
        Board[1].Suit = Card.SUIT.DIAMONDS; Board[1].Value = Card.VALUE.TEN;
        //Board[2].Suit = Card.SUIT.SPADES; Board[2].Value = Card.VALUE.FOUR;
        //Board[3].Suit = Card.SUIT.CLUBS; Board[3].Value = Card.VALUE.NINE;
        //Board[4].Suit = Card.SUIT.DIAMONDS; Board[4].Value = Card.VALUE.TWO;

        int[] rank = Eval.Evaluate(PlayerHand1, Board, 2);
        Debug.Log(rank[0] + " -" + RankName.getString(rank[0]) + "...highcard: " + rank[1] + "second high:" + rank[2]);
        CheckWinner();
    }
    class Ranks
    {
        public string getString(int num)
        {
            if (num == 0)
                return "High Card";
            if (num == 1)
                return "Pair";
            if (num == 2)
                return "Two Pair";
            if (num == 3)
                return "Three of a Kind";
            if (num == 4)
                return "Straight";
            if (num == 5)
                return "Flush";
            if (num == 6)
                return "Full House";
            if (num == 7)
                return "Four of a Kind";
            if (num == 8)
                return "Straight Flush";
            if (num == 9)
                return "Royal Flush";

            return "";
        }
    }










    void AddTestCardHand()
    {
        // SetInitialCards(Card.Suit.Spades, 14, Card.Suit.Diamonds, 7);
        //AddHandCard(new Card { suit = Card.CSuit.Diamonds, rank = 6 });
        //AddHandCard(new Card { suit = Card.CSuit.Hearts, rank = 5 });
        //AddHandCard(new Card { suit = Card.CSuit.Spades, rank = 10 });
        //AddHandCard(new Card { suit = Card.CSuit.Spades, rank = 11 });
        //AddHandCard(new Card { suit = Card.CSuit.Spades, rank = 12 });
        //AddHandCard(new Card { suit = Card.CSuit.Spades, rank = 13 });
        //AddHandCard(new Card { suit = Card.CSuit.Clubs, rank = 14 });


        //playerHandCards.SortCards();
        //HandRanking ranking = playerHandCards.DetermineHandRankings();
        //foreach (var card in playerHandCards)
        //{
        //    Debug.Log(card.ToString());
        //}
        //Debug.Log(ranking);

    }
    public void AddHandCard(Card cardData)
    {
        //playerHandCards.Add(cardData);
    }


}
