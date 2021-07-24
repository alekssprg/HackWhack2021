using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public string Direction;

    private float speed = 10.0f;
    float translationY = 0;
    float translationX = 0;

    void InitIfNeed()
    {
        if (!string.IsNullOrEmpty(Direction) && translationX == 0 && translationY == 0)
        {
            switch (Direction)
            {
                case "A":
                    translationX = -1.0f * speed;
                    break;
                case "D":
                    translationX = 1.0f * speed;
                    break;
                case "W":
                    translationY = 1.0f * speed;
                    break;
                case "S":
                    translationY = -1.0f * speed;
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(Direction))
        {
            InitIfNeed();
            // Make it move 10 meters per second instead of 10 meters per frame...
            var translationXActual = translationX * Time.deltaTime;
            var translationYActual = translationY * Time.deltaTime;
            //выход за границы
            if ((this.transform.position.x > 20) || (this.transform.position.x < -20)
                || (this.transform.position.y > 20) || (this.transform.position.y < -20))
            {
                Destroy(this.gameObject);
            }
            //if (this.transform.rotation.)
            // Move translation along the object's x and y axises
            transform.Translate(translationXActual, translationYActual, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTrigger" + other.gameObject.name + " " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Health = 0;
            }
            Destroy(this.gameObject);
        }
    }
}