using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class PokerRoomManager : MonoBehaviourPunCallbacks , IOnEventCallback
{
    
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
    public void OnEvent(EventData photonEvent)
    {
        throw new System.NotImplementedException();
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        
    }

    #region Photon Callbacks
    //Overriden callbacks
    public override void OnConnectedToMaster()
    {
        //Debug.Log("Connected To Master");
        //JoinCreateButton.gameObject.SetActive(true);
        ////CreateOrJoinRoom();
        //PhotonNetwork.LocalPlayer.NickName = playerNametest;



    }
    public override void OnJoinedRoom()
    {
       



        //countDownTimer = true;
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
        return;
        //Debug.Log("Player Joined -" + " \n UserId : " + newPlayer.UserId + "\n ActNo : " + newPlayer.ActorNumber);
        //if (!roundStarted)
        //    InfoText.text = "Joined..." + (PhotonNetwork.CurrentRoom.PlayerCount >= minPlayers ? "Waiting to Start" : "Waiting For Players");
        //PlayerData player = new PlayerData();
        //player.playerName = newPlayer.NickName;
        //player.playerPosition = newPlayer.ActorNumber;
        //player.playerActorNo = newPlayer.ActorNumber;
        //PokerClientManager.instance.AddOpponent(player);
    }
    #endregion
}
