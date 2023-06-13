using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
[System.Serializable]
public class PlayerData
{


    public string playerName;
    public int seatPos;
    public int playerActorNo;
    public int playerRole;
    public bool isLocalPlayer = false;

    public float Coins;

    public float betAmount;


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
    [NonSerialized] public bool isGameStarted;
    [SerializeField] List<Transform> PlayersTransform = new List<Transform>();
    [SerializeField] GameObject PokerPlayerPrefab;

    public int maxPlayers = 5;
    int opponentCount = 0;
    [SerializeField] GameObject[] PlayerObjects = new GameObject[5];

    List<PokerPlayer> RoomPlayerList = new List<PokerPlayer>();
    List<PokerPlayer> CurrentRoundPlayers = new List<PokerPlayer>();

    public List<PokerCard> TableCards = new List<PokerCard>();


    List<Card> flopCardsList = new List<Card>();
    Card TurnCard = Card.nullCard, RiverCard = Card.nullCard;

    int nextCardIndex = 0;
    bool useFlopCars, useTurnCard, useRiverCard;
    //EvalHand CardEval = new EvalHand();
    //<actNr, player>
    public Dictionary<int, PokerPlayer> DPokerRoomPlayers = new Dictionary<int, PokerPlayer>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    List<int> SpawnMapIndex = new List<int>();
    private void Start()
    {
        //OnJoinedGame();
        //StartCoroutine(StartSim());
        for(int i=1; i<=PlayerObjects.Length-1; i++)
        {
            SpawnMapIndex.Add(i);
           
        }
    }



    public void AddLocalPlayer(PlayerData newPlayerData)
    {
        var playerObj = PlayerObjects[0];//Instantiate(PokerPlayerPrefab, PlayersTransform[0], false);
        var pokerPlayer = playerObj.GetComponent<PokerPlayer>();
        pokerPlayer.isLocalPlayer = true;
        //player.GetComponent<PokerPlayer>().PlayerName = "Player0";
        //player.GetComponent<PokerPlayer>().playerData.playerName = "Player0";
        pokerPlayer.playerData = newPlayerData;
        pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
        pokerPlayer.spawnIndex = 0;
        pokerPlayer.SetInitPlayerData();
        RoomPlayerList.Add(pokerPlayer);
        //CurrentRoundPlayers.Add(playerObj.GetComponent<PokerPlayer>());
        DPokerRoomPlayers.Add(pokerPlayer.playerData.playerActorNo, pokerPlayer);

    }
    public void GivePlayerCards(Card card1, Card card2)
    {
        CurrentRoundPlayers[0].SetAndShowPlayerCards(card1, card2);
        if (CurrentRoundPlayers[0].playerData.card1data.rank == CurrentRoundPlayers[0].playerData.card2data.rank)
            CurrentRoundPlayers[0].SetCardRankingText("Pair");
        else
        {
            CurrentRoundPlayers[0].SetCardRankingText("High Card");
        }
        for (int i = 1; i < CurrentRoundPlayers.Count; i++)
        {
            Debug.Log("NAME" + CurrentRoundPlayers[i].PlayerName);
            CurrentRoundPlayers[i].ShowBackCards();
            CurrentRoundPlayers[i].SetCardRankingText("");
        }
    }
   
    public void AddRoomOpponents(List<PlayerData> playerDataList)
    {
        playerDataList = playerDataList.OrderByDescending(player => player.seatPos).ToList();
        int count = playerDataList.Count;
        for (int i = 0; i < playerDataList.Count; i++)
        {
            opponentCount++;
            var newPlayer = PlayerObjects[opponentCount];// Instantiate(PokerPlayerPrefab, PlayersTransform[opponentCount], false);
            var pokerPlayer = newPlayer.GetComponent<PokerPlayer>();
            pokerPlayer.playerData = playerDataList[i];
            pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
            pokerPlayer.spawnIndex = i;
            pokerPlayer.SetInitPlayerData();
            RoomPlayerList.Add(pokerPlayer);//CurrentRoundPlayers.Add(pokerPlayer);
            DPokerRoomPlayers.Add(pokerPlayer.playerData.playerActorNo, pokerPlayer);
            SpawnMapIndex.Remove(i);
        }
        printMapIndex();
    }

