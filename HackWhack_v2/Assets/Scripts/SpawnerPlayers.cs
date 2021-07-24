using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayers : MonoBehaviour
{
    public GameObject player;
    public GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(0, 0);
        var playerObject = PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
        playerObject.gameObject.GetComponent<Player>().grid = grid;
    }

    // Update is called once per frame
    void Update() 
    {

    }
}