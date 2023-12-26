using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView photonView;

    private Rigidbody2D rigidbody2D;

    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 5;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        photonView.RPC("ChangeColor",RpcTarget.All);
    }

    void Move()
    {
        if (photonView.IsMine)
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            var vec = new Vector2(x, y).normalized * moveSpeed;

            rigidbody2D.velocity = vec;
        }
    }
    [PunRPC]
    void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var color_1 = Random.Range(0, 255);
            var color_2 = Random.Range(0, 255);
            var color_3 = Random.Range(0, 255);

            Color color = new Color(color_1, color_2, color_3, 1);
            spriteRenderer.color = color;
        }
    }
}
