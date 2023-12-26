using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button roomMake, roomJoin;
    [SerializeField] private InputField roomName, playerName;
    [SerializeField] private Text state;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        PhotonNetwork.ConnectUsingSettings();


    }
    void Start()
    {
        roomMake.onClick.AddListener(() => CreateRoom(roomName.text));
        roomJoin.onClick.AddListener(() => JoinRoom(roomName.text));


    }

    void Update()
    {
        state.text = PhotonNetwork.NetworkClientState.ToString();
    }

    public override void OnJoinedRoom() => PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).name = playerName.text;

    public void CreateRoom(string roomName) => PhotonNetwork.CreateRoom(roomName);

    public void JoinRoom(string roomName) => PhotonNetwork.JoinRoom(roomName);
}
