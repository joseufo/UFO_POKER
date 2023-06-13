using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PokerPlayer : MonoBehaviour
{

    public string PlayerName { get; set; }
  

    [SerializeField] GameObject UIPrefab;
    [SerializeField] Transform PlayerUIPos;
    [SerializeField] GameObject TableBetObj;
    [SerializeField] GameObject BetObj;
    Vector3 betObjInitPosition;
    TMP_Text amountPlacedtxt;
    public bool isLocalPlayer;
    GameObject PlayerUIObject;
    [System.NonSerialized]public PlayerStatsUI playerUI;
    public PlayerData playerData = new PlayerData();
    // Start is called before the first frame update
    [SerializeField] PokerCard Card1, Card2;
    public int spawnIndex=-1;
    public Card[] PlayerHand = new Card[2];
    [System.NonSerialized] public int[] rankScores = new int[3] { 0, 0, 0, };
    
    private void Awake()
    {
        PlayerUIObject = Instantiate(UIPrefab, PlayerUIPos, false);
        playerUI = PlayerUIObject.GetComponent<PlayerStatsUI>();
        PlayerUIObject.SetActive(false);
        amountPlacedtxt = TableBetObj.transform.GetChild(0).GetComponent<TMP_Text>();
        TableBetObj.SetActive(false);
        betObjInitPosition = BetObj.transform.position;
        BetObj.SetActive(false);
    }
    
    //public List<PokerCard> PlayerHand = new List<PokerCard>();
    public void SetInitPlayerData()
    {
        PlayerUIObject.SetActive(true);
        playerUI.SetInitPlayerData(playerData);
        ClearBets();
        //BetObject.SetActive(true);
    }
    public void RemovePlayer()
    {
        ShowBackCards();
        UnshowCard();
        
        PlayerUIObject.SetActive(false);
    }
   
    float currentPlacedAmount=0;
    public void PlaceBetAmount(float amount)
    {
        playerData.Coins -= amount;
        currentPlacedAmount += amount;
        //amountPlacedtxt.text = "₹"+amount.ToString();
        playerUI.UpdateCoinText(playerData.Coins);
        
        BetObj.SetActive(true);
        BetObj.transform.position = betObjInitPosition;
        BetObj.transform.GetChild(0).GetComponent<TMP_Text>().text = "₹" + amount.ToString();
        BetObj.transform.DOMove(TableBetObj.transform.position, 0.2f).OnComplete(delegate {amountPlacedtxt.text = "₹"+currentPlacedAmount.ToString(); BetObj.SetActive(false); TableBetObj.SetActive(true); });
    }
    public void ClearBets()
    {
        currentPlacedAmount = 0;
        TableBetObj.SetActive(false);
    }
    public void SetAndShowPlayerCards(Card cardData1, Card cardData2)
    {
       

        Card1.SetAndShowCard(cardData1);
        //PlayerHand[0] = new Card();
        playerData.card1data = cardData1;
        
        PlayerHand[0] = cardData1;
        playerData.card2data = cardData2;
        Card2.SetAndShowCard(cardData2);

        //PlayerHand[1] = new Card();
        PlayerHand[1] = cardData2;
    }
    string[] playerRoles = new string[4] { "D", "SB", "BB", "" };
    public void SetPlayerRole(int playerRole)
    {
        playerUI.SetPlayerRole(playerRoles[playerRole]);
    }
    public void ShowBackCards()
    {
        Card1.ShowBack();
        Card2.ShowBack();
    }

    public void UnshowCard()
    {
        Card1.gameObject.SetActive(false);
        Card2.gameObject.SetActive(false);
    }

    public void SetCardRankingText(string cardRanking)
    {
        playerUI.SetHandRanking(cardRanking);
    }
   
    public void GivePlayerCoins(float amount, Transform totalPotTransform)
    {
       
        BetObj.transform.position = totalPotTransform.position;
        BetObj.transform.GetChild(0).GetComponent<TMP_Text>().text = "₹" + amount.ToString();
        BetObj.SetActive(true);
        playerData.Coins += amount;
        BetObj.transform.DOMove(betObjInitPosition, 0.7f).OnComplete(delegate { playerUI.UpdateCoinText(playerData.Coins); BetObj.SetActive(false); });
    }
    
    
    
}