    public void AddOpponent(PlayerData newPlayerData)
    {
        if (opponentCount == maxPlayers - 1) return;
        opponentCount++;
        int spawnIndex = SpawnMapIndex[SpawnMapIndex.Count - 1];
        var playerObj = PlayerObjects[spawnIndex]; //Instantiate(PokerPlayerPrefab, PlayersTransform[mapIndex[spawnIndex]], false);
        var pokerPlayer = playerObj.GetComponent<PokerPlayer>();
        pokerPlayer.playerData = newPlayerData;
        pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
        pokerPlayer.spawnIndex = spawnIndex;
        pokerPlayer.SetInitPlayerData();
        RoomPlayerList.Add(pokerPlayer);   // CurrentRoundPlayers.Add(pokerPlayer);
        DPokerRoomPlayers.Add(pokerPlayer.playerData.playerActorNo, pokerPlayer);
        SpawnMapIndex.Remove(spawnIndex);
        printMapIndex();
    }
    public void AddAllRoomOpponents(List<PlayerData> playerDataList)
    {
        playerDataList = playerDataList.OrderByDescending(player => player.seatPos).ToList();
        int count = playerDataList.Count;
        for (int i = 0; i < playerDataList.Count; i++)
        {
            opponentCount++;
            var newPlayer = Instantiate(PokerPlayerPrefab, PlayersTransform[opponentCount], false);
            var pokerPlayer = newPlayer.GetComponent<PokerPlayer>();
            pokerPlayer.playerData = playerDataList[i];
            pokerPlayer.PlayerName = pokerPlayer.playerData.playerName;
            pokerPlayer.SetInitPlayerData();
            CurrentRoundPlayers.Add(pokerPlayer);
            DPokerRoomPlayers.Add(pokerPlayer.playerData.playerActorNo, CurrentRoundPlayers[CurrentRoundPlayers.IndexOf(pokerPlayer)]);
            SpawnMapIndex.Remove(i);
        }
        printMapIndex();
    }
    public void RoundStart(Dictionary<int, int> playerRolesActors, int[] currentRoundActors, float smallBlindAmount, float bigBlindAmount)
    {

        ResultText.text = "";
        //foreach (var roomPlayer in RoomPlayerList)
        //    CurrentRoundPlayers.Add(roomPlayer);
        CurrentRoundPlayers.Add(RoomPlayerList[0]);
        foreach (var actor in currentRoundActors)
        {
            if (actor != CurrentRoundPlayers[0].playerData.playerActorNo) ;
            CurrentRoundPlayers.Add(DPokerRoomPlayers[actor]);
        }
        foreach (var pokerPlayer in CurrentRoundPlayers)
        {
            pokerPlayer.ShowBackCards();
            pokerPlayer.UnshowCard();
            pokerPlayer.SetPlayerRole(3);
        }
        foreach (var pokerCard in TableCards)
        {
            pokerCard.ShowBack();
            pokerCard.gameObject.SetActive(false);
        }
        StartCoroutine(Playerblinds(playerRolesActors, smallBlindAmount, bigBlindAmount));

    }
    IEnumerator Playerblinds(Dictionary<int, int> playerRolesActors, float smallBlindAmount, float bigBlindAmount)
    {
        foreach (var actor in playerRolesActors.Keys)
        {
            var role = playerRolesActors[actor];
            DPokerRoomPlayers[actor].SetPlayerRole(role);
            if (role == 1)
                DPokerRoomPlayers[actor].PlaceBetAmount(smallBlindAmount);
            else if (role == 2)
                DPokerRoomPlayers[actor].PlaceBetAmount(bigBlindAmount);
        }
        //DPokerRoomPlayers[playerRolesActors[0]].SetPlayerRole(0); DPokerRoomPlayers[playerRolesActors[1]].SetPlayerRole(1); DPokerRoomPlayers[playerRolesActors[2]].SetPlayerRole(2);
        //DPokerRoomPlayers[playerRolesActors[1]].PlaceBetAmount(smallBlindAmount); DPokerRoomPlayers[playerRolesActors[2]].PlaceBetAmount(bigBlindAmount);
        TotalPokerPot += smallBlindAmount + bigBlindAmount;
        yield return new WaitForSecondsRealtime(0.5f);
    }
    public IEnumerator RoundEnd(Dictionary<int, float> winnerPlayersAmount, int[] playerQuitActors, bool allFoldwinner)
    {
        //IEnumerable<PokerPlayer> query = PlayerList.OrderBy(player => player.PlayerHand[0]);
        InitializePlayerTurnImage(-1);
        PotTotalSet();

        yield return new WaitForSecondsRealtime(1f);
        if(!allFoldwinner)
        ShowPlayerHandRankings();
        //FindPokerWinner();
        foreach (var playerActor in winnerPlayersAmount.Keys)
        {
            var amount = winnerPlayersAmount[playerActor];
            TotalPokerPot -= amount;
            PokerTotalPotObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "₹"+TotalPokerPot.ToString();
            DPokerRoomPlayers[playerActor].GivePlayerCoins(amount, PokerTotalPotObject.transform);
        }
        foreach(var actor in playerQuitActors)
        {
            PlayerQuitRemove(actor);
        }

        ResetAll();
        //rest.SetActive(true);
    }
    void ResetAll()
    {
        flopCardsList.Clear();
        nextCardIndex = 0;
        CurrentRoundPlayers.Clear();
    }
    [SerializeField] GameObject PokerTotalPotObject;
    [SerializeField] GameObject PlayersPots;
    private float TotalPokerPot = 0;
    public void PlacePlayerBet(int actor, float betAmount, bool isRaise)
    {
        if (betAmount <= 0)
        {
            DPokerRoomPlayers[actor].playerUI.ShowPlayerchoice("CHECK");
            return;
        }

        if (isRaise) DPokerRoomPlayers[actor].playerUI.ShowPlayerchoice("RAISE");
        else DPokerRoomPlayers[actor].playerUI.ShowPlayerchoice("CALL");
        DPokerRoomPlayers[actor].PlaceBetAmount(betAmount);
        TotalPokerPot += betAmount;
    }
    public void PlayerFold(int actor)
    {

        DPokerRoomPlayers[actor].playerUI.ShowPlayerchoice("FOLD");
        DPokerRoomPlayers[actor].ShowBackCards();
        DPokerRoomPlayers[actor].UnshowCard();
        //IEnumerable<PokerPlayer> query = PlayerList.OrderBy(player => player.PlayerHand[0]);

       
    }
    public void ClearPlayerBets()
    {
        foreach (var player in CurrentRoundPlayers)
        {
            player.ClearBets();
        }
    }

