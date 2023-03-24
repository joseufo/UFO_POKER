using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PokerServManager : MonoBehaviour
{
    [SerializeField] Transform LocalPlayerPosition;
    [SerializeField] List<Transform> OtherPlayers = new List<Transform>();
    int otherPlayerCount=0;
    

    public static PokerServManager instance;

    bool isGameStarted;
   

    List<Card> CardDeck = new List<Card>();

    Card[] BoardCard = new Card[5];
    List<PokerCard> TableCardsObj = new List<PokerCard>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        //AddLocalPlayer();
    }
    void AddLocalPlayer()
    {
        
    }

    void OnGameStart()
    {

    }

    public void PlayerJoinAdd()
    {

    }

    void StartGame()
    {
        isGameStarted = true;
    }

    enum PokerGameState{ Flop,Turn,River}

    PokerGameState gameState;
    public void NextDeal()
    {
        switch(gameState)
        {
            case PokerGameState.Flop:
                SetFlopCards();
                break;
            case PokerGameState.Turn:
                SetTurnCard();
                break;
            case PokerGameState.River:
                SetRiverCard();
                break;
        }

    }
    public void SetCardAndShuffle()
    {
        //int i = 0;
        foreach (Card.SUIT suit in Enum.GetValues(typeof(Card.SUIT)))
        {

            foreach (Card.VALUE value in Enum.GetValues(typeof(Card.VALUE)))
            {
                //Deck[i] = new Card { Suit = suit, Value = value };
                //i++;
                CardDeck.Add(new Card { Suit = suit, Value = value });
            }
            //for (int rank = 2; rank <= 14; rank++)
            //{
            //    Card pokerCard = new Card();
            //    pokerCard.Suit = suit;
            //    pokerCard.Value = rank;
            //    CardDeck.Add(pokerCard);
            //   // Debug.Log(pokerCard.rank + " : " + pokerCard.suit
            //}
        }
        Debug.Log(CardDeck.Count + " - count");
        var rand = new System.Random();
        Card hold;

        for (int shuffleCount = 0; shuffleCount < 1776; shuffleCount++)
        {
            for (int i = 0; i < 52; i++)
            {
                int index = rand.Next(52);
                hold = CardDeck[i];
                CardDeck[i] = CardDeck[index];
                CardDeck[index] = hold;
                //Debug.Log(CardDeck[i].suit + " : " + CardDeck[i].rank);
            }
        }


        SetTableCard();

    }
    void PrintDeck()
    {
        Debug.Log(CardDeck.Count + " - Deckcount");
        foreach (Card pokercard in CardDeck)
        {
            //Debug.Log(pokercard.suit + " : " + pokercard.rank);
        }
    }

    public void SetTableCard()
    {
        for (int i = 0; i < 5; i++)
        {
            TableCardsObj[i].CardData = CardDeck[i];
            TableCardsObj[i].SetCardData(CardDeck[i].Suit, CardDeck[i].Value);

            CardDeck.RemoveAt(i);
        }
        //SetFlopCards
        //PrintDeck();
        //SetFlopCards();
    }



    public void SetFlopCards()
    {
        for (int i = 0; i < 3; i++)
        {
            TableCardsObj[i].gameObject.SetActive(true);
            var card = TableCardsObj[i].GetComponent<PokerCard>();
            Debug.Log(card.CardData.ToString());
            //TableCards[i].SetCardData(Ca)
        }
        gameState = PokerGameState.Turn;
    }
    public void SetTurnCard()
    {
        TableCardsObj[3].gameObject.SetActive(true);

    }
    public void SetRiverCard()
    {
        TableCardsObj[4].gameObject.SetActive(true);
    }
}
