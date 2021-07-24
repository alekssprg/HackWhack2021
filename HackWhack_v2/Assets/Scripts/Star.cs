using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public int index = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Count += 10;
                PhotonNetwork.Destroy(this.gameObject);
            }
            Spawner.singleton.CreateOneStar();
            Spawner.singleton.AddSpareStat(this.index);
        }
    }
}