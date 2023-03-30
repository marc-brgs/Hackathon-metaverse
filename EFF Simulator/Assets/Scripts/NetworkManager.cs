using System;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields
       
    public GameObject playerPrefab;
    public GameObject extinguisherPrefab;
    public GameObject civilianPrefab;
    
    #endregion

    #region Public Variables
    
    #endregion

    #region Private Fields

    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "0.1";

    
    #endregion


    #region MonoBehaviour CallBacks

    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        Connect();
    }

   

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        
        PhotonNetwork.CreateRoom("Test", new RoomOptions());

        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        //instantiate the player prefab on the network 
        Vector3 position = new Vector3(43f, 0f, 15f);
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.Euler(0, 180, 0), 0);
        
        if (PhotonNetwork.IsMasterClient)
        {
            position = new Vector3(36.603f, 0.53f, -10.184f);
            PhotonNetwork.Instantiate(civilianPrefab.name, position, Quaternion.identity, 0);

            position = new Vector3(38.9f, 3.96f, -7.836442f);
            PhotonNetwork.Instantiate(civilianPrefab.name, position, Quaternion.identity, 0);
            
            position = new Vector3(32f, 0.8790878f, 5f);
            PhotonNetwork.Instantiate(extinguisherPrefab.name, position, Quaternion.identity, 0);
            
            position = new Vector3(37f, 0.8790878f, 5f);
            PhotonNetwork.Instantiate(extinguisherPrefab.name, position, Quaternion.identity, 0);
        }
        
        GameManager.instance.UpdateUI();
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}",
            cause);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion
}

