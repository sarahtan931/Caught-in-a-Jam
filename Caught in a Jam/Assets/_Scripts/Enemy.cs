using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    private Vector3 MovingDirection = Vector3.left;
    float timer = 0;
    private Vector3 startPos;
  
    public Slider slider;

    public int maxHealth = 5;
    public int health = 5;
    public HealthBar healthBar;

    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;
    
    public float delta = 0.5f;

    

    private readonly string selectedCharacter = "SelectedCharacter";


    // Update is called once per frame

    void Start()
    {
        startPos = transform.position;
        timer = 0;
        SetStats();
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
        timer = Time.deltaTime;
        if (timer > 2)
        {
            return;
        }
        else
        {
           UpdateMovement();

        }
        
    }

    public void SetStats()
    {
        if (this.gameObject.tag == "Ladybug")
        {
            maxHealth = 10;
        }
        if (this.gameObject.tag == "Grasshopper")
        {
            maxHealth = 15;
        }
        if (this.gameObject.tag == "Bee")
        {
            maxHealth = 20;
        }
    }

    public virtual void UpdateMovement()
    {
      if (this.transform.position.x > 1f)
    {
      MovingDirection = Vector3.left;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

       }
        else if (this.transform.position.x < -1.2f)
       {
            MovingDirection = Vector3.right;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        this.transform.Translate(MovingDirection * Time.smoothDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        // checks if the current GameObject triggering Hero's collider is the same as the last
        // if it is, the collision is ignored, if not it sets the lastTriggerGo to the current triggering Gameobject

        
        // destroys the enemy the GameObject collides with the enemy (object with tag "Enemy")
        if (go.tag == "Projectile")
        {
          //  health--;
            Destroy(go);
            TakeDamage(PlayerMovement.strength);
        }

        else if(go.tag == "Stick")
        {
           // health--;
            print(health);
            TakeDamage(PlayerMovement.strength);
        }

        

        if(health <= 0)
        {
            StatsSave.S.SetPoints();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Player" && PlayerPrefs.GetInt(selectedCharacter) == 1)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                print(point.normal.y);
                if (point.normal.y < 0f)
                {
                    TakeDamage(PlayerMovement.strength);                                                                                                                        
                }
            }
        }
        if (health <= 0)
        {
            StatsSave.S.SetPoints();
            Destroy(this.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.SetHealth(health);
    }

}

