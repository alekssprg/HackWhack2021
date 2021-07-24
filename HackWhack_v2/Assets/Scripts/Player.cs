using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public int Health = 3;
    public int Count = 0;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>(); 
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Health == 0)
            {
                //respawn игрока
                transform.position = new Vector3(0.0f, 0.0f);
                Health = 3;
            }
            float translationY = Input.GetAxis("Vertical") * speed;
            float translationX = Input.GetAxis("Horizontal") * speed;

            //Debug.Log($"translationX: {translationX}, translationY:{translationY}");

            translationX *= Time.deltaTime;
            translationY *= Time.deltaTime;
            //выход за границы
            if ((this.transform.position.x > 20) || (this.transform.position.x < -20)
                || (this.transform.position.y > 20) || (this.transform.position.y < -20))
            {
                transform.position = new Vector3(-8.0f, 0.5f);
            }

            transform.Translate(translationX, translationY, 0);

            Debug.Log(Count);
        }
    }
}
