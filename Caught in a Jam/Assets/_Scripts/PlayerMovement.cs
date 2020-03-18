using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    // Use this for initialization
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    private bool direction;
    private bool isOnGround = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        { // The script would be placed on the Ground object in this example
            isOnGround = true;

        }

    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            direction = true;
        }

        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            direction = false;
        }

        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            rigidBody.velocity = Vector2.up*jumpSpeed;
            isOnGround = false;
        }

        //allow the ship to fire 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
    }

    void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.transform.position = transform.position;
        Rigidbody2D rigidB = projGo.GetComponent<Rigidbody2D>();
       //rojectile testProj = projGo.GetComponent<Projectile>();

       if (direction == true)
       {
            rigidB.velocity = Vector2.right * projectileSpeed;
        }
       else
       {
            rigidB.velocity = Vector2.left * projectileSpeed;
        }
    }
}