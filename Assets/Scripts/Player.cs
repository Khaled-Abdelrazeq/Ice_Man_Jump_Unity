using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    
    public float moveSpeed = 10;

    Rigidbody2D rb;
    float movement = 0;

    public static Player instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        GameManager.instance.isPlayed = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //GET X Asis movement
        movement = Input.GetAxis("Horizontal") * moveSpeed;

        // IF Fail
        destroyPlayer();

        //DON'T ALLOW PLAYER MOVING OUTSIDE SCREEN
        if (transform.position.x > 2.3)
        {
            transform.position = new Vector3(2.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -2.3)
        {
            transform.position = new Vector3(-2.3f, transform.position.y, 0);
        }

        // PLAYER SUCCESS
        if (transform.gameObject != null)
        {
            if (transform.position.y > GameObject.FindGameObjectWithTag("LastPlatform").transform.position.y)
                GameManager.instance.onPlayerSuccess();
        }
    }

    private void FixedUpdate()
    {
        //MOVE PLAYER
        rb.velocity = new Vector2(movement, rb.velocity.y);
        
    }

    private void destroyPlayer()
    {
          if  (Camera.main.transform.position.y > transform.position.y + 5)
        {
            GameManager.instance.onPlayerFail();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("LastPlatform"))
        {
            //Show Congratulation Panel
            GameManager.instance.onPlayerSuccess();
        }
    }
}
