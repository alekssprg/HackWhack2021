using Photon.Pun;
using UnityEngine;
public class Player : MonoBehaviour, IPunObservable
{
    public float speed = 10.0f;
    public int Health = 3;
    public int Count = 0;
    PhotonView view;
    private GameObject _grid;
    public GameObject grid 
    {
        get { return _grid; }
        set
        {
            _grid = value;
            _grid.gameObject.GetComponent<GridScript>().player = this;
        }
    }

    Rigidbody2D rb;
    private SpriteRenderer m_spriteRenderer;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(m_spriteRenderer.flipX);
        }
        else
        {
            m_spriteRenderer.flipX = (bool)stream.ReceiveNext();
        }
    }

    private void AddObservable()
    {
        if (!view.ObservedComponents.Contains(this))
        {
            view.ObservedComponents.Add(this);
        }
    }

    void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        AddObservable();
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Health == 0)
            {
                //respawn ??????
                transform.position = new Vector3(0.0f, 0.0f);
                Health = 3;
            }
            float translationY = Input.GetAxis("Vertical") * speed;
            float translationX = Input.GetAxis("Horizontal") * speed;

            //Debug.Log($"translationX: {translationX}, translationY:{translationY}");

            translationX *= Time.deltaTime;
            translationY *= Time.deltaTime;
            //????? ?? ???????
            if ((this.transform.position.x > 200) || (this.transform.position.x < -200)
                || (this.transform.position.y > 200) || (this.transform.position.y < -200))
            {
                transform.position = new Vector3(-8.0f, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_spriteRenderer.flipX = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_spriteRenderer.flipX = true;
            }
            transform.Translate(translationX, translationY, 0);

            Debug.Log(Count);
        }
    }
}
