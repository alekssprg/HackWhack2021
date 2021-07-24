using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createRoomText;
    public TMP_InputField joinRoomText;


    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createRoomText.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomText.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameMapOneScene");
    }
}
