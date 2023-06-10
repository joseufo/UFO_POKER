using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class PokerUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static PokerUIManager instance;
    public List<Sprite> ClubSprites, DiamondSprites, HeartSprites, SpadeSprites = new List<Sprite>();
    public Sprite CardBackSprite;
    [SerializeField] RectTransform PlayerChoicePanel;
    Vector3 playerChoicePanelPos;

    [SerializeField] List<Button> UIButtons;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        foreach(var button in UIButtons)
        {
            
            button.onClick.AddListener(delegate { ButtonClickAnim(button.GetComponent<RectTransform>()); });
        }
        playerChoicePanelPos = PlayerChoicePanel.localPosition;
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
    private void ButtonClickAnim(RectTransform buttonTransform)
    {
        // Perform the desired animation using DOTween
        buttonTransform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                // Perform any additional actions after the animation is complete
                buttonTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutBack);
            });
    }

    public void ShowInPlayerChoicePanel()
    {
        PlayerChoicePanel.DOLocalMoveY(playerChoicePanelPos.y, 0.4f).SetEase(Ease.OutCubic);
    }

    public void HideOutPlayerChoicePanel()
    {
        PlayerChoicePanel.DOLocalMoveY(playerChoicePanelPos.y - PlayerChoicePanel.rect.height, 0.4f).SetEase(Ease.OutCubic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
