using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingEnemy : Enemy
{

    private Vector3 MovingDirection = Vector3.left;
    float timer = 0;
    private Vector3 startPos;

    // Update is called once per frame

    void Start()
    {
        startPos = transform.position;

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


    public override void UpdateMovement()
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

}