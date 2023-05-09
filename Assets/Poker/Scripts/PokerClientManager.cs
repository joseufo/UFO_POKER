using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class PlayerData
{
       

    public string playerName;
    public int playerPosition;
    public int playerActorNo;
    public bool isLocalPlayer = false;

    public float TotalCoinAmount;

    public float currentCallRaiseAmount;
    public float RemainingAmount;

    public EvalData completeEvalData;

    public bool isOutOfGame = false;
    public bool runOutOfMoney = false;
    public bool underAllin = false;
    public bool isObserver = false;

    public Card card1data;
    public Card card2data;      

    //public int coeffCardsValOnFlopPhase = 0;
    //public int maxCardValOnFlopPhase = 0;
    //public int maxCardValueOnShowDown = 0;





}
public class PokerClientManager : MonoBehaviour
{
    public bool isOnline;
    public PokerEval GameCardControl;
    public TMP_Text ResultText; 
    public static PokerClientManager instance;
    [NonSerialized]public bool isGameStarted;    
    [SerializeField] List<Transform> PlayersTransform = new List<Transform>();
    [SerializeField] GameObject PokerPlayerPrefab;

    public int maxPlayers = 5;
    int opponentCount=0;
    public List<PokerPlayer> PlayerList = new List<PokerPlayer>();

    public List<PokerCard> TableCards = new List<PokerCard>();
    Card[] BoardCard = new Card[5];

    List<Card> flopCardsList = new List<Card>();
    Card TurnCard = Card.nullCard, RiverCard = Card.nullCard;

    int nextCardIndex = 0;
    bool useFlopCars, useTurnCard, useRiverCard;
    //EvalHand CardEval = new EvalHand();

