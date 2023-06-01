using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] TMP_Text PlayerNameText;
    [SerializeField] TMP_Text SeatNoText;
    [SerializeField] TMP_Text RoleText;
    [SerializeField] TMP_Text HandRankingText;
    [SerializeField] TMP_Text CoinsText;

    public void SetInitPlayerData(PlayerData playerData)
    {
        PlayerNameText.text = playerData.playerName;
        RoleText.text = "";
        SeatNoText.text = playerData.seatPos.ToString();
        CoinsText.text = playerData.Coins.ToString();

    }

    public void UpdateCoinText(float coinAmount)
    {
        CoinsText.text = coinAmount.ToString();
    }
    public void SetPlayerRole(string playerRole)
    {
        RoleText.text = playerRole;
    }
    public void SetHandRanking(string handRank)
    {
        HandRankingText.text = handRank;
    }
}
