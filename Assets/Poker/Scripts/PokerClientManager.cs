using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerClientManager : MonoBehaviour
{
    public static PokerClientManager instance;

    [SerializeField] Transform LocalPlayerPosition;
    [SerializeField] List<Transform> OtherPlayers = new List<Transform>();
    [SerializeField] GameObject PokerPlayerPrefab;

    public List<PokerPlayer> PlayerList = new List<PokerPlayer>();
    private void Start()
    {
        JoinGame();
    }


    public void JoinGame()
    {
        var player = Instantiate(PokerPlayerPrefab, LocalPlayerPosition, false);
        PlayerList.Add(player.GetComponent<PokerPlayer>());
    }

    public void AddOpponent()
    {

    }

    void AddTestPlayers()
    {
        Instantiate(PokerPlayerPrefab, LocalPlayerPosition, false);
        //PokerPlayerPrefab.transform.set
        for (int i = 0; i < OtherPlayers.Count; i++)
        {
            Instantiate(PokerPlayerPrefab, OtherPlayers[i], false);
        }
    }
}
