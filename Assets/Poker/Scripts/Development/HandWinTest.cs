using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HandWinTest : MonoBehaviour
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
    public PokerPlayer player1, player2;
    private void Start()
    {
        List<PokerPlayer> testPlayers = new List<PokerPlayer>();
        //GameObject p1 = new GameObject();
        //p1.AddComponent(typeof(PokerPlayer));
        //PokerPlayer player1 = p1.GetComponent<PokerPlayer>();

        player1.PlayerName = "Player001"; 
        //player1.PlayerHand = new Card[2];
        player1.PlayerHand[0] = new Card { Suit = Card.SUIT.HEARTS, Value = Card.VALUE.KING };
        player1.PlayerHand[1] = new Card { Suit = Card.SUIT.HEARTS, Value = Card.VALUE.JACK };
        testPlayers.Add(player1);

        //GameObject p2 = new GameObject();
        //p2.AddComponent(typeof(PokerPlayer));
        //PokerPlayer player2 = p2.GetComponent<PokerPlayer>();
        player2.PlayerName = "Player002";
        //player2.PlayerHand = new Card[2];
        player2.PlayerHand[0] = new Card { Suit = Card.SUIT.CLUBS, Value = Card.VALUE.KING };
        player2.PlayerHand[1] = new Card { Suit = Card.SUIT.HEARTS, Value = Card.VALUE.NINE };
        testPlayers.Add(player2);
        

        Board = new Card[5];
        Board[0] = new Card { Suit = Card.SUIT.DIAMONDS, Value = Card.VALUE.KING };
        Board[1] = new Card { Suit = Card.SUIT.DIAMONDS, Value = Card.VALUE.TWO };
        Board[2] = new Card { Suit = Card.SUIT.SPADES, Value = Card.VALUE.KING };
        Board[3] = new Card { Suit = Card.SUIT.DIAMONDS, Value = Card.VALUE.SIX };
        Board[4] = new Card { Suit = Card.SUIT.SPADES, Value = Card.VALUE.TWO };

        player1.rankScores = Eval.Evaluate(player1.PlayerHand, Board, 5);
        player2.rankScores = Eval.Evaluate(player2.PlayerHand, Board, 5);
        Debug.Log("Player1: " + player1.rankScores[0] + " -" + RankName.getString(player1.rankScores[0]) + "...highcard: " + player1.rankScores[1] + "second high:" + player1.rankScores[2]);
        Debug.Log("Player2: " + player2.rankScores[0] + " -" + RankName.getString(player2.rankScores[0]) + "...highcard: " + player2.rankScores[1] + "second high:" + player2.rankScores[2]);

        //CheckWinner();
        
       
        FindWinner(testPlayers);
    }
    bool isDraw;
    public void FindWinner(List<PokerPlayer> players)
    {

        List<PokerPlayer> sortedPlayers = players.OrderByDescending(p => p.rankScores[0]).ToList();

        int topPlayerCardRank = sortedPlayers[0].rankScores[0];
        
        List<PokerPlayer> topPlayers = sortedPlayers.TakeWhile(p => p.rankScores[0] == topPlayerCardRank).ToList();

        //foreach (PokerPlayer pl in topPlayers)
        //    Debug.Log(pl.PlayerName + "--" + pl.rankScores[1]);

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            //ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
            return;
        }


        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[1]).ToList();
        int topPlayerHighCard1 = topPlayers[0].rankScores[1];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[1] == topPlayerHighCard1).ToList();

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            //ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
            return;
        }
        

        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[2]).ToList();
        int topPlayerHighCard2 = topPlayers[0].rankScores[2];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[2] == topPlayerHighCard2).ToList();

        if (topPlayers.Count == 1)
        {
            Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            //ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
        }
        else
        {
            string playersWinners = "";
            foreach (var player in topPlayers)
                playersWinners += player.PlayerName + ", ";
            //Debug.Log(player.PlayerName);
            isDraw = true;
            Debug.Log("Draw!, Split pot with" + playersWinners);
            //ResultText.text = "Draw!, Split pot with " + playersWinners;

        }
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
