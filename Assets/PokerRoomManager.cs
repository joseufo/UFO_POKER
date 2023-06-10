using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon;
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
        //base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        PokerManager = GetComponent<PokerOnlineManager>();
    }
    public override void OnDisable()
    {
        //base.OnEnable();
        PhotonNetwork.RemoveCallbackTarget(this);
       
    }
    public void CallEvent(byte evCode, object DataContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
    {
        PhotonNetwork.RaiseEvent(evCode, DataContent, raiseEventOptions, sendOptions);
        //switch (evCode)
        //{

        //    case ACCEPTBET:
        //        PhotonNetwork.RaiseEvent(ACCEPTBET, null, null, SendOptions.SendReliable);
        //        break;
        //    case CHECK:
        //        PhotonNetwork.RaiseEvent(CHECK, null, null, SendOptions.SendReliable);
        //        //Debug.Log("Check Called");
        //        break;
        //    case FOLD:
        //        PhotonNetwork.RaiseEvent(FOLD, null, null, SendOptions.SendReliable);
        //        break;
        //    case PLACEBET:
        //        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        //        PhotonNetwork.RaiseEvent(PLACEBET, DataContent, raiseEventOptions, SendOptions.SendReliable);
        //        break;
        //}

    }
    public void OnEvent(EventData photonEvent)
    {
        PokerManager.PokerEvent(photonEvent);
    }
    public void CallRpc(object data)
    {
        this.photonView.RPC(nameof(SendDataRpc), RpcTarget.Others, data);
    }
    [PunRPC]
    void SendDataRpc(object data)
    {
        Debug.LogError(data);
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
        PhotonPeer.RegisterType(typeof(CardData), (byte)1, SerializeCardData, DeserializeCardData);
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

    private byte[] SerializeCardData(object o)
    {
        CardData cardObject = o as CardData;
        if (cardObject == null) { return null; }
        using (var s = new MemoryStream())
        {
            using (var bw = new BinaryWriter(s))
            {
                bw.Write(cardObject.suit);
                bw.Write(cardObject.rank);
                return s.ToArray();
            }
        }
    }
    private object DeserializeCardData(byte[] bytes)
    {
        CardData cardObject = new CardData();
        using (var s = new MemoryStream(bytes))
        {
            using (var br = new BinaryReader(s))
            {
                cardObject.suit = br.ReadInt32();
                cardObject.rank = br.ReadInt32();

            }
        }
        return cardObject;
    }


}
