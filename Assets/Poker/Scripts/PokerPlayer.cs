using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokerPlayer : MonoBehaviour
{
    public TMP_Text playerText;
    public TMP_Text rankingText;
    public int TotalPlayers { get; set; } = 2;
    public int TurnPosition { get; set; } = 0;
    //public int[] PlayerStatus { get; set; }  // [id, callraisefolded, chips, chips wagered] 
    public int DeckState { get; set; } = 0;

    public int Chips { get; set; } = 1000;
    public Card[] PlayerHand = new Card[2];
    public int PlayerID { get; set; } = -1;
    public bool Folded { get; set; } = false;
    public bool Called { get; set; } = false;
    public bool Raised { get; set; } = false;
    public bool Checked { get; set; } = false;
    public int RaiseAmount { get; set; } = 0;
    public int PotSize { get; set; } = 0;

    // Start is called before the first frame update
    [SerializeField] PokerCard Card1, Card2;
   
    void Start()
    {
        //handCards = new Hand();
        //SetInitialCards(Card.Suit.Diamonds, Random.Range(2, 13), Card.Suit.Spades, Random.Range(2, 13));
       // AddTestCardHand();
    }
    //public List<PokerCard> PlayerHand = new List<PokerCard>();
    



    //public void SetInitialCards(Card.SUIT card1Suit, int card1Rank, Card.CSuit card2Suit , int card2Rank)
    //{
    //    Card1.SetCardData(card1Suit, card1Rank);
    //    Card2.SetCardData(card2Suit, card2Rank);
    //    playerHandCards.Add(Card1.CardData);
    //    playerHandCards.Add(Card2.CardData);
      
        
    //    foreach(var card in playerHandCards)
    //    {
    //        Debug.Log(card.suit + ", " + card.rank);
    //    }
            
    //}

    
    
    
}
