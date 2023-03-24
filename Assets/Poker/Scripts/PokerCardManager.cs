using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCardManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static PokerCardManager instance;
    public List<Sprite> ClubSprites, DiamondSprites, HeartSprites, SpadeSprites = new List<Sprite>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        
    }
    public Sprite GetCardSprite(Card.SUIT cardSuit, Card.VALUE cardValue)
    {
        int cardIndex = (int)cardValue - 2;
        switch (cardSuit)
        {
            case Card.SUIT.CLUBS:
                return ClubSprites[cardIndex];                
            case Card.SUIT.DIAMONDS:
                return DiamondSprites[cardIndex];
            case Card.SUIT.HEARTS:
                return HeartSprites[cardIndex];
            case Card.SUIT.SPADES:
                return SpadeSprites[cardIndex];                
        }
        return null;
    }
  

   

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
