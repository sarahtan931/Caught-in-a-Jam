using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float zoomSpeed = 60f;
    public float jumpSpeed = 8f;
    private float movement = 0f;

    private Rigidbody2D rigidBody;
    // Use this for initialization
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    private bool direction;
    private bool isOnGround = false;

    private GameObject _lastTriggerGo = null;
    [SerializeField]
    private float _destroyEnemy = 1;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
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
 
    void onTriggerEnter2D(Collider2D collision)
    {
        
        Transform rootT = collision.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        // checks if the current GameObject triggering Hero's collider is the same as the last
        // if it is, the collision is ignored, if not it sets the lastTriggerGo to the current triggering Gameobject
        if (go == _lastTriggerGo)
        {
            return;
        }
        _lastTriggerGo = go;

        // destroys the enemy the GameObject collides with the enemy (object with tag "Enemy")
        if (go.tag == "Enemy")
        {
            destroyEnemy--;
            Destroy(go);
        }
    }
    public float destroyEnemy
    {
        get
        {
            return (_destroyEnemy);
        }
        set
        {
            _destroyEnemy = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