    void printMapIndex() { string indd = ""; foreach (var id in SpawnMapIndex) { indd += ", " + id; } Debug.Log("MAPINDEX: " + indd); }
    int CardPhase = 0;

    public IEnumerator SetPokerPhaseCards(List<Card> cardList, int cardPhase)
    {
        InitializePlayerTurnImage(-1);
        PotTotalSet();
        yield return new WaitForSecondsRealtime(0.5f);
        CardPhase = cardPhase;
        switch (cardPhase)
        {
            case 1:

                foreach (var card in cardList)
                {
                    flopCardsList.Add(card);
                    TableCards[nextCardIndex].SetAndShowCard(card);
                    TableCards[nextCardIndex].gameObject.SetActive(true);
                    nextCardIndex++;
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
            case 5:
                if (flopCardsList.Count == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        flopCardsList.Add(cardList[i]);
                        TableCards[i].SetAndShowCard(cardList[i]);
                        TableCards[i].gameObject.SetActive(true);
                    }
                }

                if (!TableCards[3].gameObject.activeSelf)
                {
                    TurnCard = cardList[3];
                    TableCards[3].SetAndShowCard(cardList[3]);
                    TableCards[3].gameObject.SetActive(true);
                }
                nextCardIndex = 4;                                  //change for display playerrankinggs with cardphase
                if (!TableCards[4].gameObject.activeSelf)
                {
                    TurnCard = cardList[4];
                    TableCards[4].SetAndShowCard(cardList[4]);
                    TableCards[4].gameObject.SetActive(true);
                }
                break;
        }
        string tableCards = "TableCards: ";
        for (int i = 0; i < TableCards.Count; i++)
            tableCards += TableCards[i].CardData + ", ";
        if (cardPhase == 3)
            Debug.Log(tableCards);
        ShowLocalPlayerRanking();

        //ShowPlayerHandRankings();
        //ClearPlayerBets();

    }
    void PotTotalSet()
    {
        foreach (Transform gameObj in PlayersPots.transform)
        {
            if (gameObj.gameObject.activeSelf)
            {
                var currentTransform = gameObj.position;
                gameObj.transform.DOMove(PokerTotalPotObject.transform.position, 0.4f).OnComplete(delegate
                {
                    PokerTotalPotObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "₹" + TotalPokerPot.ToString();
                    gameObj.transform.position = currentTransform; ClearPlayerBets();
                });
            }
        }
    }
    void ShowLocalPlayerRanking()
    {
        EvalData data = new EvalData();
        EvalData dataOut = new EvalData();
        data.playerCard_1 = CurrentRoundPlayers[0].playerData.card1data;
        data.playerCard_2 = CurrentRoundPlayers[0].playerData.card2data;
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
            case 5:
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
            GameCardControl.getPlayerCardsResult(CurrentRoundPlayers[0].playerData.seatPos, data, out dataOut);
            CurrentRoundPlayers[0].playerData.completeEvalData = dataOut;
            CurrentRoundPlayers[0].SetCardRankingText(CurrentRoundPlayers[0].playerData.completeEvalData.cardsResultValues.ToString());

            string bestFive = "";
            foreach (int ix in CurrentRoundPlayers[0].playerData.completeEvalData.bestFive)
            {
                bestFive = bestFive + ix + " : ";
            }
            Debug.Log("" + CurrentRoundPlayers[0].PlayerName + " bestfive:" + bestFive);
        }
        else
        {
            if (CurrentRoundPlayers[0].playerData.card1data.rank == CurrentRoundPlayers[0].playerData.card2data.rank)
                CurrentRoundPlayers[0].SetCardRankingText("Pair");
            else
            {
                CurrentRoundPlayers[0].SetCardRankingText("High Card");
            }

        }

    }
    public void InitializePlayerTurnImage(int actorNo)
    {
        foreach (var actor in DPokerRoomPlayers.Keys)
        {
            if (actor != actorNo)
                DPokerRoomPlayers[actor].playerUI.HidePlayerTimer();
        }
        if (actorNo == -1) return;
        DPokerRoomPlayers[actorNo].playerUI.ShowPlayerTimer();
    }

    public void ShowPlayerHandRankings()
    {
        for (int i = 0; i < CurrentRoundPlayers.Count; i++)
        {
            EvalData data = new EvalData();
            EvalData dataOut = new EvalData();
            data.playerCard_1 = CurrentRoundPlayers[i].playerData.card1data;
            data.playerCard_2 = CurrentRoundPlayers[i].playerData.card2data;
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
                case 5:
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
                GameCardControl.getPlayerCardsResult(CurrentRoundPlayers[i].playerData.seatPos, data, out dataOut);
                CurrentRoundPlayers[i].playerData.completeEvalData = dataOut;
                CurrentRoundPlayers[i].SetCardRankingText(CurrentRoundPlayers[i].playerData.completeEvalData.cardsResultValues.ToString());

                string bestFive = "";
                foreach (int ix in CurrentRoundPlayers[i].playerData.completeEvalData.bestFive)
                {
                    bestFive = bestFive + ix + " : ";
                }
                Debug.Log("" + CurrentRoundPlayers[i].PlayerName + " bestfive:" + bestFive);
            }
            else
            {
                if (CurrentRoundPlayers[i].playerData.card1data.rank == CurrentRoundPlayers[i].playerData.card2data.rank)
                    CurrentRoundPlayers[i].SetCardRankingText("Pair");
                else
                {
                    CurrentRoundPlayers[i].SetCardRankingText("High Card");
                }

            }


            //player.rankScores = CardEval.Evaluate(player.PlayerHand, BoardCard, cardShown); ;
            // player.playerData
            //player.SetCardRankingText(RankName.getString(player.rankScores[0]));
        }

    }
    public void PlayerSitBack(int actorNo)
    {
        DPokerRoomPlayers[actorNo].UnshowCard();
        CurrentRoundPlayers.Remove(DPokerRoomPlayers[actorNo]);
        //DPokerRoomPlayers.Remove(actorNo);
    }

    void PlayerQuitRemove(int actor)
    {
        var player = DPokerRoomPlayers[actor];
        RoomPlayerList.Remove(player);
        player.RemovePlayer();
        SpawnMapIndex.Add(player.spawnIndex);

        DPokerRoomPlayers.Remove(actor);
    }
    public GameObject rest;













    public void FindPokerWinner()
    {
        int bestResult = 10;
        for (int x = 0; x < CurrentRoundPlayers.Count; x++)
        {
            Debug.Log("-----------------------------------------------");
            //Debug.Log("++++++++++ Result idx : " + PlayerList[x].playerData.playerPosition);
            Debug.Log("++++ Result idx : " + CurrentRoundPlayers[x].playerData.seatPos + "++++++ Result result : " + CurrentRoundPlayers[x].playerData.completeEvalData.cardsResultValues);
            //TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] cardsResultValues : " + pdList[x].completeResultStruct.cardsResultValues + "\n";
            string bestFive = "";
            foreach (int i in CurrentRoundPlayers[x].playerData.completeEvalData.bestFive)
            {
                bestFive = bestFive + i + " : ";
            }
            Debug.Log(CurrentRoundPlayers[x].PlayerName + "- bestfive:" + bestFive);
            // TextResult.text = TextResult.text + "[" + pdList[x].playerPosition + "] bestFive : " + bestFive + " kiker :" + pdList[x].completeResultStruct.kikers.ToString() + "\n";
            Debug.Log("-----------------------------------------------");
            if ((int)CurrentRoundPlayers[x].playerData.completeEvalData.cardsResultValues < bestResult) bestResult = (int)CurrentRoundPlayers[x].playerData.completeEvalData.cardsResultValues;
        }

        Debug.Log("bestResult : " + (CardsResultValues)bestResult);

        List<PlayerData> pdWinnerList = new List<PlayerData>();

        for (int x = 0; x < CurrentRoundPlayers.Count; x++)
        {
            if (CurrentRoundPlayers[x].playerData.completeEvalData.cardsResultValues == (CardsResultValues)bestResult)
            {
                pdWinnerList.Add(CurrentRoundPlayers[x].playerData);
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
            playersWinners += player.playerName + ".. ";
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
