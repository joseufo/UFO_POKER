using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class PokerClientManager : MonoBehaviour
{

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

    int cardShown = 0;

    EvalHand CardEval = new EvalHand();
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        JoinGame();
    }
    


    public void JoinGame()
    {
        var player = Instantiate(PokerPlayerPrefab, PlayersTransform[0], false);
        player.GetComponent<PokerPlayer>().isLocalPlayer = true;
        player.GetComponent<PokerPlayer>().PlayerName = "Player0";
        PlayerList.Add(player.GetComponent<PokerPlayer>());
    }

    public void AddOpponent()
    {
        if (opponentCount == maxPlayers - 1) return;
        opponentCount++;
        var newPlayer = Instantiate(PokerPlayerPrefab, PlayersTransform[opponentCount], false);
        PlayerList.Add(newPlayer.GetComponent<PokerPlayer>());
    }
    Ranks RankName = new Ranks();
    public void SetBoardTableCard(List<Card> cardList)
    {
        foreach(var card in cardList)
        {
            TableCards[cardShown].SetAndShowCard(card);
            TableCards[cardShown].gameObject.SetActive(true);
            BoardCard[cardShown] = card;
            cardShown++;
        }
        ShowPlayerHandRankings();


    }
    public void ShowPlayerHandRankings()
    {
        foreach (var player in PlayerList)
        {
            
            player.rankScores = CardEval.Evaluate(player.PlayerHand, BoardCard, cardShown); ;
            player.SetCardRankingText(RankName.getString(player.rankScores[0]));
        }
    }

    public void GameEnd()
    {
        //IEnumerable<PokerPlayer> query = PlayerList.OrderBy(player => player.PlayerHand[0]);
        FindWinner(PlayerList);
    }
    public static void FindWinner(List<PokerPlayer> players)
    {
        
        List<PokerPlayer> sortedPlayers = players.OrderByDescending(p => p.rankScores[0]).ToList();
        
        int topPlayerCardRank = sortedPlayers[0].rankScores[0];

      
        List<PokerPlayer> topPlayers = sortedPlayers.TakeWhile(p => p.rankScores[0] == topPlayerCardRank).ToList();

        
        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            return;
        }

        
        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[1]).ToList();
        int topPlayerHighCard1 = topPlayers[0].rankScores[1];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[1] == topPlayerHighCard1).ToList();

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
            Debug.Log("Winner Player : " + (topPlayers[0]).PlayerName);
            return;
        }

       
        topPlayers = topPlayers.OrderByDescending(p => p.rankScores[2]).ToList();
        int topPlayerHighCard2 = topPlayers[0].rankScores[2];
        topPlayers = topPlayers.TakeWhile(p => p.rankScores[2] == topPlayerHighCard2).ToList();

        if (topPlayers.Count == 1)
        {
            //Debug.Log("Winner: Player " + (players.IndexOf(topPlayers[0]) + 1));
        }
        else
        {
            Debug.Log("Draw!, Split pot with");
            foreach (var player in topPlayers)
                Debug.Log(player.PlayerName);
        }
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
}
