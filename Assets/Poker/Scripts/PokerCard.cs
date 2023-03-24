using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCard : MonoBehaviour
{
    // Start is called before the first frame update

    //public Sprite cardSprite;
    public Card CardData;

    
    void Start()
    {

        
       

    }
    public void SetCardData(Card.SUIT suit, Card.VALUE cardValue)
    {
        CardData.Suit = suit;
        CardData.Value = cardValue;
        SetCardSprite(suit, cardValue);
    }
    //public (Card.Suit, int) GetCardData()
    //{
    //    return (CardData.suit, CardData.rank);
    //}

    void SetCardSprite(Card.SUIT suit, Card.VALUE cardValue)
    {
        GetComponent<SpriteRenderer>().sprite = PokerCardManager.instance.GetCardSprite(suit, cardValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