    public Dictionary<int, PokerPlayer> DPokerPlayer = new Dictionary<int, PokerPlayer>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        //OnJoinedGame();
        //StartCoroutine(StartSim());
    }
    


    public void AddLocalPlayer(PlayerData newPlayerData)
    {
        var player = Instantiate(PokerPlayerPrefab, PlayersTransform[0], false);
        var pokerPlayer = player.GetComponent<PokerPlayer>();
        pokerPlayer.isLocalPlayer = true;
        //player.GetComponent<PokerPlayer>().PlayerName = "Player0";
        //player.GetComponent<PokerPlayer>().playerData.playerName = "Player0";
        pokerPlayer.playerData = newPlayerData;
        pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
        pokerPlayer.DisplayData();
        PlayerList.Add(player.GetComponent<PokerPlayer>());
        DPokerPlayer.Add(pokerPlayer.playerData.playerActorNo, PlayerList[PlayerList.IndexOf(pokerPlayer)]);

    }
    public void GivePlayerCards(Card card1, Card card2)
    {
        PlayerList[0].SetAndShowPlayerCards(card1, card2);
        if (PlayerList[0].playerData.card1data.rank == PlayerList[0].playerData.card2data.rank)
            PlayerList[0].SetCardRankingText("Pair");
        else
        {
            PlayerList[0].SetCardRankingText("High Card");
        }
        for (int i = 1; i < PlayerList.Count; i++)
        {
            Debug.Log("NAME" + PlayerList[i].PlayerName);
            PlayerList[i].ShowBackCards();
            PlayerList[i].SetCardRankingText("");
        } 
    }
    List<int> mapIndex = new List<int> { 1, 2, 3, 4 };
    public void AddRoomOpponents(List<PlayerData> playerDataList)
    {
        playerDataList = playerDataList.OrderByDescending(player => player.playerPosition).ToList();
        int count = playerDataList.Count;
        for (int i = 0; i < playerDataList.Count; i++)
        {
            opponentCount++;            
            var newPlayer = Instantiate(PokerPlayerPrefab, PlayersTransform[opponentCount], false);
            var pokerPlayer = newPlayer.GetComponent<PokerPlayer>();            
            pokerPlayer.playerData = playerDataList[i];
            pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
            pokerPlayer.DisplayData();
            PlayerList.Add(pokerPlayer);
            DPokerPlayer.Add(pokerPlayer.playerData.playerActorNo, PlayerList[PlayerList.IndexOf(pokerPlayer)]);
            mapIndex.Remove(i);
        }
        printMapIndex();
    }

    public void AddOpponent(PlayerData newPlayerData)
    {
        if (opponentCount == maxPlayers - 1) return;
        opponentCount++;
        int spawnIndex = mapIndex.Count - 1;
        var newPlayer = Instantiate(PokerPlayerPrefab, PlayersTransform[mapIndex[spawnIndex]], false);
        var pokerPlayer = newPlayer.GetComponent<PokerPlayer>();
        pokerPlayer.playerData = newPlayerData;
        pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
        pokerPlayer.DisplayData();
        PlayerList.Add(pokerPlayer);
        DPokerPlayer.Add(pokerPlayer.playerData.playerActorNo, PlayerList[PlayerList.IndexOf(pokerPlayer)]);
        mapIndex.Remove(mapIndex[spawnIndex]);
        printMapIndex();
    }
    void printMapIndex() { string indd = ""; foreach (var id in mapIndex) { indd += ", " + id; } Debug.Log("MAPINDEX: " + indd); }
    int CardPhase=0;
    public void SetBoardTableCard(List<Card> cardList , int cardPhase)
    {
        CardPhase = cardPhase;
        switch (cardPhase)
        {
            case 1:

                foreach (var card in cardList)
                {
                    flopCardsList.Add(card);
                    TableCards[nextCardIndex].SetAndShowCard(card);
                    TableCards[nextCardIndex].gameObject.SetActive(true);
                    nextCardIndex ++;
                }
                nextCardIndex = 3;
                break;
            case 2:
                TableCards[nextCardIndex].SetAndShowCard(cardList[0]);
                TableCards[nextCardIndex].gameObject.SetActive(true);
                TurnCard = cardList[0];
                nextCardIndex = 4;
                break;
            case 3:
                TableCards[nextCardIndex].SetAndShowCard(cardList[0]);
                TableCards[nextCardIndex].gameObject.SetActive(true);
                RiverCard = cardList[0];
                break;
        }
        string tableCards = "TableCards: ";
        for (int i=0; i<TableCards.Count; i++ )
            tableCards += TableCards[i].CardData + ", ";
        if(cardPhase == 3)
        Debug.Log(tableCards);
        ShowLocalPlayerRanking();
        //ShowPlayerHandRankings();


    }
    void ShowLocalPlayerRanking()
    {
        EvalData data = new EvalData();
        EvalData dataOut = new EvalData();
        data.playerCard_1 = PlayerList[0].playerData.card1data;
        data.playerCard_2 = PlayerList[0].playerData.card2data;
        switch (CardPhase)
        {

            case 1:
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];
                break;
            case 2:
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];
                data.turnCard = TurnCard;
                break;
            case 3:
                data.flopCards[0] = flopCardsList[0];
                data.flopCards[1] = flopCardsList[1];
                data.flopCards[2] = flopCardsList[2];
                data.turnCard = TurnCard;
                data.riverCard = RiverCard;
                break;

        }
        string cardListString = "CardList: " + CardPhase + " : ";
        foreach (var cards in data.flopCards)
            cardListString += cards.ToString() + ", ";
        cardListString += data.turnCard.ToString();
        cardListString += data.riverCard.ToString();
        //Debug.Log(cardListString);


        if (nextCardIndex >= 3)
        {
            GameCardControl.getPlayerCardsResult(PlayerList[0].playerData.playerPosition, data, out dataOut);
            PlayerList[0].playerData.completeEvalData = dataOut;
            PlayerList[0].SetCardRankingText(PlayerList[0].playerData.completeEvalData.cardsResultValues.ToString());

            string bestFive = "";
            foreach (int ix in PlayerList[0].playerData.completeEvalData.bestFive)
            {
                bestFive = bestFive + ix + " : ";
            }
            Debug.Log("" + PlayerList[0].PlayerName + " bestfive:" + bestFive);
        }
        else
        {
            if (PlayerList[0].playerData.card1data.rank == PlayerList[0].playerData.card2data.rank)
                PlayerList[0].SetCardRankingText("Pair");
            else
            {
                PlayerList[0].SetCardRankingText("High Card");
            }

        }

    }
    public void ShowPlayerHandRankings()
    {
        for (int i=0; i< PlayerList.Count; i++)
        {
            EvalData data = new EvalData();
            EvalData dataOut = new EvalData();
            data.playerCard_1 = PlayerList[i].playerData.card1data;
            data.playerCard_2 = PlayerList[i].playerData.card2data;
            switch(CardPhase)
            {
               
                case 1:
                    data.flopCards[0] = flopCardsList[0];
                    data.flopCards[1] = flopCardsList[1];
                    data.flopCards[2] = flopCardsList[2];
                    break;
                case 2:
                    data.flopCards[0] = flopCardsList[0];
                    data.flopCards[1] = flopCardsList[1];
                    data.flopCards[2] = flopCardsList[2];
                    data.turnCard = TurnCard;
                    break;
                case 3:
                    data.flopCards[0] = flopCardsList[0];
                    data.flopCards[1] = flopCardsList[1];
                    data.flopCards[2] = flopCardsList[2];
                    data.turnCard = TurnCard;
                    data.riverCard = RiverCard;
                    break;

            }
            string cardListString = "CardList: "+ CardPhase + " : ";
            foreach (var cards in data.flopCards)
                cardListString += cards.ToString() + ", ";
            cardListString += data.turnCard.ToString();
            cardListString += data.riverCard.ToString();
            //Debug.Log(cardListString);


            if (nextCardIndex>=3)
            {
                GameCardControl.getPlayerCardsResult(PlayerList[i].playerData.playerPosition, data, out dataOut);
                PlayerList[i].playerData.completeEvalData = dataOut;
                PlayerList[i].SetCardRankingText(PlayerList[i].playerData.completeEvalData.cardsResultValues.ToString());

                string bestFive = "";
                foreach (int ix in PlayerList[i].playerData.completeEvalData.bestFive)
                {
                    bestFive = bestFive + ix + " : ";
                }
                Debug.Log("" + PlayerList[i].PlayerName + " bestfive:" + bestFive);
            }
            else
            {
                if(PlayerList[i].playerData.card1data.rank == PlayerList[i].playerData.card2data.rank)
                    PlayerList[i].SetCardRankingText("Pair");
                else
                {
                    PlayerList[i].SetCardRankingText("High Card");
                }
                
            }
            

            //player.rankScores = CardEval.Evaluate(player.PlayerHand, BoardCard, cardShown); ;
            // player.playerData
            //player.SetCardRankingText(RankName.getString(player.rankScores[0]));
        }
        
    }
    public void PlayerSitBack(int actorNo)
    {
        DPokerPlayer[actorNo].UnshowCard();
        PlayerList.Remove(DPokerPlayer[actorNo]);
        DPokerPlayer.Remove(actorNo);
    }
    public GameObject rest;
    public void RoundStart()
    {
        ResultText.text = "";
        foreach (var pokerPlayer in PlayerList)
        {
            pokerPlayer.ShowBackCards();
            pokerPlayer.UnshowCard();
        }
        foreach(var pokerCard in TableCards)
        {
            pokerCard.ShowBack();
            pokerCard.gameObject.SetActive(false);
        }
            
    }
    public void RoundEnd()
    {
        //IEnumerable<PokerPlayer> query = PlayerList.OrderBy(player => player.PlayerHand[0]);
        ShowPlayerHandRankings();
        FindPokerWinner();
        flopCardsList.Clear();
        nextCardIndex = 0;
        //rest.SetActive(true);
    }
    public void Fold()
    {
        //IEnumerable<PokerPlayer> query = PlayerList.OrderBy(player => player.PlayerHand[0]);
        
        rest.SetActive(true);
    }











    public void FindPokerWinner()
    {
        int bestResult = 10;
        for (int x = 0; x < PlayerList.Count; x++)
        {
            Debug.Log("-----------------------------------------------");
            //Debug.Log("++++++++++ Result idx : " + PlayerList[x].playerData.playerPosition);
            Debug.Log("++++ Result idx : " + PlayerList[x].playerData.playerPosition + "++++++ Result result : " + PlayerList[x].playerData.completeEvalData.cardsResultValues);
            //TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeResultStruct.cardsResultValues + "\n";
            string bestFive = "";
            foreach (int i in PlayerList[x].playerData.completeEvalData.bestFive)
            {
                bestFive = bestFive + i + " : ";
            }
            Debug.Log(PlayerList[x].PlayerName + "- bestfive:" + bestFive);
            // TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeResultStruct.kikers.ToString() + "\n";
            Debug.Log("-----------------------------------------------");
            if ((int)PlayerList[x].playerData.completeEvalData.cardsResultValues < bestResult) bestResult = (int)PlayerList[x].playerData.completeEvalData.cardsResultValues;
        }

        Debug.Log("bestResult : " + (CardsResultValues)bestResult);

        List<PlayerData> pdWinnerList = new List<PlayerData>();

        for (int x = 0; x < PlayerList.Count; x++)
        {
            if (PlayerList[x].playerData.completeEvalData.cardsResultValues == (CardsResultValues)bestResult)
            {
                pdWinnerList.Add(PlayerList[x].playerData);
            }
        }
        List<PlayerData> finalWinners = new List<PlayerData>();
        Debug.Log("pdWinnerList Count : " + pdWinnerList.Count);
        for (int x = 0; x < pdWinnerList.Count; x++)
        {
            //TextResult.text = TextResult.text + "Winner : " + pdWinnerList[x].playerPosition + " result : " + pdWinnerList[x].completeResultStruct.cardsResultValues + "\n";
            Debug.Log("Winner : " + pdWinnerList[x].playerName + " result : " + pdWinnerList[x].completeEvalData.cardsResultValues + "\n");
            finalWinners.Add(pdWinnerList[x]);
        }


        string winnersResult = "";
        if (pdWinnerList.Count > 1)
        {
            finalWinners.Clear();
            winnersResult = "";
            switch ((CardsResultValues)bestResult)
            {
                case CardsResultValues.HighCard:
                    finalWinners = GameCardControl.getWinnerCheck_HighCard(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.Pair:
                    finalWinners = GameCardControl.getWinnerCheck_Pair(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.TwoPair:
                    finalWinners = GameCardControl.getWinnerCheck_TwoPair(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.ThreeOfAkind:
                    finalWinners = GameCardControl.getWinnerCheck_Tris(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.Straight:
                    finalWinners = GameCardControl.getWinnerCheck_Straight(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.Flush:
                    finalWinners = GameCardControl.getWinnerCheck_Flush(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.FullHouse:
                    finalWinners = GameCardControl.getWinnerCheck_FullHouse(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.FourOfAkind:
                    finalWinners = GameCardControl.getWinnerCheck_FourOfKind(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
                case CardsResultValues.StraightFlush:
                    finalWinners = GameCardControl.getWinner_StraightFlush(pdWinnerList);
                    foreach (PlayerData pd in finalWinners)
                    {
                        winnersResult = winnersResult + "FINAL WIN NUMBER : " + finalWinners.Count + " WINNER : " + pd.playerName + "\n";
                    }
                    break;
            }
        }
        string playersWinners = "";
        foreach (var player in finalWinners)
            playersWinners += player.playerName +".. ";
        if (finalWinners.Count == 1)
            ResultText.text = "Winner Player : " + playersWinners;
        else
        {
            
            //Debug.Log(player.PlayerName);
            Debug.Log("Draw!, Split pot with");
            ResultText.text = "Draw!, Split pot with " + playersWinners;
            isDraw = true;
        }
        Debug.Log(winnersResult);
    }
    public void FindWinner(List<PokerPlayer> players)
    {
        
        List<PokerPlayer> sortedPlayers = players.OrderByDescending(p => p.rankScores[0]).ToList();
        
        int topPlayerCardRank = sortedPlayers[0].rankScores[0];

      
        List<PokerPlayer> topPlayers = sortedPlayers.TakeWhile(p => p.rankScores[0] == topPlayerCardRank).ToList();

        
        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
            return;
        }

        
        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[1]).ToList();
        int topPlayerHighCard1 = topPlayers[0].rankScores[1];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[1] == topPlayerHighCard1).ToList();

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
            return;
        }

       
        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[2]).ToList();
        int topPlayerHighCard2 = topPlayers[0].rankScores[2];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[2] == topPlayerHighCard2).ToList();

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            ResultText.text = "Winner Player : " + (topPlayers[0]).PlayerName;
        }
        else
        {
            string playersWinners = "";
            foreach (var player in topPlayers)
                playersWinners += player.PlayerName + ", ";
                //Debug.Log(player.PlayerName);
            Debug.Log("Draw!, Split pot with");
            ResultText.text = "Draw!, Split pot with " + playersWinners;
            isDraw = true;

        }
    }

    public void RestartGame()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    bool isDraw;
    IEnumerator StartSim()
    {
        yield return new WaitForSeconds(0.1f);
        PokerServManager.instance.PlayerJoinAddMax();
        yield return new WaitForSeconds(0.2f);
        PokerServManager.instance.StartGame();
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 4; i++)
            PokerServManager.instance.NextDeal();
        yield return new WaitForSeconds(0.2f);
        if (isDraw)
            yield break;
        else
            PokerServManager.instance.RestartGame();
    }
    void AddTestPlayers()
    {
        Instantiate(PokerPlayerPrefab, PlayersTransform[0], false);
        //PokerPlayerPrefab.transform.set
        for (int i = 0; i < PlayersTransform.Count; i++)
        {
            Instantiate(PokerPlayerPrefab, PlayersTransform[i], false);
        }
    }

}
