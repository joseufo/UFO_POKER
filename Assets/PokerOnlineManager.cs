using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

using System.Net;
public class PokerOnlineManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public bool connectOnline;
    public TMP_InputField NameInput;
    public Button JoinCreateButton;
    public TMP_Text InfoText;
    // Photon Event Codes from Server
    const byte TIMERGAMESTART = 101, ROUNDSTART = 105, INITSEAT = 111, SWITCHTURN = 115,
            FLOPCARDS = 121, TURNCARD = 122, RIVERCARD = 123, ROUNDEND = 125;
    // Photon Event Codes from User
    const byte CALL = 22, CHECK = 23, FOLD = 25, RAISE = 20;

    int minPlayers = 2, maxPlayers = 5;
    string playerNametest;

    bool isMyturn;
    void Start()
    {
        maxPlayers = 7;
        TESTFUNC(ref maxPlayers);
        JoinCreateButton.onClick.AddListener(() => JoinOrHostGame());
        JoinCreateButton.gameObject.transform.parent.gameObject.SetActive(true);
        JoinCreateButton.gameObject.SetActive(false);

        //var host = Dns.GetHostName
        //Debug.Log(host);
        //if (!connectOnline) return;
        PhotonNetwork.ConnectUsingSettings();
    }
    void TESTFUNC(ref int maxx)
    {
        //maxx = maxx - 3;
        //Debug.LogError(maxx + "--" + maxPlayers);
    }
    public void JoinOrHostGame()
    {

        if (String.IsNullOrEmpty(NameInput.text) || NameInput.text[0] == ' ')
            playerNametest = "Player" + UnityEngine.Random.Range(1, 10000);
        else
            playerNametest = NameInput.text;
        CreateOrJoinRoom();
        JoinCreateButton.gameObject.transform.parent.gameObject.SetActive(false);
        InfoText.text = "Joining/Hosting...";
        PhotonNetwork.LocalPlayer.NickName = playerNametest;
    }
    //Overriden callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        JoinCreateButton.gameObject.SetActive(true);
        //CreateOrJoinRoom();
        PhotonNetwork.LocalPlayer.NickName = playerNametest;



    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room, Room ID: " + PhotonNetwork.CurrentRoom.Name + " \n UserId : " + PhotonNetwork.LocalPlayer.UserId + "\n ActNo : " + PhotonNetwork.LocalPlayer.ActorNumber);
        InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
        //if(PhotonNetwork.CurrentRoom.CustomProperties["cSeat"] != null)

        int mySeat = (int)PhotonNetwork.CurrentRoom.CustomProperties["nSeat"];
        Debug.Log(mySeat);
        PlayerData dataPlayer = new PlayerData();
        dataPlayer.playerName = playerNametest;
        dataPlayer.playerActorNo = PhotonNetwork.LocalPlayer.ActorNumber;
        dataPlayer.playerPosition = mySeat;
        PokerClientManager.instance.AddLocalPlayer(dataPlayer);
        List<PlayerData> roomPlayerList = new List<PlayerData>();
        foreach (var photonPlayer in PhotonNetwork.PlayerListOthers)
        {
            var playerdata = new PlayerData();
            playerdata.playerName = photonPlayer.NickName;
            playerdata.playerActorNo = photonPlayer.ActorNumber;
            Debug.Log(photonPlayer.NickName + " : " + photonPlayer.ActorNumber);
            if (photonPlayer.CustomProperties.ContainsKey("position"))
            {
                playerdata.playerPosition = (int)photonPlayer.CustomProperties["position"];
            }
            roomPlayerList.Add(playerdata);

        }
        PokerClientManager.instance.AddRoomOpponents(roomPlayerList);



        countDownTimer = true;
        //timeToBegin = PhotonNetwork.CurrentRoom.CustomProperties["timerTillStart"] != null ? int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["timerTillStart"].ToString()) : -1;
        //if (timeToBegin != -1)
        //{
        //    StartCoroutine(startTimer());
        //}
        //else
        //{
        //    stopTimer();
        //}
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player Joined -" + " \n UserId : " + newPlayer.UserId + "\n ActNo : " + newPlayer.ActorNumber);
        InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
        PlayerData player = new PlayerData();
        player.playerName = newPlayer.NickName;
        player.playerActorNo = newPlayer.ActorNumber;
        PokerClientManager.instance.AddOpponent(player);
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        base.OnEnable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    #region PhotonFail_override_callbacks

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError(returnCode + " Create Room Failed" + message);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError(returnCode + " JoinRandom Room Failed" + message);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError(returnCode + " Join Room Failed" + message);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError(" Disconnected: " + cause);
    }
    #endregion
    void CreateOrJoinRoom()
    {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public void CallORCheckButton()
    {
        Debug.Log(isMyturn);
        if (!isMyturn) return;

        CallEvent(CHECK, null, null);
    }

    void Update()
    {

    }
    public void CallEvent(byte evCode, object DataContent, object type)
    {
        switch (evCode)
        {

            case CALL:
                PhotonNetwork.RaiseEvent(CALL, null, null, SendOptions.SendReliable);
                break;
            case CHECK:
                PhotonNetwork.RaiseEvent(CHECK, null, null, SendOptions.SendReliable);
                Debug.Log("Check Called");
                break;
            case FOLD: break;
            case RAISE: break;
        }

    }

    public void OnEvent(EventData photonEvent)
    {


        if (photonEvent.Code == INITSEAT)
        {
            //InfoText.text = "RoundStarted";
            var DActorPos = (Dictionary<int, int>)(photonEvent.Parameters[1]);
            List<PlayerData> playerDataList = new List<PlayerData>();
            var localPlayer = new PlayerData();
            localPlayer.playerName = PhotonNetwork.LocalPlayer.NickName;
            localPlayer.playerPosition = DActorPos[PhotonNetwork.LocalPlayer.ActorNumber];
            localPlayer.isLocalPlayer = true;
            playerDataList.Add(localPlayer);

            foreach (var player in PhotonNetwork.PlayerListOthers)
            {
                if (DActorPos.ContainsKey(player.ActorNumber))
                {
                    var dataPlayer = new PlayerData();
                    dataPlayer.playerName = player.NickName;
                    dataPlayer.playerPosition = DActorPos[player.ActorNumber];
                }
            }

        }
        if (photonEvent.Code == TIMERGAMESTART)
        {
            timeToBegin = (float)(photonEvent.Parameters[3]);
            Debug.Log(timeToBegin);
            countDownTimer = true;
            StartCoroutine(startTimer());

            //Debug.Log("GameStartCalled");
        }
        if (photonEvent.Code == ROUNDSTART)
        {

            var startPlayerTurn = (int)photonEvent.Parameters[1];
            var playerCards = (int[])photonEvent.Parameters[2];
            Card card1 = new Card(playerCards[0], playerCards[1]);
            Card card2 = new Card(playerCards[2], playerCards[3]);


            if (startPlayerTurn == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                InfoText.text = "RoundStarted, Your Turn";
                isMyturn = true;
            }
            else
            {
                InfoText.text = "RoundStarted," + PokerClientManager.instance.DPokerPlayer[startPlayerTurn].PlayerName + "'s Turn";
                isMyturn = false;
            }

            Debug.Log("EVENTCARDATA: " + card1 + ", " + card2);
            PokerClientManager.instance.GivePlayerCards(card1, card2);
        }

        if (photonEvent.Code == SWITCHTURN)
        {
            var playerTurn = (int)photonEvent.Parameters[1];
            if (playerTurn == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                InfoText.text = "Your Turn";
                isMyturn = true;
            }
            else
            {
                InfoText.text = "" + PokerClientManager.instance.DPokerPlayer[playerTurn].PlayerName + "'s Turn";
                isMyturn = false;
            }
        }
        if (photonEvent.Code == FLOPCARDS)
        {
            var cards = (int[])photonEvent.Parameters[0];
            List<Card> flopCardList = new List<Card>();
            for(int i=0; i<3; i++)
            {
                Card card = new Card(cards[i], cards[i+3]);
                flopCardList.Add(card);
            }
            PokerClientManager.instance.SetBoardTableCard(flopCardList, 1);
        }
        if (photonEvent.Code == TURNCARD)
        {
            var cards = (int[])photonEvent.Parameters[0];
            List<Card> turncard = new List<Card>();
            Card card = new Card(cards[0], cards[1]);
            turncard.Add(card);
            
            PokerClientManager.instance.SetBoardTableCard(turncard, 2);
        }
        if (photonEvent.Code == RIVERCARD)
        {
            var cards = (int[])photonEvent.Parameters[0];
            List<Card> rivercard = new List<Card>();
            Card card = new Card(cards[0], cards[1]);
            rivercard.Add(card);

            PokerClientManager.instance.SetBoardTableCard(rivercard, 3);
        }
        if (photonEvent.Code == ROUNDEND)
        {
            Debug.Log("RoundEnd");
            InfoText.text = "End Round";
            isMyturn = false;
            var allPlayerCards = (Dictionary<int, int[]>)photonEvent.Parameters[0];
            foreach(var pactor in allPlayerCards.Keys)
            {
                Card card1 = new Card(allPlayerCards[pactor][0], allPlayerCards[pactor][1]);
                Card card2 = new Card(allPlayerCards[pactor][2], allPlayerCards[pactor][3]);
                PokerClientManager.instance.DPokerPlayer[pactor].SetAndShowPlayerCards(card1, card2);
            }
            PokerClientManager.instance.GameEnd();
            PhotonNetwork.Disconnect();
        }
            //Debug.Log(photonEvent.Code);
            if (photonEvent.Code == 12)
                Debug.Log(photonEvent.Parameters[0]);

        //if(photonEvent.Parameters != null)
        //
    }



    bool countDownTimer = false;
    public float timeDelay = 180;
    float timeToBegin = 0;
    TimeSpan t;
    WaitForSecondsRealtime waitTimer = new WaitForSecondsRealtime(0.2f);
    IEnumerator startTimer()
    {
        while (countDownTimer)
        {
            t = TimeSpan.FromMilliseconds(timeToBegin - PhotonNetwork.ServerTimestamp);
            if (t.TotalMilliseconds < 1000 && PhotonNetwork.IsMasterClient)
            {
                //last 10 seconds gives time for the last players to join
                PhotonNetwork.CurrentRoom.MaxPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
            }
            //Debug.Log(t.TotalMilliseconds);
            if (t.TotalMilliseconds > 0)
                InfoText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            else
            {

                //start game
                stopTimer();
            }
            yield return waitTimer;
        }
    }
    void stopTimer()
    {
        countDownTimer = false;
        //InfoText.text = "";
    }

}
