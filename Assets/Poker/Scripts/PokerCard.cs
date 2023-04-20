using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCard : MonoBehaviour
{
    // Start is called before the first frame update

    //public Sprite cardSprite;
   
    public Card CardData;
    Sprite backSprite;
    
    void Start()
    {

        backSprite = PokerCardManager.instance.BackSprite;
       

    }
    public void ShowBack()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<SpriteRenderer>().sprite = PokerCardManager.instance.BackSprite;
    }
    public void SetAndShowCard(Card cardData)
    {
        this.name = cardData.ToString();
        this.CardData = cardData;
        //SetCardSprite();
        
        this.gameObject.SetActive(true);
        StartCoroutine(RotShowCard(this.transform, transform, PokerCardManager.instance.GetCardSprite(CardData.Suit, CardData.Value)));

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
    float uncoverTime=3;
    IEnumerator RotShowCard(Transform card, bool uncover, Sprite frontSprite)
    {

        float minAngle = uncover ? 0 : 180;
        float maxAngle = uncover ? 180 : 0;
        card.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        float t = 0;
        bool uncovered = false;

        while (t < 1f)
        {
            t += Time.deltaTime * uncoverTime; ;

            float angle = Mathf.LerpAngle(minAngle, maxAngle, t);
            card.eulerAngles = new Vector3(0, angle, 0);

            if (((angle >= 90 && angle < 180) || (angle >= 270 && angle < 360)) && !uncovered)
            {
                uncovered = true;
                if (uncover)
                {
                    card.gameObject.GetComponent<SpriteRenderer>().sprite = frontSprite;
                    card.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    card.gameObject.GetComponent<SpriteRenderer>().sprite = backSprite;
                    card.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                
            }

            yield return null;
        }

        yield return 0;
    }

}
