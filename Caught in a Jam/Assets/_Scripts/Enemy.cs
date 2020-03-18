using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 MovingDirection = Vector3.left;
    float timer = 0;

    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {

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
    void Start()
    {
        timer = 0;
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

     void OnCollisionEnter2D(Collision2D coll) 
     {
        GameObject otherGo = coll.gameObject;
        if (otherGo.tag == "Projectile" || otherGo.tag == "Enemy")
        {
            Destroy(otherGo); //destroy the projectile 
            Destroy(gameObject); //destroy this enemy game object 
        }
        else
        {
            print("Enemy hit by non-Projectile: " + otherGo.name);
        }
    }
}

   