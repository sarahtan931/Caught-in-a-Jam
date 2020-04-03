using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //FINAL VERSION
    public static float speed = 70f;
    public float jumpSpeed = 8f;
    public static int strength = 1;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    // Use this for initialization
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public static bool direction;
    private bool isOnGround = false;

    public GameObject doorPrefabVar;
    private GameObject door;
    public GameObject keyPrefabVar;


    public int maxHealth = 5;
    public int health = 0;
    public static int key = 0;
    public static int friend = 0;
    private readonly string selectedCharacter = "SelectedCharacter";

    public HealthBar healthBar;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = false;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        strength = StatsSave.S.strength;
        speed = StatsSave.S.speed;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    isOnGround = true;

                }
            }
        }

        if (collision.gameObject.tag == "Friend")
        {
            Destroy(collision.gameObject);
            Instantiate(keyPrefabVar, new Vector3(196.15f, -125.6f, 0), Quaternion.identity);
            Instantiate(keyPrefabVar, new Vector3(-203f, -123f, 0), Quaternion.identity);
            Instantiate(keyPrefabVar, new Vector3(-187f, 108f, 0), Quaternion.identity);
        }

        if (collision.gameObject.tag == "Ladybug" || collision.gameObject.tag == "Grasshopper" || collision.gameObject.tag == "Bee" || collision.gameObject.tag == "Caterpillar")
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
            ReloadGame();
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
        if (go.tag == "Water")
        {
            Destroy(go);
            SetSpeed(5);
            speed += 5;
        }

        if (go.tag == "Sunshine")
        {
            Destroy(go);
            SetStrength(1);
            strength++;
        }

        if (go.tag == "Key")
        {
            print("Picked up key");
            key++;
            GetDoor();
            Destroy(go);
          
        }

        if(go.tag == "Door")
        {
            LoadNextScene();
        }

        if (go.tag == "Teleport")
        {
            transform.position = go.transform.GetChild(0).position;
        }

        if(go.tag == "EnemyProjectile")
        {
            Destroy(go);
            TakeDamage(1);
            speed -= 10;
            StatsSave.S.LoseSpeed();
        }

        if(go.tag == "Friend")
        {
            friend++;
            GetDoor();
            Destroy(go);
        }
    }

    public void GetDoor()
    {
        Vector3 keyPosition = new Vector3(0, 0, 0);

        if (friend > 3)
        {

            door = Instantiate(doorPrefabVar);
            door.transform.position = door.transform.position;
        }
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

    public void ReloadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

    void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.SetHealth(health);
    }

  
    void SetSpeed(int s)
    {
        speed += s;
        StatsSave.S.SetSpeed(speed);

    }

    void SetStrength(int s)
    {
        strength += s;
        StatsSave.S.SetStrength(strength);
    }

    public void LoadGameOverScene()
    {
        Destroy(StatsSave.S.gameObject);
        SceneManager.LoadScene(0);
    }
}
