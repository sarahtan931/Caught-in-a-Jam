using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _lastTriggerGo = null;
    private Vector3 MovingDirection = Vector3.left;
    float timer = 0;
    private int health = 10;
    private float _destroyEnemy = 3;

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

    void OnTriggerEnter2D(Collider2D collision)
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
        if (go.tag == "Projectile")
        {
            health--;
            Destroy(go);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

   