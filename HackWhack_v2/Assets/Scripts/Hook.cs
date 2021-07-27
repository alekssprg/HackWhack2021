using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hook : MonoBehaviour
{
    public GameObject HookFiringObject;
    public GameObject FireObject;
    private Text text;
    private bool empty = false;
    private int FireCount = 20;
    void Start()
    {
        text = this.gameObject.GetComponentInChildren<Text>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            text.text = "Íאזלטעו ןנמבוכ.";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if ((!empty) && (FireCount > 0))
                {
                    var hookFiring = HookFiringObject?.GetComponent<HookFiring>();
                    if (hookFiring != null)
                    {
                        var position = HookFiringObject.transform.position;
                        var fireObjectCopy = PhotonNetwork.Instantiate("FiringBullet", HookFiringObject.transform.position, Quaternion.identity);
                        var fireBullet = fireObjectCopy.gameObject.GetComponent<FireBullet>();
                        if (fireBullet != null)
                        {
                            fireBullet.Direction = hookFiring.Direction;
                        }
                        FireCount--;
                    }
                    empty = true;
                }
                else
                {
                    empty = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    { //גûרוככ ס ענטדדונא
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}