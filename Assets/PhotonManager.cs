using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PhotonManager : MonoBehaviourPunCallbacks , IOnEventCallback
{
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    //Overriden callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        
        CreateOrJoinRoom();

        
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room, Room ID: " + PhotonNetwork.CurrentRoom.Name + " \n UserId : " + PhotonNetwork.LocalPlayer.UserId + "\n ActNo : " + PhotonNetwork.LocalPlayer.ActorNumber);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player Joined -" + " \n UserId : " + newPlayer.UserId + "\n ActNo : " + newPlayer.ActorNumber);
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
        Debug.LogError(returnCode + " Create Room Failed"+  message);
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
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

   
   
    void Update()
    {
        
    }
    public void SendDataToPhoton(int score)
    {
        PhotonNetwork.RaiseEvent(5, score, null, SendOptions.SendReliable);
    }
    public void OnEvent(EventData photonEvent)
    {
       
        //Debug.Log(photonEvent.Code);
        if(photonEvent.Code == 12)
            Debug.Log(photonEvent.Parameters[0]);
        //if(photonEvent.Parameters != null)
        //
    }
}
