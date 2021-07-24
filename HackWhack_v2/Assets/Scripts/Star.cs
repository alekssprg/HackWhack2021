using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //        Debug.Log("OnTrigger" + other.gameObject.name + " " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Count += 10;
                Destroy(this.gameObject);
            }
        }
    }
}