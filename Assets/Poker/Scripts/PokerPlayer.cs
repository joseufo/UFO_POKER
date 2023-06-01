using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokerPlayer : MonoBehaviour
{

    public string PlayerName { get; set; }
  

    [SerializeField] GameObject UIPrefab;
    [SerializeField] Transform PlayerUIPos;
    [SerializeField] GameObject BetObject;
    TMP_Text betAmountText;
    public bool isLocalPlayer;
    GameObject PlayerUIObject;
    PlayerStatsUI playerUI;
    public PlayerData playerData = new PlayerData();
    // Start is called before the first frame update
    [SerializeField] PokerCard Card1, Card2;

    public Card[] PlayerHand = new Card[2];
    [System.NonSerialized] public int[] rankScores = new int[3] { 0, 0, 0, };
    
    private void Awake()
    {
        PlayerUIObject = Instantiate(UIPrefab, PlayerUIPos, false);
        playerUI = PlayerUIObject.GetComponent<PlayerStatsUI>();
        PlayerUIObject.SetActive(false);
        betAmountText = BetObject.GetComponentInChildren<TMP_Text>();
        BetObject.SetActive(false);
    }
    
    //public List<PokerCard> PlayerHand = new List<PokerCard>();
    public void SetInitPlayerData()
    {
        PlayerUIObject.SetActive(true);
        playerUI.SetInitPlayerData(playerData);
        BetObject.SetActive(true);
    }
    IEnumerator BetAnim()
    {
        yield return null;
    }
    public void PutOutCoins(float amount)
    {
        playerData.Coins -= amount;
        betAmountText.text = amount.ToString();
        playerUI.UpdateCoinText(playerData.Coins);
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
   

    
    
    
}
