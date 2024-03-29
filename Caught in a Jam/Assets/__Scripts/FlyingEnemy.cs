﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingEnemy : MonoBehaviour
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

    private GameObject _lastTriggerGo = null;

    private readonly string selectedCharacter = "SelectedCharacter";


    // Update is called once per frame

    void Start()
    {
        startPos = transform.position;
        timer = 0;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
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


    public virtual void UpdateMovement()
    {
        if (this.transform.position.y > 1f)
        {
            MovingDirection = Vector3.up;

        }
        else if (this.transform.position.y < -1.2f)
        {
            MovingDirection = Vector3.down;

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
            Destroy(go);
            TakeDamage(1);
        }

        else if (go.tag == "Stick")
        {
            print(health);
            TakeDamage(1);
        }



        if (health <= 0)
        {
            PlayerMovement.points++;
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
                    TakeDamage(1);
                }
            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.SetHealth(health);
    }

}