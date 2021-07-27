using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Player player;
    private PhotonView view;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.gameObject.GetComponent<PhotonView>().IsMine)
            {
                Vector3 position = new Vector3(player.transform.position.x + 4.0f, player.transform.position.y, -10.0f);
                //Debug.Log("1" + Camera.main.transform.position);
                //Debug.Log("2" + position);
                Camera.main.transform.position = position;
            }
        }
    }
}