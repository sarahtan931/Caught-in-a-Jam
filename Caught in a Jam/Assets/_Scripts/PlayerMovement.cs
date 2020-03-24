using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //FINAL VERSION
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    // Use this for initialization
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public static bool direction;
    private float increaseSpeed = 0;
    private bool isOnGround = false;

    public GameObject doorPrefabVar;
    private GameObject door;

    public Slider slider;


    public int maxHealth = 5;
    public int health = 0;
    public static int key = 0;
    private readonly string selectedCharacter = "SelectedCharacter";

    public HealthBar healthBar;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = false;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
      
    }

    public void SetStats()
    {
        if (PlayerPrefs.GetInt(selectedCharacter) == 1)
        {

        }
        if (PlayerPrefs.GetInt(selectedCharacter) == 2)
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            isOnGround = true;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            if (PlayerPrefs.GetInt(selectedCharacter) == 1)
            {
                foreach (ContactPoint2D point in collision.contacts)
                {
                    if (point.normal.y >= 0.9f)
                    {
                        Vector2 velocity = rigidBody.velocity;
                        velocity.y = jumpSpeed;
                        rigidBody.velocity = velocity;

                    }
                    else { 
                        //health--;
                        TakeDamage(1);
                    }
                }
            }
            else { //health--;
                TakeDamage(1);
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
            LoadGameOverScene();
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform rootT = collision.gameObject.transform.root;
        GameObject go = rootT.gameObject;
       
        // destroys the enemy the GameObject collides with the enemy (object with tag "Enemy")
        if (go.tag == "pickUp")
        {
            Destroy(go);
            increaseSpeed++;
            if (increaseSpeed == 3)
            {
                speed = 130f;
            }
            
        }

        if (go.tag == "Key")
        {
            print("Picked up key");
            key++;
            getDoor();
            Destroy(go);
          
        }

        if(go.tag == "Door")
        {
            LoadNextScene();
        }
    }

    public void getDoor()
    {
        Vector3 keyPosition = new Vector3(0, 0, 0);

        if (key >= 3)
        {
            door = Instantiate(doorPrefabVar);
            door.transform.position = door.transform.position + keyPosition;
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

   void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.SetHealth(health);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(0);
    }

}
