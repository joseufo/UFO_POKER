using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

using System.Net;
public class PokerOnlineManager : MonoBehaviour
{
    public float SmallBlindAmount, BigBlindAmount, TotalCoinAmount;
    public Slider RaiseSlider;
    bool AutoCheck;
    public TMP_InputField NameInput;
    public Button JoinCreateButton;
    public TMP_Text InfoText;
    // Photon Event Codes from Server
    const byte INITSEAT = 51, SEATPLAYER = 55, TIMERGAMESTART = 101, ROUNDSTART = 105,  SWITCHTURN = 115,
            FLOPCARDS = 121, TURNCARD = 122, RIVERCARD = 123, ROUNDEND = 125;
    // Photon Event Codes from User
    const byte PLACEBET = 20, ACCEPTBET = 22, CHECK = 23, FOLD = 25 ;

    int minPlayers = 2, maxPlayers = 5;
    string playerNametest;


    PokerRoomManager RoomManager;
    bool isMyturn, roundStarted;
    void Awake()
    {
        RoomManager = GetComponent<PokerRoomManager>();
    }
    void Start()
    {
        
        //maxPlayers = 7;
        
        JoinCreateButton.onClick.AddListener(() => JoinOrHostGame());
        JoinCreateButton.gameObject.transform.parent.gameObject.SetActive(true);
        JoinCreateButton.gameObject.SetActive(false);
        //RaiseSlider.onValueChanged.AddListener(RaiserSlideValue);
        //var host = Dns.GetHostName
        //Debug.Log(host);
        //if (!connectOnline) return;
        ConnectToServer();
    }
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinOrHostGame()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
        if (String.IsNullOrEmpty(NameInput.text) || NameInput.text[0] == ' ')
        {
            if (PlayerPrefs.HasKey("name"))
            {
                playerNametest = PlayerPrefs.GetString("name");
            }
            else playerNametest = "Player" + UnityEngine.Random.Range(1, 10000);
        }            
        else
        {
            playerNametest = NameInput.text; PlayerPrefs.SetString("name", NameInput.text);
        }
        
      
        
