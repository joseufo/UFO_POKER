using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class photonTest : MonoBehaviourPunCallbacks
{
    public bool master;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    string roomName = "myroom";
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = "Player123";
        base.OnConnectedToMaster();
        Debug.Log("Connected to Master");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.EmptyRoomTtl = 90000;
        roomOptions.PlayerTtl = 0;
        //roomOptions.MaxPlayers = 10;
        if (master)
            PhotonNetwork.CreateRoom(roomName);
        else
            PhotonNetwork.JoinRoom(roomName);
    }
    
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerTtl+"Joined Room, ActorNumber: " + PhotonNetwork.LocalPlayer.ActorNumber);
        if(!master)
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        //base.OnLeftRoom();
        PhotonNetwork.JoinRoom(roomName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
