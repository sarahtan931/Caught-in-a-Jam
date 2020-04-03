using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
   //Declaring the speed of the player as well as a rigidbody
    public float speed;
    public PlayerMovement player;
    private Rigidbody2D rb;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
   
    }

   

}