        CreateOrJoinRoom();
        JoinCreateButton.gameObject.transform.parent.gameObject.SetActive(false);
        InfoText.text = "Joining/Hosting...";
        PhotonNetwork.LocalPlayer.NickName = playerNametest;
    }
    #region Photon Callbacks
    //Overriden callbacks
    public void ConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        JoinCreateButton.gameObject.SetActive(true);
        //CreateOrJoinRoom();
        PhotonNetwork.LocalPlayer.NickName = playerNametest;



    }
    public void ClientJoinedRoom()
    {
        return;
        Debug.Log("Joined Room, Room ID: " + PhotonNetwork.CurrentRoom.Name + " \n UserId : " + PhotonNetwork.LocalPlayer.UserId + "\n ActNo : " + PhotonNetwork.LocalPlayer.ActorNumber);
        InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
        //if(PhotonNetwork.CurrentRoom.CustomProperties["cSeat"] != null)

        int mySeat = (int)PhotonNetwork.CurrentRoom.CustomProperties["AvlSeat"];
        Hashtable seat = PhotonNetwork.CurrentRoom.CustomProperties;        
        seat["AvlSeat"] = mySeat +1;

        //Debug.Log(mySeat);
        PlayerData dataPlayer = new PlayerData();
        dataPlayer.playerName = playerNametest;
        dataPlayer.playerActorNo = PhotonNetwork.LocalPlayer.ActorNumber;
        //dataPlayer.playerPosition = PhotonNetwork.LocalPlayer.ActorNumber;
        dataPlayer.playerPosition = mySeat;
        PokerClientManager.instance.AddLocalPlayer(dataPlayer);
        List<PlayerData> roomPlayerList = new List<PlayerData>();
        foreach (var photonPlayer in PhotonNetwork.PlayerListOthers)
        {
            var playerdata = new PlayerData();
            playerdata.playerName = photonPlayer.NickName;
            playerdata.playerActorNo = photonPlayer.ActorNumber;
            playerdata.playerPosition = photonPlayer.ActorNumber;
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
    public void PlayerEnteredRoom(Player newPlayer)
    {
        return;
        Debug.Log("Player Joined -" + " \n UserId : " + newPlayer.UserId + "\n ActNo : " + newPlayer.ActorNumber);
        if(!roundStarted)
        InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
        PlayerData player = new PlayerData();
        player.playerName = newPlayer.NickName;
        player.playerPosition = newPlayer.ActorNumber;
        player.playerActorNo = newPlayer.ActorNumber;
        PokerClientManager.instance.AddOpponent(player);
    }
   

 

    #endregion
    void CreateOrJoinRoom()
    {
        Hashtable roomProps = new Hashtable();
        roomProps["smallBlind"] = SmallBlindAmount;
        roomProps["bigBlind"] = BigBlindAmount;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.CustomRoomProperties = roomProps;
        //roomOptions.MaxPlayers = (byte)maxPlayers;
        //PhotonNetwork.JoinRandomOrCreateRoom(roomProps,(byte)5,MatchmakingMode.SerialMatching, null,null,null, roomOptions,null);
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    public void AutoCheckChange(bool value) { AutoCheck = value; if(isMyturn) CallORCheckButton(); }

    public void CallORCheckButton()
    {
        Debug.Log(isMyturn);
        if (!isMyturn) return;
        
        CallEvent(CHECK, null, null);
    }
   
    public void FoldButton()
    {
        Debug.Log(isMyturn);
        if (!isMyturn) return;

        CallEvent(FOLD, null, null);
        InfoText.text = " You Folded  ";
        PokerClientManager.instance.Fold();
    }

    void Update()
    {

    }
    public void CallEvent(byte evCode, object DataContent, object type)
    {
        switch (evCode)
        {

            case ACCEPTBET:
                PhotonNetwork.RaiseEvent(ACCEPTBET, null, null, SendOptions.SendReliable);
                break;
            case CHECK:
                PhotonNetwork.RaiseEvent(CHECK, null, null, SendOptions.SendReliable);
                //Debug.Log("Check Called");
                break;
            case FOLD:
                PhotonNetwork.RaiseEvent(FOLD, null, null, SendOptions.SendReliable);
                break;
            case PLACEBET: break;
        }
        
    }

    public void PokerEvent(EventData photonEvent)
    {


        if (photonEvent.Code == INITSEAT)
        {
            Debug.Log("Joined Room, Room ID: " + PhotonNetwork.CurrentRoom.Name + " \n UserId : " + PhotonNetwork.LocalPlayer.UserId + "\n ActNo : " + PhotonNetwork.LocalPlayer.ActorNumber);
            InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
            //if(PhotonNetwork.CurrentRoom.CustomProperties["cSeat"] != null)

            //int mySeat = (int)PhotonNetwork.CurrentRoom.CustomProperties["AvlSeat"];
            //Hashtable seat = PhotonNetwork.CurrentRoom.CustomProperties;
            //seat["AvlSeat"] = mySeat + 1;
            //Debug.Log((int)PhotonNetwork.LocalPlayer.CustomProperties["SeatPos"] + "ssseat");
            int myseat = (int)photonEvent.Parameters[0];
            //Debug.Log(mySeat);
            PlayerData dataPlayer = new PlayerData();
            dataPlayer.playerName = playerNametest;
            dataPlayer.playerActorNo = PhotonNetwork.LocalPlayer.ActorNumber;
            //dataPlayer.playerPosition = PhotonNetwork.LocalPlayer.ActorNumber;
            dataPlayer.playerPosition = myseat;
            PokerClientManager.instance.AddLocalPlayer(dataPlayer);
            List<PlayerData> roomPlayerList = new List<PlayerData>();
            Dictionary<int, int> playerSeats = (Dictionary<int, int>)photonEvent.Parameters[2];
            foreach (var photonPlayer in PhotonNetwork.PlayerListOthers)
            {
                var playerdata = new PlayerData();
                playerdata.playerName = photonPlayer.NickName;
                playerdata.playerActorNo = photonPlayer.ActorNumber;
                playerdata.playerPosition = playerSeats[photonPlayer.ActorNumber];
                Debug.Log(photonPlayer.NickName + " : " + photonPlayer.ActorNumber);
                if (photonPlayer.CustomProperties.ContainsKey("SeatPos"))
                {
                    playerdata.playerPosition = (int)photonPlayer.CustomProperties["SeatPos"];
                }
                roomPlayerList.Add(playerdata);

            }
            PokerClientManager.instance.AddRoomOpponents(roomPlayerList);



            countDownTimer = true;

        }
       
        if (photonEvent.Code == SEATPLAYER)
        {
            int playerSeat = (int)photonEvent.Parameters[0];
            int playerActorKey = (int)photonEvent.Parameters[1];
            if(RoomManager.DRoomPlayers.ContainsKey(playerActorKey))
            {
                
                Player newPlayer = RoomManager.DRoomPlayers[playerActorKey];
                Debug.Log("Player Joined -" + " \n UserId : " + newPlayer.UserId + "\n ActNo : " + newPlayer.ActorNumber);
                if (!roundStarted)
                    InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
                PlayerData player = new PlayerData();
                player.playerName = newPlayer.NickName;
                player.playerPosition = playerSeat;
                player.playerActorNo = newPlayer.ActorNumber;
                PokerClientManager.instance.AddOpponent(player);
            }
            else { Debug.LogError("NO PLAYER IN DICT WITH ACTORNO " + playerActorKey); }
            
        }
            if (photonEvent.Code == TIMERGAMESTART)
        {
            //if((int)PhotonNetwork.CurrentRoom.CustomProperties["BeginTime"] != -1)
            timeToBegin = (float)PhotonNetwork.CurrentRoom.CustomProperties["BeginTime"];
            //timeToBegin = (float)(photonEvent.Parameters[3]);
            //Debug.Log(timeToBegin);
            countDownTimer = true;
            StartCoroutine(startTimer());
            
            //Debug.Log("GameStartCalled");
        }
        if (photonEvent.Code == ROUNDSTART)
        {

            PokerClientManager.instance.RoundStart();
            roundStarted = true;
            var startPlayerTurn = (int)photonEvent.Parameters[1];
            var playerCards = (int[])photonEvent.Parameters[2];
            var cardtest = (CardData)photonEvent.Parameters[3];
            Debug.Log("CARD...DATA.." + cardtest.suit + "," + cardtest.rank);

            Card card1 = new Card(playerCards[0], playerCards[1]);
            Card card2 = new Card(playerCards[2], playerCards[3]);


            if (startPlayerTurn == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                InfoText.text = "RoundStarted, Your Turn";
                isMyturn = true;
                if(AutoCheck)CallORCheckButton();
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
            //
            string msg = "";
            if(photonEvent.Parameters[0] != null)
            {
                PokerClientManager.instance.PlayerSitBack((int)photonEvent.Parameters[0]);
            }
            var playerTurn = (int)photonEvent.Parameters[2];
            if (playerTurn == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                InfoText.text = "Your Turn";
                isMyturn = true;
                if (AutoCheck) CallORCheckButton();
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
            PokerClientManager.instance.RoundEnd();
            roundStarted = false;
            //PhotonNetwork.Disconnect();
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
                //PhotonNetwork.CurrentRoom.MaxPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
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
