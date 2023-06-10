using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PokerServManager : MonoBehaviour
{
    [SerializeField] Transform LocalPlayerPosition;
    [SerializeField] List<Transform> OtherPlayers = new List<Transform>();
    int otherPlayerCount=0;

    public GameObject cardPrefab;
    public static PokerServManager instance;

    bool isGameStarted;
   

    List<Card> CardDeck = new List<Card>();


    List<Card> TableCards = new List<Card>();
    //Card[] BoardCard = new Card[5];

    int cardShown=0;
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
   

    void OnGameStart()
    {

    }

    public void PlayerJoinAdd()
    {
        PlayerData playerData = new PlayerData();
        PokerClientManager.instance.AddOpponent(playerData);
    }
    public void PlayerJoinAddMax()
    {
       
        for (int i=0; i<5; i++)
        {
            PlayerData playerData = new PlayerData();
            PokerClientManager.instance.AddOpponent(playerData);
        }
            
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void ExitGame() => Application.Quit();
    public void StartGame()
    {
        isGameStarted = true;
        SetCardAndShuffle();
        DistributeCards();
    }
    
    void DistributeCards()
    {
        //var playerlist = PokerClientManager.instance.CurrentRoundPlayers;
        
        //for(int i=0; i<playerlist.Count; i++)
        //{

        //    playerlist[i].SetAndShowPlayerCards(CardDeck[i], CardDeck[i+1]);
        //    Debug.Log(playerlist[i].playerText.text + " Cards : " + CardDeck[i].ToString() + " , " + CardDeck[i + 1].ToString());
            
        //    CardDeck.RemoveAt(i); CardDeck.RemoveAt(i);
        //    pokerCardList[i].UnshowCard(); pokerCardList[i+1].UnshowCard();
        //}

        //PokerClientManager.instance.ShowPlayerHandRankings();
        //SetTableCard();
        //gameState = PokerGameState.Flop;
    }
    enum PokerGameState{ Flop,Turn,River, End}

    PokerGameState gameState;
    public void NextDeal()
    {
        Debug.Log(gameState);
        switch (cardShown)
        {
            case 0:
                SetFlopCards();
                break;
            case 3:
                SetTurnCard();
                break;
            case 4:
                SetRiverCard();
                break;
            case 5:
                PokerClientManager.instance.RoundEnd(null);
                break;
        }

    }
    List<PokerCard> pokerCardList = new List<PokerCard>();
    public void SetCardAndShuffle()
    {
        //int i = 0;
        int xOffset = 10;
        foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
        {

            foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
            {
                //Deck[i] = new Card { Suit = suit, Value = value };
                //i++;
                CardDeck.Add(new Card(suit, value));
                var x = Instantiate(cardPrefab, new Vector3(xOffset, 5f, 0f), Quaternion.identity);
                pokerCardList.Add(x.GetComponent<PokerCard>());
                x.GetComponent<PokerCard>().SetAndShowCard(new Card (suit, value));
                xOffset += 2;
            }
           
        }
        Debug.Log(CardDeck.Count + " - count");
        var rand = new System.Random();
        Card hold;

        
        for (int i = CardDeck.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            Card temp = CardDeck[i];
            CardDeck[i] = CardDeck[j];
            CardDeck[j] = temp;
            pokerCardList[i].GetComponent<PokerCard>().SetAndShowCard(CardDeck[i]);
            pokerCardList[j].GetComponent<PokerCard>().SetAndShowCard(CardDeck[j]);
        }
        //// Fisher-Yates shuffle
        //for (int i = CardDeck.Count - 1; i > 0; i--)
        //{
        //    int n = UnityEngine.Random.Range(0, i + 1);
        //    Card temp = CardDeck[i];
        //    CardDeck[i] = CardDeck[n];
        //    CardDeck[n] = temp;
        //}

       


        //SetTableCard();

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
        string cardListString = "";
        for (int i = 0; i < 5; i++)
        {
            //TableCardsObj[i].CardData = CardDeck[i];
            TableCards.Add(CardDeck[i]);

            //TableCardsObj[i].SetCardData(CardDeck[i].Suit, CardDeck[i].Value);
            //TableCardsObj[i].SetAndShowCard(CardDeck[i]);
            cardListString = cardListString + CardDeck[i] + ", ";
            CardDeck.RemoveAt(i);

        }
        Debug.Log("TableCards: " + cardListString);
        //SetFlopCards
        //PrintDeck();
        //SetFlopCards();

        //NextDeal();
    }



    public void SetFlopCards()
    {
        //foreach (var card in TableCards)
            //Debug.LogError(card.ToString());
        List<Card> cardlist = new List<Card>();
        for (int i = 0; i < 3; i++)
        {

            cardlist.Add(TableCards[i]);
            //TableCardsObj[i].gameObject.SetActive(true);
            //var card = TableCardsObj[i].GetComponent<PokerCard>();
            //Debug.Log(card.CardData.ToString());
            //TableCards[i].SetCardData(Ca)
            cardShown++;
        }
        //PokerClientManager.instance.SetPokerPhaseCards(cardlist,1);
        gameState = PokerGameState.Turn;

    }
    public void SetTurnCard()
    {
        //foreach (var card in TableCards)
        //    Debug.LogError(card.ToString());
        //TableCardsObj[3].gameObject.SetActive(true);
        List<Card> cardlist = new List<Card>();
        //cardlist[0] = TableCards[3];
        cardlist.Add(TableCards[3]);
        cardShown++;
        //PokerClientManager.instance.SetPokerPhaseCards(cardlist,2);
        gameState = PokerGameState.River;

    }
    public void SetRiverCard()
    {
        //foreach (var card in TableCards)
        //    Debug.LogError(card.ToString());
        List<Card> cardlist = new List<Card>();
        cardlist.Add(TableCards[4]);
        cardShown++;
        //PokerClientManager.instance.SetPokerPhaseCards(cardlist,3);
        gameState = PokerGameState.End;
    }
    private void Update()
    {
        //Debug.Log(gameState);
    }
}
