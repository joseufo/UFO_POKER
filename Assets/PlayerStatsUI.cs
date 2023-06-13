using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] TMP_Text PlayerNameText;
    [SerializeField] TMP_Text SeatNoText;
    [SerializeField] TMP_Text RoleText;
    [SerializeField] TMP_Text HandRankingText;
    [SerializeField] TMP_Text CoinsText;
    [SerializeField] TMP_Text InfoText;

    [SerializeField] Image PlayerTurnFillImage;

    GameObject InfoParentObj;


    Vector3 scaleTurnFill;
    private void Start()
    {
        scaleTurnFill = PlayerTurnFillImage.transform.localScale;
        InfoParentObj = InfoText.transform.parent.gameObject;
    }
    public void SetInitPlayerData(PlayerData playerData)
    {
        PlayerNameText.text = playerData.playerName;
        RoleText.text = "";
        SeatNoText.text = playerData.seatPos.ToString();
        CoinsText.text = playerData.Coins.ToString();

    }

    public void UpdateCoinText(float coinAmount)
    {
        CoinsText.text = "₹" + coinAmount.ToString();
    }
    public void SetPlayerRole(string playerRole)
    {
        RoleText.text = playerRole;
    }
    public void SetHandRanking(string handRank)
    {
        HandRankingText.text = handRank;
    }

    Tween fillTween ;
    
    public void ShowPlayerchoice(string choice)
    {
        InfoText.text = choice;
        InfoParentObj.transform.DOKill();
        InfoParentObj.SetActive(true);
        InfoParentObj.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.05f).OnComplete(delegate { InfoParentObj.transform.localScale = new Vector3(1, 1, 1); InfoParentObj.SetActive(false); });
    }
    public void ShowPlayerTimer()
    {
        
        PlayerTurnFillImage.DOKill();
        PlayerTurnFillImage.transform.parent.DOScale(scaleTurnFill * 1.2f, 0.15f);
        PlayerTurnFillImage.gameObject.SetActive(true);
        PlayerTurnFillImage.fillAmount = 1f;
       
         PlayerTurnFillImage.DOFillAmount(0f, 15f).OnComplete(HidePlayerTimer);
    }
    public void HidePlayerTimer()
    {
        
        PlayerTurnFillImage.transform.parent.DOScale(scaleTurnFill, 0.1f).OnComplete(delegate { PlayerTurnFillImage.gameObject.SetActive(false); });
        
    }
}
