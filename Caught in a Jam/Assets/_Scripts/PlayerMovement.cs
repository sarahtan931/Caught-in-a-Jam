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
    private bool isOnGround = false;
    private Rigidbody2D combatJump;

    public static int health = 5;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = false;

        combatJump = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            isOnGround = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
         foreach (ContactPoint2D point in collision.contacts)
             if (point.normal.y >= 0.9f) { }
            else { health--; }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    Vector2 velocity = combatJump.velocity;
                    velocity.y = jumpSpeed;
                    combatJump.velocity = velocity;
                    Destroy(collision.collider.gameObject);
                }
            }
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
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
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

        // references the last GameObject that triggered Hero's collider
        void OnTriggerEnter2D(Collider2D collider)
        {
            Transform rootT = collider.gameObject.transform.root;
            GameObject go = rootT.gameObject;

            // destroys the enemy the GameObject collides with the enemy (object with tag "Enemy")
            if (go.tag == "pickUp")
            {

                Destroy(go);
            }


        }
    }
