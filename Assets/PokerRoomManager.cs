using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class PokerRoomManager : MonoBehaviourPunCallbacks , IOnEventCallback
{
    public PokerOnlineManager PokerManager;
    public Dictionary<int, Player> DRoomPlayers = new Dictionary<int, Player>();
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        PokerManager = GetComponent<PokerOnlineManager>();
    }
    public override void OnDisable()
    {
        base.OnEnable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public void OnEvent(EventData photonEvent)
    {
        PokerManager.PokerEvent(photonEvent);
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
        PokerManager.ConnectedToMaster();


    }
    public override void OnJoinedRoom()
    {
       
        foreach(var roomPlayer in PhotonNetwork.PlayerListOthers)
        {
            DRoomPlayers.Add(roomPlayer.ActorNumber, roomPlayer);
        }
        PokerManager.ClientJoinedRoom();
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        DRoomPlayers.Add(newPlayer.ActorNumber, newPlayer);

        PokerManager.PlayerEnteredRoom(newPlayer);
    }
    #endregion

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
}
