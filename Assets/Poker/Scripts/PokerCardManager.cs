using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCardManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static PokerCardManager instance;
    public List<Sprite> ClubSprites, DiamondSprites, HeartSprites, SpadeSprites = new List<Sprite>();
    public Sprite BackSprite;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        
    }
    public Sprite GetCardSprite(SUIT cardSuit, VALUE cardValue)
    {   
        //if((int)cardValue == 1) cardValue = (VALUE)
        int cardIndex = (int)cardValue - 2;  // [0]Two, [1]Three, [2]Four, [3]Five, [4]Six, [5]Seven, [6]Eight, [7]Nine, [8]Ten, [9]Jack, [10]Queen [11]King, [12]Ace
        if (cardIndex < 0) cardIndex = 12;
        switch (cardSuit)
        {
            case SUIT.CLUBS:
                return ClubSprites[cardIndex];                
            case SUIT.DIAMONDS:
                return DiamondSprites[cardIndex];
            case SUIT.HEARTS:
                return HeartSprites[cardIndex];
            case SUIT.SPADES:
                return SpadeSprites[cardIndex];                
        }
        return null;
    }
  

   

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
