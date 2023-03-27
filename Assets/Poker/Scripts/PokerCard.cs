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
    public void SetAndShowCard(Card cardData)
    {
        this.CardData = cardData;
        SetCardSprite();
        this.gameObject.SetActive(true); 

    }

    public void SetCard(Card cardData)
    {
        this.CardData = cardData;
        SetCardSprite();       

    }
    public void UnshowCard()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
    public void SetCardSprite()
    {
        GetComponent<SpriteRenderer>().sprite = PokerCardManager.instance.GetCardSprite(CardData.Suit, CardData.Value);
    }
    
    
}
